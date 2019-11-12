using System.Threading.Tasks;

using DotNetCoreKatas.Command.Adapter.Contracts;
using DotNetCoreKatas.Command.Contracts;
using DotNetCoreKatas.Core.Interfaces.Commanding;

namespace DotNetCoreKatas.Command.Adapter
{
	public class AzureServiceBusCommandAdapter : IAzureServiceBusCommandAdapter
	{
        public AzureServiceBusCommandAdapter()
        {
            
        }

        public void Dispatch(ICommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}