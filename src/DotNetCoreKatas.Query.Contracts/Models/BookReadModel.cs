using System.ComponentModel.DataAnnotations;

namespace DotNetCoreKatas.Query.Contracts.Models
{
	public class BookReadModel
	{
		[Required]
		public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Isbn { get; set; }
	}
}