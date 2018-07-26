using System.Collections.Generic;

using DotNetCoreKatas.Core.Interfaces.Querying;
using DotNetCoreKatas.Query.Contracts.Models;

namespace DotNetCoreKatas.Query.Contracts.Queries
{
	public class GetAllBooksQuery : IQuery<IEnumerable<BookReadModel>>
	{
	}
}