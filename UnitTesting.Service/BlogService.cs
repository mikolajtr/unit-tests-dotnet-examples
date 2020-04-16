using System.Threading.Tasks;
using UnitTesting.Models;
using UnitTesting.Repositories;

namespace UnitTesting.Service
{
    public class BlogService : IBlogService
    {
        private readonly IBlogConverter _blogConverter;
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogConverter blogConverter, IBlogRepository blogRepository)
        {
            _blogConverter = blogConverter;
            _blogRepository = blogRepository;
        }

        public async Task<int> AddPost(AddPostDto postDto)
        {
            var post = _blogConverter.ConvertToPost(postDto);
            return await _blogRepository.Add(post);
        }
    }
}
