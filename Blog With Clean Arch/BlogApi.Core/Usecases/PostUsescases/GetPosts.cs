using System.Threading.Tasks;
using BlogApi.Core.Entities;
using BlogApi.Core.UseCases;

namespace BlogApi.Core.UseCases
{
    public  class GetPosts
    {
        IPostRepository _postRepository;

        public GetPosts(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<List<Post>> ExecuteAsync()
        {
            return await _postRepository.GetPostsAsync();
        }

    }
}
