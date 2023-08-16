using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApi.Core.Entities;
using BlogApi.Core.UseCases;

namespace BlogApi.Core.UseCases
{
    public class UpdateComment
    {

        ICommentRepository _commentRepository;

        public UpdateComment(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Comment> ExecuteAsync(int id, Comment comment)
        {

            return await _commentRepository.UpdateAsync(id, comment);

        }
    }
}
