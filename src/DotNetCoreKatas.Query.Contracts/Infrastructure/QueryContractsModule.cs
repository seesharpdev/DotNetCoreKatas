using Autofac;

namespace DotNetCoreKatas.Query.Contracts.Infrastructure
{
	public class QueryContractsModule : Module
    {
	    protected override void Load(ContainerBuilder builder)
	    {
		    builder.RegisterAssemblyTypes(typeof(QueryContractsModule).Assembly)
			    .Where(t => t.Name.EndsWith("Query"))
			    .AsImplementedInterfaces();
	    }
    }
}
