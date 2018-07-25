namespace DotNetCoreKatas.Command.Contracts
{
	public class CreateBookCommand : ICreateBookCommand
	{
		public int Id { get; set; }
	}
}