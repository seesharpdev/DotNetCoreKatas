using Microsoft.EntityFrameworkCore;

using DotNetCoreKatas.Domain.Models;

namespace DotNetCoreKatas.Persistence
{
	public interface IDotNetCoreKatasDbContext
	{
		DbSet<BookDomainModel> Books { get; set; }
	}
}