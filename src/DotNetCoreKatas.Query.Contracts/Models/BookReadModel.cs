using System.ComponentModel.DataAnnotations;

namespace DotNetCoreKatas.Query.Contracts.Models
{
	public class BookReadModel
	{
		[Required]
		public int Id { get; set; }
	}
}