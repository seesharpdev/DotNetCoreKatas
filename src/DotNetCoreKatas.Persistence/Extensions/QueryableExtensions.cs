using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DotNetCoreKatas.Persistence.Extensions
{
	/// <summary>
	/// Custom implementation of 'AsNoTracking' to facilitate testing of classes depending on <see cref="DbSet{TEntity}"/>
	/// </summary>
	public static class QueryableExtensions
	{
		// TODO: Trying to make this extension method asynchronous.
		//public static IQueryable<T> AsNoTrackingQueryable<T>(this IQueryable<T> source) where T : class
		public static async Task<IQueryable<T>> AsNoTrackingQueryable<T>(this IQueryable<T> source) where T : class
		{
			if (source.Provider is EntityQueryProvider)
			{
				//return source.AsNoTracking();
				return await Task.FromResult(source.AsNoTracking());
			}

			//return source;
			return await Task.FromResult(source);
		}
	}
}