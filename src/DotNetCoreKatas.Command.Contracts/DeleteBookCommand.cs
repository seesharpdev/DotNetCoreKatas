namespace DotNetCoreKatas.Command.Contracts
{
	public class DeleteBookCommand : IDeleteBookCommand
	{
		public int Id { get; set; }
	}
}