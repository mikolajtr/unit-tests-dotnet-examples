using System;
using UnitTesting.Models;

namespace UnitTesting.Service
{
    public class BlogConverter : IBlogConverter
    {
        public Post ConvertToPost(AddPostDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new Post
            {
                AuthorId = dto.AuthorId,
                Title = dto.Title,
                Text = dto.Text
            };
        }
    }
}
