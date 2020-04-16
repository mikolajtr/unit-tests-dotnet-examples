using System.Threading.Tasks;
using UnitTesting.Models;

namespace UnitTesting.Repositories
{
    public interface IBlogRepository
    {
        Task<int> Add(Post post);
    }
}
