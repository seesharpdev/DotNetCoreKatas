using System;
using System.Text;

using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;

using DotNetCoreKatas.Command.Adapter.Contracts;
using DotNetCoreKatas.Core.Interfaces.Commanding;

namespace DotNetCoreKatas.Command.Adapter
{
    public class AzureServiceBusCommandAdapter : IAzureServiceBusCommandAdapter
	{
        private readonly IQueueClient _client;

        public AzureServiceBusCommandAdapter(IQueueClient client)
        {
            _client = client;
        }

        public void Dispatch(ICommand command)
        {
            try
            {
                var payload = JsonConvert.SerializeObject(command);
                var message = new Message(Encoding.UTF8.GetBytes(payload));
                _client.SendAsync(message);
            }
            catch (Exception exception)
            {
                // TODO: Log exception;
                throw;
            }
        }
    }
}