using Microsoft.EntityFrameworkCore;

using DotNetCoreKatas.Domain.Models;

namespace DotNetCoreKatas.Persistence
{
	public interface IDotNetCoreKatasDbContext
	{
		DbSet<BookDomainModel> Books { get; set; }
	}

	public class DotNetCoreKatasDbContext : DbContext, IDotNetCoreKatasDbContext
	{
		public virtual DbSet<BookDomainModel> Books { get; set; }

	    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	    {
		    optionsBuilder.UseSqlite("Data Source=blogging.db");
		}

	    protected override void OnModelCreating(ModelBuilder modelBuilder)
	    {
			// Define Composite Keyes:
		    //modelBuilder.Entity<BookDomainModel>()
			   // .HasKey(b => new { b.Id });
		}
    }
}