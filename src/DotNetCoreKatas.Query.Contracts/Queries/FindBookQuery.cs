using System;

using DotNetCoreKatas.Core.Interfaces.Querying;
using DotNetCoreKatas.Query.Contracts.Models;

namespace DotNetCoreKatas.Query.Contracts.Queries
{
	public class FindBookQuery : IQuery<BookReadModel>
	{
		public Predicate<BookReadModel> Predicate { get; set; }
	}
}