using BlogApi.Core.Entities;


namespace BlogApi.Core.UseCases
{
    public class CreatePost
    {
        IPostRepository _postRepository;

        public CreatePost(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post> ExecuteAsync(Post post)
        {
            return await _postRepository.CreateAsync(post);
        }
    }
}