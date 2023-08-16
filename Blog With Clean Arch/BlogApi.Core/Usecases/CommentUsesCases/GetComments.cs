using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApi.Core.Entities;
using BlogApi.Core.UseCases;

namespace BlogApi.Core.UseCases
{
     public class GetComments
    {

        ICommentRepository _commentRepository;

        public GetComments(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<Comment>> ExecuteAsync()
        {

            return await _commentRepository.GetCommentsAsync();

        }
    }
}
