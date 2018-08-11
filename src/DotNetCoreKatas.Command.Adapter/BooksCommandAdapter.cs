using System.Threading.Tasks;

using DotNetCoreKatas.Core.Interfaces.Commanding;

namespace DotNetCoreKatas.Command.Adapter
{
	internal class BooksCommandAdapter : ICommandAdapter
	{
		public Task Execute(ICommand command)
		{
			throw new System.NotImplementedException();
		}
	}
}