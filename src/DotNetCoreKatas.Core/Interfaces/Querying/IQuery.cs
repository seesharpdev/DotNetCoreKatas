namespace DotNetCoreKatas.Core.Interfaces.Querying
{
    /// <summary>
    /// Marker interface for a Domain Query.
    /// </summary>
    public interface IQuery
    {
    }

    /// <summary>
    /// Marker interface for a Domain Query.
    /// </summary>
    public interface IQuery<TReadModel> : IQuery
        where TReadModel : IReadModel
    {
    }

    /// <summary>
    /// Marker interface for a Domain Query.
    /// </summary>s
    public interface IQuery<TReadModel, TReturn> : IQuery<TReadModel>
        where TReadModel : IReadModel
    {
    }
}