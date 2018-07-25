namespace DotNetCoreKatas.Command.Contracts
{
	public class UpdateBookCommand : IUpdateBookCommand
	{
		public int Id { get; set; }
	}
}