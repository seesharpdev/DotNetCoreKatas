namespace DotNetCoreKatas.Command.Adapter.Contracts
{
	public class DeleteBookCommand : IDeleteBookCommand
	{
		public int Id { get; set; }
	}
}