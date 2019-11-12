using System.Threading.Tasks;

using DotNetCoreKatas.Command.Contracts;
using DotNetCoreKatas.Core.Interfaces.Commanding;
using DotNetCoreKatas.Domain.Models;
using DotNetCoreKatas.Persistence;

namespace DotNetCoreKatas.Command.Adapter.Handlers
{
	public class RegisterBookCommandHandler : ICommandHandler<RegisterBookCommand>
	{
		private readonly IDotNetCoreKatasDbContext _dbContext;

		public RegisterBookCommandHandler(IDotNetCoreKatasDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Task Handle(RegisterBookCommand command)
		{
			var book = BookDomainModel.Create(command.Id);
			book.SetTitle(command.Title)
				.SetIsbn(command.Isbn);

			// TODO: Raise Event from AggregateRoot when applying EventSourcing.
			_dbContext.Books.Add(book);
			_dbContext.SaveChanges();

			return Task.CompletedTask;
		}
	}
}