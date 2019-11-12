using System.Diagnostics;

using Autofac;
using Autofac.Core.Registration;
using DotNetCoreKatas.Core.Interfaces.Querying;

namespace DotNetCoreKatas.Query.Adapter
{
	public class QueryProcessor : IQueryProcessor
	{
        // Replace this with a QueryRegistry!
        private readonly ILifetimeScope _scope;

        public QueryProcessor(ILifetimeScope scope)
		{
            _scope = scope;
        }

		//[DebuggerStepThrough]
		public TResult Process<TResult>(IQuery<TResult> query)
		{
			var handlerType = typeof(IQueryHandler<,>)
				.MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = _scope.Resolve(handlerType);

            return handler.Handle((dynamic)query);
		}
	}
}