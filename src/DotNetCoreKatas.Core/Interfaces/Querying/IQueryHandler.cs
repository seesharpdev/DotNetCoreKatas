namespace DotNetCoreKatas.Core.Interfaces.Querying
{
    /// <summary>
    /// Marker interface for a Query Handler.
    /// </summary>
    public interface IQueryHandler
    {
    }

    // TODO: To make it easier one could make the IQueryHandler always return a collection of results
    // thus making redudant the TReadModel and TResult type arguments
    public interface IQueryHandler<in TQuery, out TResult> : IQueryHandler
        where TQuery : IQuery
    {
        TResult Handle(TQuery query);
    }

    public interface IQueryHandler<in TQuery, in TReadModel, out TResult> : IQueryHandler
        where TQuery : IQuery<TReadModel, TResult>
        where TReadModel : IReadModel
	{
		TResult Handle(TQuery query);
	}
}