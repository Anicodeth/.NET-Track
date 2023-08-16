using BlogApi.Core.UseCases;
using BlogApi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Infrastructure.Data {

    public class BlogDatabaseContext : DbContext, IBlogDatabaseContext{

     public DbSet<Post> Posts { get; set;}
     public DbSet<Comment> Comments {get; set; }

     public BlogDatabaseContext(DbContextOptions<BlogDatabaseContext> options) : base(options){
     }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public async Task<int> SaveChangesAsync()


        {

                return await base.SaveChangesAsync();

   

        }
    }
}

