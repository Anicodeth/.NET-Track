using Blog_API.Models;
using Microsoft.AspNetCore.Mvc;
using Blog_API.Data;
using System.Collections.Generic;
using System.Linq;

namespace Blog_API.Controllers
{
    /// <summary>
    /// Controller for managing comments on blog posts.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly BlogDbContext _context;

        /// <summary>
        /// Constructor for the CommentsController.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CommentsController(BlogDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get a list of all comments.
        /// </summary>
        /// <returns>A list of comments.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Comment>> GetComments()
        {
            var comments = _context.Comments.ToList();
            return Ok(comments);
        }

        /// <summary>
        /// Get a specific comment by ID.
        /// </summary>
        /// <param name="id">The ID of the comment to retrieve.</param>
        /// <returns>The requested comment.</returns>
        [HttpGet("{id}")]
        public ActionResult<Comment> GetComment(int id)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.Id == id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        /// <summary>
        /// Create a new comment.
        /// </summary>
        /// <param name="comment">The comment to create.</param>
        /// <returns>The newly created comment.</returns>
        [HttpPost]
        public ActionResult<Comment> CreateComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment);
        }

        /// <summary>
        /// Update an existing comment.
        /// </summary>
        /// <param name="id">The ID of the comment to update.</param>
        /// <param name="updatedComment">The updated comment data.</param>
        /// <returns>No content response if successful.</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateComment(int id, Comment updatedComment)
        {
            var existingComment = _context.Comments.FirstOrDefault(c => c.Id == id);
            if (existingComment == null)
            {
                return NotFound();
            }

            existingComment.Text = updatedComment.Text;
            // Update other properties as needed

            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Delete a comment by ID.
        /// </summary>
        /// <param name="id">The ID of the comment to delete.</param>
        /// <returns>No content response if successful.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
