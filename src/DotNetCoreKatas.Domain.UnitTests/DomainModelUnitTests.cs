using System.Reflection;

using Xunit;

using DotNetCoreKatas.Core.Domain;
using DotNetCoreKatas.Domain.Models;

namespace DotNetCoreKatas.Domain.UnitTests
{
    public class DomainModelUnitTests
    {
	    private static class Factory
	    {
		    internal static DomainModel New(int id)
		    {
			    var domainModel = new DomainModel(id);

				return domainModel;
		    }
	    }

	    [Fact]
	    public void DomainModel_Should_Have_Protected_Ctor()
	    {
			// arrange
		    const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Static | 
				BindingFlags.NonPublic | BindingFlags.Instance;

		    // Act
		    ConstructorInfo[] ctorInfo = typeof(DomainModel).GetConstructors(bindingFlags);

			// Assert
			Assert.Equal(2, ctorInfo.Length);
			Assert.Contains(ctorInfo, c => c.IsPublic);
			Assert.Contains(ctorInfo, c => c.IsPrivate);
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
