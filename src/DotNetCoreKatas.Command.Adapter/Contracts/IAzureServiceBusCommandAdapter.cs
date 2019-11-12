using System;
using System.Threading.Tasks;

using DotNetCoreKatas.Command.Contracts;
using DotNetCoreKatas.Core.Interfaces.Commanding;

namespace DotNetCoreKatas.Command.Adapter.Contracts
{
	public interface IAzureServiceBusCommandAdapter : ICommandAdapter
	{
	}
}