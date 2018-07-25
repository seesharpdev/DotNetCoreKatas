namespace DotNetCoreKatas.Core.Interfaces.Querying
{
	/// <summary>
	/// Marker interface for a Domain Query.
	/// </summary>
	public interface IQuery<T> where T : class
	{
	}
}