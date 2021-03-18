using Microsoft.AspNetCore.Mvc;
using RopExample.Models;
using RopExample.ROP;

namespace RopExample.Application
{
    public interface IPostService
    {
        Result<Post, string[]> CreatePost(Post post);
    }
}
