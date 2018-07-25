using Microsoft.EntityFrameworkCore;

using DotNetCoreKatas.Domain.Models;

namespace DotNetCoreKatas.Persistence
{
	// TODO: Introduce DbContextFactory
	public class DotNetCoreKatasDbContext : DbContext, IDotNetCoreKatasDbContext
	{
		public virtual DbSet<BookDomainModel> Books { get; set; }

	    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	    {
		    optionsBuilder.UseSqlite("Data Source=blogging.db");
		}

	    protected override void OnModelCreating(ModelBuilder modelBuilder)
	    {
			// TODO: Apply Class Maps

			// Define (Composite) Keyes
			modelBuilder.Entity<BookDomainModel>()
				.HasKey(b => b.Id);
			
		    modelBuilder.Entity<BookDomainModel>()
			    .Property(b => b.Id)
			    .HasField("_id")
			    .UsePropertyAccessMode(PropertyAccessMode.Field);
		}
    }
}