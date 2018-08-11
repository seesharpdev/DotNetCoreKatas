using System;
using System.Threading.Tasks;

using DotNetCoreKatas.Command.Contracts;
using DotNetCoreKatas.Core.Interfaces.Commanding;

namespace DotNetCoreKatas.Command.Adapter.Contracts
{
	public interface IBooksCommandAdapter : ICommandAdapter
	{
		[Obsolete("To be replaced by ICommandAdapter.Dispatch.")]
		Task CreateBook(ICreateBookCommand command);

		[Obsolete("To be replaced by ICommandAdapter.Dispatch.")]
		Task UpdateBook(IUpdateBookCommand command);

		[Obsolete("To be replaced by ICommandAdapter.Dispatch.")]
		Task DeleteBook(IDeleteBookCommand command);
	}
}