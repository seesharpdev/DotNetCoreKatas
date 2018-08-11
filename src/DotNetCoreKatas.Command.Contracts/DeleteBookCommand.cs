using DotNetCoreKatas.Core.Domain;

namespace DotNetCoreKatas.Command.Contracts
{
	public class DeleteBookCommand : CommandBase, IDeleteBookCommand
	{
		public int Id { get; set; }
	}
}