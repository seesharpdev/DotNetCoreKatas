namespace DotNetCoreKatas.Core.Interfaces.Querying
{
	public interface IQueryHandlerRegistry
	{
		// TODO: Passing object for now!
		void Register(object handler);
	}
}