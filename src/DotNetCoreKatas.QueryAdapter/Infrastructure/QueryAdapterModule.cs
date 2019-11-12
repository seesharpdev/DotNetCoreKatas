using System.Collections.Generic;

using Autofac;

using DotNetCoreKatas.Core.Interfaces.Querying;
using DotNetCoreKatas.Query.Adapter.Adapters;
using DotNetCoreKatas.Query.Adapter.Handlers;
using DotNetCoreKatas.Query.Contracts.Infrastructure;
using DotNetCoreKatas.Query.Contracts.Models;
using DotNetCoreKatas.Query.Contracts.Queries;

namespace DotNetCoreKatas.Query.Adapter.Infrastructure
{
	public class QueryAdapterModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterModule<QueryContractsModule>();

			// TODO: RegisterModule's for dependencies: IDotNetCoreKatasDbContext and IModelMapper<BookDomainModel, BookReadModel>

            builder.RegisterType<QueryProcessor>()
                .As<IQueryProcessor>();

			RegisterAdapters(builder);
			RegisterHandlers(builder);
			RegisterMappers(builder);
		}

		private static void RegisterAdapters(ContainerBuilder builder)
		{
			builder.RegisterType<BooksQueryAdapter>()
				.As<IQueryAdapter<BookReadModel, int>>();
		}

		private static void RegisterHandlers(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(typeof(QueryAdapterModule).Assembly)
				.Where(t => t.Name.EndsWith("Handler"))
				.AsImplementedInterfaces();

			//builder.RegisterType<AllBooksQueryHandler>()
			//	.As<IQueryHandler<AllBooksQuery, IEnumerable<BookReadModel>>>();

            // TODO: builder.RegisterType<FindBookByIdQuery>()
            //    .As<IFindBookByIdQuery>();
        }

		private static void RegisterMappers(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(typeof(QueryAdapterModule).Assembly)
				.Where(t => t.Name.EndsWith("Mapper"))
				.AsImplementedInterfaces();
		}
	}
}
