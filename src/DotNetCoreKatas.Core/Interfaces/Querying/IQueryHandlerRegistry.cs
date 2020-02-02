using System;

namespace DotNetCoreKatas.Core.Interfaces.Querying
{
    public interface IQueryHandlerRegistry
    {
        void Register<TQuery, THandler>() 
            where TQuery : IQuery
            where THandler : IQueryHandler;

        Type Resolve<TQuery>() where TQuery : IQuery;
    }
}