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
			Assert.Equal(typeof(IEntity<int>), type.BaseType.GetInterface(typeof(IEntity<>).FullName));
	    }

	    [Fact]
	    public void AggregateRoot_Should_Implement_Interfaces()
	    {
			// Act
			var type = typeof(AggregateRoot<int>);

			// Assert
			Assert.Equal(typeof(IEntity<int>), type.GetInterface(typeof(IEntity<>).FullName));
			Assert.Equal(typeof(IAggregateRoot<int>), type.GetInterface(typeof(IAggregateRoot<>).FullName));
	    }
    }
}