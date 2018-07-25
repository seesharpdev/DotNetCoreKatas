namespace DotNetCoreKatas.Core.Interfaces.Querying
{
	public interface IQueryHandler<in TQuery, out TResult> where TQuery : IQuery<TResult>
	{
		TResult Handle(TQuery query);
	}
}