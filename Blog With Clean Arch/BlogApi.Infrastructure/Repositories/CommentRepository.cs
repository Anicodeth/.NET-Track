
using BlogApi.Core.Entities;
using BlogApi.Core.UseCases;
using BlogApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace BlogApi.Infrastructure.Repositories{
    public class CommentRepository: ICommentRepository{

        private readonly BlogDatabaseContext _context;

        public CommentRepository(BlogDatabaseContext context){
            _context = context;
        }
        
        public async Task<bool> AddAsync(Comment comment){
           
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Comment>> GetCommentsAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment> GetCommentAsync(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(comment => comment.PostId == id);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var post = await _context.Comments.FirstOrDefaultAsync(comment => comment.Id == id);

            if (post == null)
            {
                return false;
            }
            else
            {
                _context.Comments.Remove(post);
               await _context.SaveChangesAsync();
                return true;
            }

        }

        public async Task<Comment> UpdateAsync(int id, Comment comment)
        {
            var p = await  _context.Comments.FirstOrDefaultAsync(comment => comment.Id == id);

            p.Text = comment.Text;

            await _context.SaveChangesAsync();

            return p;


        }

    }
}