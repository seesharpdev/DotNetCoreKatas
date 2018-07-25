using System.Threading.Tasks;
using DotNetCoreKatas.Command.Contracts;

namespace DotNetCoreKatas.Command.Adapter.Contracts
{
	public interface IBooksCommandAdapter
	{
		Task CreateBook(ICreateBookCommand command);
		Task UpdateBook(IUpdateBookCommand command);
		Task DeleteBook(IDeleteBookCommand command);
	}
}