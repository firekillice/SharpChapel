using Chapel.Entity;
using Microsoft.EntityFrameworkCore;

namespace Chapel
{
    internal class ChapelContext : DbContext
    {
        public ChapelContext(DbContextOptions<ChapelContext> options) : base(options)
        {

        }

        public ChapelContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? connetionString = "server=10.10.50.72; port=3306; database=odyssey; user=root; password=123456; Connect Timeout=300";
            optionsBuilder.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
        }

        public DbSet<ContactEntity>? Contacts { get; set; }

        public DbSet<AuthorEntity>? Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ContactEntity>().ToTable("Contacts");
            builder.Entity<AuthorEntity>().ToTable("Authors");
        }
    }
}
