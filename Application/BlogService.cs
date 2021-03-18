using RopExample.IDataLayer;
using RopExample.Models;
using RopExample.ROP;
using RopExample.Validators

namespace RopExample.Application
{
    public class BlogService : IBlogService
    {
        private readonly IDatabaseLayer _databaseLayer;

        public BlogService(IDatabaseLayer databaseLayer)
        {
            _databaseLayer = databaseLayer;
        }

        public Result<Blog, string[]> GetBlog(string id)
        {
            return _databaseLayer
                    .GetRop<Blog>(id)
                    .Map(BaseModdifyBlog);
        }

        public Result<Blog, string[]> InsertBlog(Blog blog)
        {
            return Result<Blog, string[]>
                    .Succeeded(blog)
                    .Bind(BlogValidator.ValidateBlog)
                    .Bind(_databaseLayer.InsertRop)
                    .Map(x => new Blog { Name = "This has worked" });
        }

        private Blog BaseModdifyBlog(Blog blog)
        {
            return new Blog
            {
                Id = blog.Id,
                Description = blog.Description,
                Name = blog.Name,
                SerialNumber = blog.SerialNumber,
                Author = new Author
                {
                    Name = blog.Author.Name + "Modified"
                }
            };
        }
    }
}
