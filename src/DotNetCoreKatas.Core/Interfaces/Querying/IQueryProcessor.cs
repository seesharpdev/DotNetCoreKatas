namespace DotNetCoreKatas.Core.Interfaces.Querying
{
	public interface IQueryProcessor
	{
        TResult Process<TReadModel, TResult>(IQuery<TReadModel, TResult> query) 
            where TReadModel : IReadModel;
	}
}