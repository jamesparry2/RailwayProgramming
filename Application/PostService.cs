using Microsoft.AspNetCore.Mvc;
using RopExample.IDataLayer;
using RopExample.Models;
using RopExample.ROP;
using RopExample.Validators;

namespace RopExample.Application
{
    public class PostService : IPostService
    {
        private readonly IDatabaseLayer _databaseLayer;

        public PostService(IDatabaseLayer databaseLayer)
        {
            _databaseLayer = databaseLayer;
        }

        public Result<Post, string[]> CreatePost(Post post)
        {
            return Result<Post, string[]>
                .Succeeded(post)
                .Bind(PostValidator.ValidatePost)
                .Bind(_databaseLayer.InsertRop);
        }
    }
}
