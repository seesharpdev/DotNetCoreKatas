namespace DotNetCoreKatas.Core.Interfaces.Messaging
{
    public interface IServiceBusOptions
    {
        string QueueName { get; set; }

        string ConnectionString { get; set; }
    }
}