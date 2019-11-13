using DotNetCoreKatas.Core.Interfaces.Messaging;

namespace DotNetCoreKatas.Core
{
    public class ServiceBusOptions : IServiceBusOptions
    {
        public string ConnectionString { get; set; }

        public string QueueName { get; set; }
    }
}
