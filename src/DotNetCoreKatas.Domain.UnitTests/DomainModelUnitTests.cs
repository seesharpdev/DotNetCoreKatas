using System.Linq;
using System.Reflection;

using Xunit;

using DotNetCoreKatas.Core.Interfaces;
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
	    public void DomainModel_Should_Only_Have_A_Public_And_A_Private_Ctors()
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
		public void DomainModel_Should_Implement_IAggregateRoot()
        {
			// Act
			var domainModel = Factory.New(1);

			// Assert
			Assert.Equal(typeof(IAggregateRoot<int>), domainModel.GetType().GetInterfaces().FirstOrDefault());
        }
    }
}
