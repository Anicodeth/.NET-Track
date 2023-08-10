using System;
using System.Collections.Generic;
using System.Linq;
using Blog_API.Controllers;
using Blog_API.Data;
using Blog_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Blog_API.Tests
{
    public class BlogPostsControllerTests
    {
        [Fact]
        public void GetBlogPosts_ReturnsListOfBlogPosts()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new BlogDbContext(options))
            {
                context.BlogPosts.AddRange(new List<BlogPost>
                {
                    new BlogPost { Id = 1, Title = "Post 1", Content = "Content 1" },
                    new BlogPost { Id = 2, Title = "Post 2", Content = "Content 2" }
                });
                context.SaveChanges();

                var controller = new BlogPostsController(context);

                // Act
                var result = controller.GetBlogPosts();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result.Result);
                var blogPosts = Assert.IsType<List<BlogPost>>(okResult.Value);
                Assert.Equal(2, blogPosts.Count);
            }
        }

 
        // Similar tests for other methods (GetBlogPost, CreateBlogPost)
    }
}
