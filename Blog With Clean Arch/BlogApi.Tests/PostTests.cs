using System.Threading.Tasks;
using BlogApi.Core.Entities;
using BlogApi.Core.UseCases;
using BlogApi.Infrastructure.Data;
using BlogApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace BlogApi.Tests
{

namespace BlogApi.Tests
    {
        public class PostRepositoryTests
        {
            [Fact]
            public async void CreateAsync_ShouldAddPostToDbContext()
            {
                var mockContext = new Mock<BlogDatabaseContext>();
                var mockDbSet = new Mock<DbSet<Post>>();

                mockContext.Setup(context => context.Posts).Returns(mockDbSet.Object);
                mockContext.Setup(context => context.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1); // Return a completed task with any appropriate result

                IPostRepository repository = new PostRepository(mockContext.Object);

                var postToAdd = new Post { Id = 1, Title = "Test Post", Content = "Test Content" };

                // Act
                await repository.CreateAsync(postToAdd);

                // Assert
                mockDbSet.Verify(dbSet => dbSet.Add(It.IsAny<Post>()), Times.Once);
                mockContext.Verify(context => context.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
            }

        }

    }
}
