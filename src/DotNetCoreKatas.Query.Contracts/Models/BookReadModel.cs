using System.ComponentModel.DataAnnotations;
using DotNetCoreKatas.Core.Interfaces.Querying;

namespace DotNetCoreKatas.Query.Contracts.Models
{
	public class BookReadModel : IReadModel
	{
		[Required]
		public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Isbn { get; set; }
	}
}