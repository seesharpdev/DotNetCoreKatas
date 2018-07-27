using Autofac;

namespace DotNetCoreKatas.Command.Contracts.Infrastructure
{
	public class CommandContractsModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(typeof(CommandContractsModule).Assembly)
				.Where(t => t.Name.EndsWith("Command"))
				.AsImplementedInterfaces();
		}
	}
}