using System.Threading.Tasks;

using DotNetCoreKatas.Command.Contracts;
using DotNetCoreKatas.Core.Interfaces.Commanding;
using DotNetCoreKatas.Domain.Models;
using DotNetCoreKatas.Persistence;

namespace DotNetCoreKatas.Command.Adapter.Handlers
{
	public class CreateBookCommandHandler : ICommandHandler<CreateBookCommand>
	{
		private readonly IDotNetCoreKatasDbContext _dbContext;

		public CreateBookCommandHandler(IDotNetCoreKatasDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Task Execute(CreateBookCommand command)
		{
			BookDomainModel book = new BookDomainModel(command.Id);
			_dbContext.Books.Add(book);

			// TODO: Raise Event?

			return Task.CompletedTask;
		}
	}
}