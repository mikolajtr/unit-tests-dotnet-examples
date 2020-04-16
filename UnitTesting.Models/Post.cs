namespace UnitTesting.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public Author Author { get; set; }
    }
}
