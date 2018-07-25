using DotNetCoreKatas.Command.Adapter.Contracts;

namespace DotNetCoreKatas.Command.Adapter.Commands
{
	public class UpdateBookCommand : IUpdateBookCommand
	{
		public int Id { get; set; }
	}
}