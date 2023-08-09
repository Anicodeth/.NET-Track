using Blog_API.Data;
using Blog_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Blog_API.Controllers
{
    /// <summary>
    /// Controller for managing blog posts.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly BlogDbContext _context;

        /// <summary>
        /// Constructor for the BlogPostsController.
        /// </summary>
        /// <param name="context">The database context.</param>
        public BlogPostsController(BlogDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get a list of all blog posts.
        /// </summary>
        /// <returns>A list of blog posts.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<BlogPost>> GetBlogPosts()
        {
            var blogPosts = _context.BlogPosts.ToList();
            return Ok(blogPosts);
        }

        /// <summary>
        /// Get a specific blog post by ID.
        /// </summary>
        /// <param name="id">The ID of the blog post to retrieve.</param>
        /// <returns>The requested blog post.</returns>
        [HttpGet("{id}")]
        public ActionResult<BlogPost> GetBlogPost(int id)
        {
            var blogPost = _context.BlogPosts.FirstOrDefault(bp => bp.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }
            return Ok(blogPost);
        }

        /// <summary>
        /// Create a new blog post.
        /// </summary>
        /// <param name="blogPost">The blog post to create.</param>
        /// <returns>The newly created blog post.</returns>
        [HttpPost]
        public ActionResult<BlogPost> CreateBlogPost(BlogPost blogPost)
        {
            _context.BlogPosts.Add(blogPost);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetBlogPost), new { id = blogPost.Id }, blogPost);
        }

        /// <summary>
        /// Update an existing blog post.
        /// </summary>
        /// <param name="id">The ID of the blog post to update.</param>
        /// <param name="updatedBlogPost">The updated blog post data.</param>
        /// <returns>No content response if successful.</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateBlogPost(int id, BlogPost updatedBlogPost)
        {
            var existingPost = _context.BlogPosts.FirstOrDefault(bp => bp.Id == id);
            if (existingPost == null)
            {
                return NotFound();
            }

            existingPost.Title = updatedBlogPost.Title;
            existingPost.Content = updatedBlogPost.Content;
            // Update other properties as needed

            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Delete a blog post by ID.
        /// </summary>
        /// <param name="id">The ID of the blog post to delete.</param>
        /// <returns>No content response if successful.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteBlogPost(int id)
        {
            var blogPost = _context.BlogPosts.FirstOrDefault(bp => bp.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            _context.BlogPosts.Remove(blogPost);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
