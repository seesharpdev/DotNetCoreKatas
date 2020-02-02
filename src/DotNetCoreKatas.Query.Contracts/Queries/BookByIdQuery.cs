using DotNetCoreKatas.Core.Interfaces.Querying;
using DotNetCoreKatas.Query.Contracts.Models;

namespace DotNetCoreKatas.Query.Contracts.Queries
{
	public class BookByIdQuery : IQuery<BookReadModel, BookReadModel>
	{
		public int Id { get; set; }
	}
}
