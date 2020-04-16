using Moq;
using System.Threading.Tasks;
using UnitTesting.Models;
using UnitTesting.Repositories;
using UnitTesting.Service;
using Xunit;

namespace UnitTesting
{
    public class BlogServiceTests
    {
        [Fact]
        public async Task ShouldAddPost()
        {
            var converterMock = new Mock<IBlogConverter>();
            converterMock
                .Setup(x => x.ConvertToPost(It.IsAny<AddPostDto>()))
                .Returns(new Post());

            var repositoryMock = new Mock<IBlogRepository>();
            repositoryMock
                .Setup(x => x.Add(It.IsAny<Post>()))
                .ReturnsAsync(1);


            var service = new BlogService(converterMock.Object, repositoryMock.Object);
            var id = await service.AddPost(new AddPostDto());

            Assert.Equal(1, id);
        }

        [Fact]
        public async Task ShouldAddThreePosts()
        {
            var converterMock = new Mock<IBlogConverter>();
            converterMock
                .Setup(x => x.ConvertToPost(It.IsAny<AddPostDto>()))
                .Returns(new Post());

            var repositoryMock = new Mock<IBlogRepository>();
            repositoryMock
                .Setup(x => x.Add(It.IsAny<Post>()))
                .ReturnsAsync(1);


            var service = new BlogService(converterMock.Object, repositoryMock.Object);
            await service.AddPost(new AddPostDto());
            await service.AddPost(new AddPostDto());
            await service.AddPost(new AddPostDto());

            converterMock.Verify(x => x.ConvertToPost(It.IsAny<AddPostDto>()), Times.Exactly(3));
            repositoryMock.Verify(x => x.Add(It.IsAny<Post>()), Times.Exactly(3));
        }
    }
}
