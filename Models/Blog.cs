namespace RopExample.Models
{
    public class Blog
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long SerialNumber { get; set; }
        public Author Author { get; set; }
    }

    public class Author
    {
        public string Name { get; set; }
    }
}
