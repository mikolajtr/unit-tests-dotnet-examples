using System.Threading.Tasks;
using UnitTesting.DatabaseAccess;
using UnitTesting.Models;

namespace UnitTesting.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogContext _blogContext;

        public BlogRepository(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<int> Add(Post post)
        {
             _blogContext.Add(post);
            await _blogContext.SaveChangesAsync();
            return post.Id;
        }
    }
}
