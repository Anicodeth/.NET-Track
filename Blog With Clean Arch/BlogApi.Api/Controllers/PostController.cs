using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogApi.Core.Entities;
using BlogApi.Core.UseCases;

namespace BlogApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly CreatePost _addPost;
        private readonly GetPost _getPost;
        private readonly GetPosts _getPosts;
        private readonly UpdatePost _updatePost;
        private readonly DeletePost _deletePost;

        public PostController(
            CreatePost addPost,
            GetPosts getPosts,
            GetPost getPost,
            UpdatePost updatePost,
            DeletePost deletePost
            )
        {
            _addPost = addPost;
            _getPosts = getPosts;
            _getPost = getPost;
            _updatePost = updatePost;
            _deletePost = deletePost;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddPost(Post post)
        {
            var status = await _addPost.ExecuteAsync(post);

            return Ok(status);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _getPosts.ExecuteAsync();

            return Ok(posts);
        }

        [HttpGet("Single/{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _getPost.ExecuteAsync(id);

            if (post == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(post);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var status = await _deletePost.ExecuteAsync(id);
            return Ok(status);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdatePost(int id, Post post)
        {
            var status = await _updatePost.ExecuteAsync(id, post);
            return Ok(status);
        }
    }
}
