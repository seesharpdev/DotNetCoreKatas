using DotNetCoreKatas.Core.Interfaces.Querying;
using DotNetCoreKatas.Query.Contracts.Models;

namespace DotNetCoreKatas.Query.Contracts.Adapters
{
	public interface IBooksQueryAdapter : IQueryAdapter<BookReadModel, int>
	{
	}
}