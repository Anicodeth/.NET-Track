using System;
using System.Threading.Tasks;
using BlogApi.Core.UseCases;
using BlogApi.Core.Entities;

namespace BlogApi.Core.UseCases
{
    public class UpdatePost
    {
        IPostRepository _postRepository;

        public UpdatePost(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post> ExecuteAsync(int postId, Post post)
        {

            return await _postRepository.UpdateAsync( postId,  post);

        }
    }
}
