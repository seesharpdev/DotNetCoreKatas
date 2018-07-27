namespace DotNetCoreKatas.Core.Interfaces.Querying
{
	public interface IQueryProcessor
	{
		TResult Process<TResult>(IQuery<TResult> query);
	}
}