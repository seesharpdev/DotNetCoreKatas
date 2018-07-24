using Xunit;

using DotNetCoreKatas.Domain.Models;
using DotNetCoreKatas.QueryAdapter.Contracts;
using DotNetCoreKatas.QueryAdapter.Mappers;

namespace DotNetCoreKatas.QueryAdapter.UnitTests.Mappers
{
	public class BookDomainModelMapper
    {
		[Fact]
	    public void Mapper_Should_Map()
	    {
			// Arrange
		    const int modelId = 1;
		    var model = new BookDomainModel(modelId);
		    var mapper = new BookModelMapper();

		    // Act
		    var readModel = mapper.Map(model);

		    // Assert
			Assert.NotNull(readModel);
		    Assert.IsType<BookReadModel>(readModel);
			Assert.Equal(modelId, readModel.Id);
	    }
    }
}
