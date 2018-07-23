using Xunit;

using DotNetCoreKatas.Core.Domain;
using DotNetCoreKatas.Core.Interfaces;

namespace DotNetCoreKatas.Core.UnitTests
{
	public class EntityUnitTests
    {
	    [Fact]
	    public void Entity_Should_Be_Abstract()
	    {
			// Act
		    var entity = default(Entity<int>);

			// Assert
			Assert.Null(entity);
		}

	    [Fact]
	    public void Entity_Should_Implement_Interface()
	    {
			// Arrange
		    var type = typeof(Entity<int>);

		    // Act
		    var @interface = type.GetInterface(typeof(IEntity<>).FullName);

		    // Assert
		    Assert.NotNull(@interface);
			Assert.Equal(typeof(IEntity<int>), @interface);
		}

	    [Fact]
	    public void Entity_Should_Be_Keyed()
	    {
			// Act
		    var type = typeof(Entity<int>);

		    // Assert
		    Assert.NotNull(type.GetProperty("Id"));
	    }

	    [Fact]
	    public void Entity_Should_Be_Versioned()
	    {
		    // Act
		    var type = typeof(Entity<int>);

		    // Assert
		    Assert.NotNull(type.GetProperty("Version"));
	    }
	}
}
