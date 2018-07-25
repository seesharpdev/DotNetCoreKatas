using DotNetCoreKatas.Core.Interfaces.Commanding;

namespace DotNetCoreKatas.Command.Adapter.Commands
{
	public class DomainCommand : IDomainCommand
	{
		public int Id { get; set; }
	}
}