using Autofac;

using DotNetCoreKatas.Command.Adapter.Contracts;
using DotNetCoreKatas.Command.Contracts.Infrastructure;

namespace DotNetCoreKatas.Command.Adapter.Infrastructure
{
	public class CommandAdapterModule : Module
    {
	    protected override void Load(ContainerBuilder builder)
	    {
		    builder.RegisterModule<CommandContractsModule>();

			RegisterCommandAdapter(builder);
	    }

	    private static void RegisterCommandAdapter(ContainerBuilder builder)
        {
            // TODO: Requires Azure Service Bus Connection String and Queue Name
            //builder.RegisterType<QueueClient>()
            //    .As<IQueueClient>();

		    builder.RegisterType<AzureServiceBusCommandAdapter>()
			    .As<IAzureServiceBusCommandAdapter>();
	    }
    }
}
