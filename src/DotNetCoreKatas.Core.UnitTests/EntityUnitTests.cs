using Xunit;

using DotNetCoreKatas.Core.Domain;

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
    }
}
