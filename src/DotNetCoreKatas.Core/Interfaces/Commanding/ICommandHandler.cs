using System.Threading.Tasks;

namespace DotNetCoreKatas.Core.Interfaces.Commanding
{
	public interface ICommandHandler<in T> where T : ICommand
	{
		Task Execute(T command);
	}
}