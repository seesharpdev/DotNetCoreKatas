using System.Reflection;

using Xunit;

using DotNetCoreKatas.Core.Domain;
using DotNetCoreKatas.Core.Interfaces;
using DotNetCoreKatas.Domain.Models;

namespace DotNetCoreKatas.Domain.UnitTests
{
    public class DomainModelUnitTests
    {
	    private static class Factory
	    {
		    internal static IAggregateRoot<int> New(int id)
		    {
			    var domainModel = DomainModel<int>.Factory.New(id);

				return domainModel;
		    }
	    }

	    [Fact]
	    public void DomainModel_Should_Have_Private_Ctor()
	    {
			// arrange
		    const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Static | 
				BindingFlags.NonPublic | BindingFlags.Instance;

		    // Act
		    ConstructorInfo[] ctorInfo = typeof(DomainModel<>).GetConstructors(bindingFlags);

			// Assert
			Assert.Single(ctorInfo);
			Assert.True(ctorInfo[0].IsPrivate);
		}

	    [Fact]
	    public void DomainModel_Should_Be_Instantiated_By_The_Factory()
	    {
		    // Act
		    var domainModel = Factory.New(1);

		    // Assert
			Assert.NotNull(domainModel);
		}

		[Fact]
        public void DomainModel_Should_Inherit_From_AggregateRoot()
        {
			// Act
			var domainModel = Factory.New(1);

			// Assert
			Assert.Equal(typeof(AggregateRoot<int>), domainModel.GetType().BaseType);
        }
    }
}
