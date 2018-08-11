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

			    mock.Mock<IDotNetCoreKatasDbContext>()
				    .Setup(_ => _.SaveChanges())
				    .Returns(1);

			    var handler = mock.Create<RegisterBookCommandHandler>();
			    var command = new RegisterBookCommand { Id = 1 };

			    // Act
			    var result = handler.Execute(command);

			    // Assert
			    Assert.NotNull(result);
			    Assert.False(result.IsFaulted);
			    mock.Mock<IDotNetCoreKatasDbContext>()
				    .VerifyAll();
		    }
	    }
    }
}
