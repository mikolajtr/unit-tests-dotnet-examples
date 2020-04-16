using UnitTesting.Models;

namespace UnitTesting.Service
{
    public interface IBlogConverter
    {
        Post ConvertToPost(AddPostDto dto);
    }
}