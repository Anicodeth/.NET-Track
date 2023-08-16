
using System.Threading.Tasks;
using BlogApi.Core.Entities;

namespace BlogApi.Core.UseCases {
    public interface ICommentRepository {
        Task<bool> AddAsync(Comment comment);
        Task<Comment> GetCommentAsync(int id);
        Task<List<Comment>> GetCommentsAsync();
        Task<bool> DeleteAsync(int id);
        Task<Comment> UpdateAsync(int id, Comment comment);
    }
}