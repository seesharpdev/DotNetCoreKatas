using System;

namespace DotNetCoreKatas.Core.Interfaces.Messaging
{
	public interface IMessage<T> : IMessage where T : new()
	{
		T Payload { get;  }
	}

	public interface IMessage
	{
		Guid CorrelationId { get; }

		// TODO: Add a TimeStamp?
	}
}