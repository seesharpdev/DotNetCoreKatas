using System;

namespace DotNetCoreKatas.Core.Interfaces.Messaging
{
	public interface IMessage
	{
		Guid CorrelationId { get; }
	}
}