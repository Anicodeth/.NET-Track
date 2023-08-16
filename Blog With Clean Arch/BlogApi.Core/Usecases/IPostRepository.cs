
using System.Threading.Tasks;
using BlogApi.Core.Entities;

namespace BlogApi.Core.UseCases {
    public interface IPostRepository {
        Task<Post> CreateAsync(Post post);
        Task<Post> UpdateAsync(int postId, Post post); 
        Task<bool> DeleteAsync(int postId);
        Task<List<Post>> GetPostsAsync();
        Task<Post> GetPostAsync(int postId);


    }
}