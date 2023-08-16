
using System.Threading.Tasks;
using BlogApi.Core.UseCases;
using BlogApi.Core.Entities;

namespace BlogApi.Core.UseCases
{
     public class GetPost
    {
        IPostRepository _postRepository;

        public GetPost(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post> ExecuteAsync(int postId)
        {
            return await _postRepository.GetPostAsync(postId);
        }
    }
}
