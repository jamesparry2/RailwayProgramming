using RopExample.Models;
using RopExample.ROP;
using System.Collections.Generic;
using System.Linq;

namespace RopExample.Validators
{
    public static class BlogValidator
    {
        public static Result<Blog, string[]> ValidateBlog(Blog blog)
        {
            var errors = GetBlogErrors(blog).ToArray();

            return errors.Any()
                ? Result<Blog, string[]>.Failed(errors)
                : Result<Blog, string[]>.Succeeded(blog);
        }

        private static IEnumerable<string> GetBlogErrors(Blog blog)
        {
            if (blog == null)
            {
                yield return "Missing Blog";
                yield break;
            }

            if (blog.Id == null)
            {
                yield return "Missing Blog ID";
                yield break;
            }

            if (blog.Description == null)
            {
                yield return "Missing Blog Description";
                yield break;
            }

            if (blog.Name == null)
            {
                yield return "Missing Blog Name";
                yield break;
            }

            if (blog.Author == null)
            {
                yield return "Missing Author";
                yield break;
            }

            if(blog.Author.Name == null)
            {
                yield return "Missing Author Name";
                yield break;
            }
        }
    }
}
