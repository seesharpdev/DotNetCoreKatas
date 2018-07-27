using System;

namespace DotNetCoreKatas.Core.Domain
{
	public class CommandBase
	{
		public CommandBase()
		{
			CorrelationId = Guid.NewGuid();
		}

		public Guid CorrelationId { get; }
	}
}