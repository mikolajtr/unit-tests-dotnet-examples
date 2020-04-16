using System.Threading.Tasks;
using UnitTesting.DatabaseAccess;
using UnitTesting.Models;
using UnitTesting.Repositories;
using Xunit;

namespace UnitTesting
{
    public class BlogRepositoryTests : InMemoryDatabaseTestFixture
    {
        [Fact]
        public async Task ShouldAddPostToDatabase()
        {
            var context = new BlogContext(DbOptions);
            var repository = new BlogRepository(context);

            var post = new Post
            {
                Id = 1,
                AuthorId = 1,
                Text = "Sample text",
                Title = "Hello"
            };

            var postId = await repository.Add(post);

            Assert.Equal(1, postId);
        }
    }
}
