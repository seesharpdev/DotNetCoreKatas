using DotNetCoreKatas.Core.Interfaces.Messaging;

namespace DotNetCoreKatas.Core.Interfaces.Commanding
{
	/// <summary>
	/// Marker interface for a Domain Command.
	/// </summary>
	public interface ICommand : IMessage
	{
	}
}