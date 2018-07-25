using DotNetCoreKatas.Command.Adapter.Contracts;

namespace DotNetCoreKatas.Command.Adapter.Commands
{
	public class CreateBookCommand : ICreateBookCommand
	{
		public int Id { get; set; }
	}
}