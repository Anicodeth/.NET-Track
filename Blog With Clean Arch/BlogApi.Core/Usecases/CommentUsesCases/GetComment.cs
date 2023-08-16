using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApi.Core.UseCases;
using BlogApi.Core.Entities;

namespace BlogApi.Core.UseCases
{
     public class GetComment
    {

        ICommentRepository _commentRepository;

        public GetComment(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Comment> ExecuteAsync(int id)
        {

            return await _commentRepository.GetCommentAsync(id);

        }
    }
}
