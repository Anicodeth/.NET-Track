
using Blog_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog_App.Data
{
    public class BlogDbContext:DbContext
    {
        public virtual DbSet<Blog> Blogs { get; set; }
        public BlogDbContext(DbContextOptions<BlogDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
