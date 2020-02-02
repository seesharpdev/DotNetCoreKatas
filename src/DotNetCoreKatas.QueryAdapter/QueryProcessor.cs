//using System.Diagnostics;

using Autofac;
//using Autofac.Core.Registration;
using DotNetCoreKatas.Core.Interfaces.Querying;

namespace DotNetCoreKatas.Query.Adapter
{
	public class QueryProcessor : IQueryProcessor
	{
        // TODO: Replace this with a QueryHandlerRegistry
        private readonly ILifetimeScope _scope;

        public QueryProcessor(ILifetimeScope scope)
		{
            _scope = scope;
        }

        //[DebuggerStepThrough]
        public TResult Process<TReadModel, TResult>(IQuery<TReadModel, TResult> query)
            where TReadModel : IReadModel
		{
			var handlerType = typeof(IQueryHandler<,,>)
				//.MakeGenericType(query.GetType(), typeof(TResult));
				.MakeGenericType(query.GetType(), typeof(TReadModel), typeof(TResult));

            dynamic handler = _scope.Resolve(handlerType);

            return handler.Handle((dynamic)query);
		}
	}
}