using System.Diagnostics;

using Autofac;

using DotNetCoreKatas.Core.Interfaces.Querying;

namespace DotNetCoreKatas.Query.Adapter
{
	public class QueryProcessor : IQueryProcessor
	{
        // Replace this with a QueryRegistry!
		private readonly IContainer _container;

		public QueryProcessor(IContainer container)
		{
			_container = container;
		}

		[DebuggerStepThrough]
		public TResult Process<TResult>(IQuery<TResult> query)
		{
			var handlerType = typeof(IQueryHandler<,>)
				.MakeGenericType(query.GetType(), typeof(TResult));

			dynamic handler = _container.Resolve(handlerType);

			return handler.Handle((dynamic)query);
		}
	}
}