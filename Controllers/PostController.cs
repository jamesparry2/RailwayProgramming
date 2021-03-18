using Microsoft.AspNetCore.Mvc;
using RopExample.Application;
using RopExample.Models;
using RopExample.ROP;

namespace RopExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController
    {
        private readonly IBlogService _blogService;
        private readonly IPostService _postService;

        public PostController(IBlogService blogService, IPostService postService)
        {
            _blogService = blogService;
            _postService = postService;
        }

        [HttpGet]
        [Route("{id}")]
        public Result<Blog, string[]> GetPost(string id)
        {
            return _blogService.GetBlog("1");
        }

        [HttpPost]
        public Result<Post, string[]> CreatePost(Post post)
        {
            return _postService.CreatePost(post);
        }
    }
}
