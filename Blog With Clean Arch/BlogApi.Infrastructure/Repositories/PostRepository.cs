
using Microsoft.EntityFrameworkCore;
using BlogApi.Core.Entities;
using BlogApi.Core.UseCases;
using BlogApi.Infrastructure.Data;


namespace BlogApi.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogDatabaseContext _context;

        public PostRepository(BlogDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Post> CreateAsync(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetPostAsync(int id)
        {
            return await _context.Posts.FirstOrDefaultAsync(post => post.Id == id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(post => post.Id == id);

            if (post == null)
            {
                return false;
            }
            else
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Post> UpdateAsync(int id, Post post)
        {
            var existingPost = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);

            if (existingPost != null)
            {
                existingPost.Title = post.Title;
                existingPost.Content = post.Content;

                await _context.SaveChangesAsync();
            }

            return existingPost;
        }
    }
}
