using System.Threading.Tasks;
using UnitTesting.Models;

namespace UnitTesting.Service
{
    public interface IBlogService
    {
        Task<int> AddPost(AddPostDto postDto);
    }
}
