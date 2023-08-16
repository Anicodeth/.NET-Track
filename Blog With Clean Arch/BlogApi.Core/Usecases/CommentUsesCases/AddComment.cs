


using BlogApi.Core.Entities;

namespace BlogApi.Core.UseCases {

    public class AddComment{
        ICommentRepository _commentRepository;

        public AddComment(ICommentRepository commentRepository){
            _commentRepository = commentRepository;
        }

        public async Task<bool> ExecuteAsync(Comment comment ){

            return await _commentRepository.AddAsync(comment);

        }
    }


}