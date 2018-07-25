namespace DotNetCoreKatas.Core.Interfaces
{
	public interface IModelMapper<in TSource, out TTarget>
	{
		TTarget Map(TSource source);
	}
}