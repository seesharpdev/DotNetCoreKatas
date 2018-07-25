using System.Linq;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DotNetCoreKatas.Persistence.Extensions
{
	/// <summary>
	/// Custom implementation of 'AsNoTracking' to facilitate testing of classes depending on <see cref="DbSet{TEntity}"/>
	/// </summary>
	public static class QueryableExtensions
	{
		public static IQueryable<T> AsNoTrackingQueryable<T>(this IQueryable<T> source) where T : class
		{
			if (source.Provider is EntityQueryProvider)
			{
				return source.AsNoTracking();
			}

			return source;
		}
	}
}