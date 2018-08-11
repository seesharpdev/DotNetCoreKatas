using DotNetCoreKatas.Core.Domain;

namespace DotNetCoreKatas.Command.Contracts
{
	public class UpdateBookCommand : CommandBase, IUpdateBookCommand
	{
		public int Id { get; set; }
	}
}