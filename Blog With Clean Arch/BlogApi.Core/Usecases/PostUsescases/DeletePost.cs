
namespace BlogApi.Core.UseCases
{
    public class DeletePost
    {
        IPostRepository _postRepository;

        public DeletePost(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<bool> ExecuteAsync(int postId)
        {
            return await _postRepository.DeleteAsync(postId);
        }
    }
}
