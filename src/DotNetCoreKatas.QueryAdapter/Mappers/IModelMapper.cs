namespace DotNetCoreKatas.QueryAdapter.Mappers
{
	public interface IModelMapper<in TSource, out TTarget>
	{
		TTarget Map(TSource source);
	}
}