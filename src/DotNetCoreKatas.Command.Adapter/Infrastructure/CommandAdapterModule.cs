using Autofac;

using DotNetCoreKatas.Command.Contracts.Infrastructure;

namespace DotNetCoreKatas.Command.Adapter.Infrastructure
{
	public class CommandAdapterModule : Module
    {
	    protected override void Load(ContainerBuilder builder)
	    {
		    builder.RegisterModule<CommandContractsModule>();

			RegisterCommandAdapter(builder);
			// TODO: Register Handlers
			// TODO: Register Mappers
	    }

	    private static void RegisterCommandAdapter(ContainerBuilder builder)
	    {
		    builder.RegisterType<AzureServiceBusCommandAdapter>()
			    .AsImplementedInterfaces();
	    }
    }
}
