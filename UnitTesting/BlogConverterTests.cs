using FluentAssertions;
using System;
using UnitTesting.Models;
using UnitTesting.Service;
using Xunit;

namespace UnitTesting
{
    public class BlogConverterTests
    {
        [Fact]
        public void ShouldConvertPost()
        {
            var expectedPost = new Post
            {
                AuthorId = 69,
                Text = "aaaaa",
                Title = "bbbbb"
            };

            var converter = new BlogConverter();
            var actualPost = converter.ConvertToPost(new Models.AddPostDto
            {
                AuthorId = 69,
                Text = "aaaaa",
                Title = "bbbbb"
            });

            expectedPost.Should().BeEquivalentTo(actualPost);
        }

        [Fact]
        public void ShouldNotConvertNull()
        {
            var converter = new BlogConverter();
            Action conversion = () => converter.ConvertToPost(null);
            conversion.Should().Throw<ArgumentNullException>();
        }
    }
}
