using Microsoft.EntityFrameworkCore;

using DotNetCoreKatas.Domain.Models;

namespace DotNetCoreKatas.Persistence
{
	public class DotNetCoreKatasDbContext : DbContext, IDotNetCoreKatasDbContext
	{
        // TODO: Introduce DbContextFactory
        public DotNetCoreKatasDbContext()
        {
            Database.EnsureCreated();
        }

		public virtual DbSet<BookDomainModel> Books { get; set; }

		public override int SaveChanges()
		{
			return base.SaveChanges();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	    {
		    optionsBuilder.UseSqlite("Data Source=blogging.db");
		}

	    protected override void OnModelCreating(ModelBuilder modelBuilder)
	    {
			// TODO: Apply Class Maps

			// Define (Composite) Keyes
            modelBuilder.Entity<BookDomainModel>()
                .ToTable("Books") // <-- the argument could be just "Files"
                .HasKey(b => b.Id);

            //modelBuilder.Entity<BookDomainModel>()
            // .Property(b => b.Id)
            // .HasField("_id")
            // .UsePropertyAccessMode(PropertyAccessMode.Field);

            // TODO Delete?
            //modelBuilder.Entity<BookDomainModel>()
            //    .HasOne(m => m.Title);

            //modelBuilder.Entity<BookDomainModel>()
            //    .HasOne(m => m.Isbn);
        }
    }
}