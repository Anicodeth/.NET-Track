


using BlogApi.Core.Entities;

namespace BlogApi.Core.UseCases
{

    public class DeleteComment
    {
        ICommentRepository _commentRepository;

        public DeleteComment(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<bool> ExecuteAsync(int id)
        {

            return await _commentRepository.DeleteAsync(id);

        }
    }


}