using DotNetCoreKatas.Core.Interfaces.Messaging;

namespace DotNetCoreKatas.Core.Interfaces.Domain
{
	/// <summary>
	/// Marker interface for a Domain Event.
	/// </summary>
	public interface IDomainEvent<T> : IMessage where T : IEntity
	{
		string Describe();
	}
}