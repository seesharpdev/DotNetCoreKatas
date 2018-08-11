using DotNetCoreKatas.Core.Domain;

namespace DotNetCoreKatas.Command.Contracts
{
	public class RegisterBookCommand : CommandBase, ICreateBookCommand
	{
		public int Id { get; set; }
	}
}