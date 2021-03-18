using Microsoft.AspNetCore.Mvc;
using RopExample.Models;
using RopExample.ROP;
using System.Collections.Generic;
using System.Linq;

namespace RopExample.Validators
{
    public static class PostValidator
    {
        public static Result<Post, string[]> ValidatePost(Post post)
        {
            var errors = GetPostErrors(post).ToArray();

            return errors.Any()
                ? Result<Post, string[]>.Failed(errors)
                : Result<Post, string[]>.Succeeded(post);
        }

        private static IEnumerable<string> GetPostErrors(Post post)
        {
            if(post.PostId == 0)
            {
                yield return "Missing Post ID";
                yield break;
            }

            if (post.Content == null)
            {
                yield return "Missing Post Content";
                yield break;
            }

            if(post.Title == null)
            {
                yield return "Missing Post Title";
                yield break;
            }
        }

    }
}
