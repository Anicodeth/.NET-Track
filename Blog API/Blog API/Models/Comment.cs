namespace Blog_API.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int BlogPostId { get; set; }
        public string Text { get; set; }
    }
}
