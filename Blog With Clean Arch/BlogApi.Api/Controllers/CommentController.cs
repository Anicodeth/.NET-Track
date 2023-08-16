// BlogApi.Api/Controllers/CommentController.cs
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogApi.Core.Entities;
using BlogApi.Core.UseCases;

namespace BlogApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly AddComment _addComment;
        private readonly GetComment _getComment;
        private readonly GetComments _getComments;
        private readonly UpdateComment _updateComment;
        private readonly DeleteComment _deleteComment;



        public CommentController(
            AddComment addComment,
            GetComments getComments,
            GetComment getComment,
            UpdateComment updateComment,
            DeleteComment deleteComment
            )
        {
            _addComment = addComment;
            _getComment = getComment;
            _updateComment = updateComment;
            _deleteComment = deleteComment;
            _getComments = getComments;

        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            bool status = await _addComment.ExecuteAsync(comment);

            return Ok(status);
        }


        [HttpGet("All")]
        public async Task<IActionResult> GetComments()
        {
            var Comments = await _getComments.ExecuteAsync();

            return Ok(Comments);
        }

        [HttpGet("Single/{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var comment = await _getComment.ExecuteAsync(id);

            if (comment == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(comment);
            }

        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var status = await _deleteComment.ExecuteAsync(id);
            return Ok(status);
        }

        [HttpPut("Update")] 
        public async Task<IActionResult> UpdateComment(int id, Comment comment)
        {
            var status = await _updateComment.ExecuteAsync(id, comment);
            return Ok(status);
        }

    }
}
