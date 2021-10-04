using Posts.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Posts.JsonPlaceHolderAPI.Abstractions
{
    public interface IPostService
    {
        Task<IEnumerable<PostModel>> GetPosts();
    }
}
