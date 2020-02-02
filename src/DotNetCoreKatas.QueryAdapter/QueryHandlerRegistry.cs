using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

using DotNetCoreKatas.Core.Interfaces.Querying;

namespace DotNetCoreKatas.Query.Adapter
{
    public class QueryHandlerRegistry : IQueryHandlerRegistry
    {
        private IDictionary<Type, Type> _registry = new ConcurrentDictionary<Type, Type>();

        public void Register<TQuery, THandler>() 
            where TQuery : IQuery
            where THandler : IQueryHandler
        {
            _registry.Add(typeof(TQuery), typeof(THandler));
        }

        public Type Resolve<T>() where T : IQuery
        {
            var handler = _registry[typeof(T)];

            return handler;
        }
    }
}