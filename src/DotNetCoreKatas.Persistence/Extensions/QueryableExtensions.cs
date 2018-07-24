using System.Linq;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DotNetCoreKatas.Persistence.Extensions
{
	public static class QueryableExtensions
	{
		public static IQueryable<T> GatedAsNoTracking<T>(this IQueryable<T> source) where T : class
		{
			if (source.Provider is EntityQueryProvider)
			{
				return source.AsNoTracking();
			}

			return source;
		}
	}
}