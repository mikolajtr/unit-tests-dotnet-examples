using Microsoft.EntityFrameworkCore;
using UnitTesting.Models;

namespace UnitTesting.DatabaseAccess
{
    public class BlogContext: DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Author> Authors { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Post>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.AuthorId);

            base.OnModelCreating(builder);
        }
    }
}
