

using Microsoft.EntityFrameworkCore;
using Blog_API.Models;

namespace Blog_API.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        // Add other DbSet properties as needed
    }
}