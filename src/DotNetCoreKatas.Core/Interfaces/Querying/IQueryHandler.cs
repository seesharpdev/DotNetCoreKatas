using System.Threading.Tasks;

namespace DotNetCoreKatas.Core.Interfaces.Querying
{
	public interface IQueryHandler<T> where T : class
	{
		Task<T> Handle(IQuery<T> query);
	}
}