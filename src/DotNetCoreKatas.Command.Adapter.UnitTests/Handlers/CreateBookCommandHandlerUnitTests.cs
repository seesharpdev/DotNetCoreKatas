using Autofac.Extras.Moq;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

using DotNetCoreKatas.Command.Adapter.Handlers;
using DotNetCoreKatas.Command.Contracts;
using DotNetCoreKatas.Domain.Models;
using DotNetCoreKatas.Persistence;

namespace DotNetCoreKatas.Command.Adapter.UnitTests.Handlers
{
	public class CreateBookCommandHandlerUnitTests
    {
	    [Fact]
	    public void Handler_Should_Create_Book()
	    {
		    using (var mock = AutoMock.GetStrict())
		    {
			    // Arrange
			    mock.Mock<IDotNetCoreKatasDbContext>()
				    .Setup(_ => _.Books)
				    .Returns(new Mock<DbSet<BookDomainModel>>().Object);

			    var handler = mock.Create<CreateBookCommandHandler>();
			    var command = new CreateBookCommand { Id = 1 };

			    // Act
			    var result = handler.Execute(command);

			    // Assert
			    Assert.NotNull(result);
			    Assert.False(result.IsFaulted);
		    }
	    }
    }
}
