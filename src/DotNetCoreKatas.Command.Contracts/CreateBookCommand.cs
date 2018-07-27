using DotNetCoreKatas.Core.Domain;

namespace DotNetCoreKatas.Command.Contracts
{
	public class CreateBookCommand : CommandBase, ICreateBookCommand
	{
		public int Id { get; set; }
	}
}