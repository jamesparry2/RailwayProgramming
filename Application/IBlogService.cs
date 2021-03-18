using RopExample.Models;
using RopExample.ROP;

namespace RopExample.Application
{
    public interface IBlogService
    {
        Result<Blog, string[]> GetBlog(string id);
        Result<Blog, string[]> InsertBlog(Blog blog);
    }
}
