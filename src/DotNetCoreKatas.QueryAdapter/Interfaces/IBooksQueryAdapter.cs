using DotNetCoreKatas.QueryAdapter.Contracts;

namespace DotNetCoreKatas.QueryAdapter.Interfaces
{
	public interface IBooksQueryAdapter : IQueryAdapter<BookReadModel, int>
	{
	}
}