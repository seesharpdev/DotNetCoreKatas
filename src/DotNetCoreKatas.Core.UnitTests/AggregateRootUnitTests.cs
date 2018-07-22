using Xunit;

using DotNetCoreKatas.Core.Domain;
using DotNetCoreKatas.Core.Interfaces;

namespace DotNetCoreKatas.Core.UnitTests
{
	public class AggregateRootUnitTests
    {
		[Fact]
	    public void AggregateRoot_Should_Be_Abstract()
		{
			// Act
			var aggregateRoot = default(AggregateRoot<int>);

			// Assert
			Assert.Null(aggregateRoot);
		}

	    [Fact]
	    public void AggregateRoot_Should_Inherit_From_Entity()
	    {
			// Act
		    var type = typeof(AggregateRoot<int>);

			// Assert
			Assert.Equal(typeof(Entity<int>), type.BaseType);
	    }

	    [Fact]
	    public void AggregateRoot_Should_Expose_Interface()
	    {
		    // Act
		    var interfaces = typeof(AggregateRoot<int>).GetInterfaces();

		    // Assert
			Assert.Equal(typeof(IAggregateRoot), interfaces[0]);
	    }
    }
}