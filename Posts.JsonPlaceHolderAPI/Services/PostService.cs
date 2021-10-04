using Posts.Domain.Model;
using Posts.JsonPlaceHolderAPI.Abstractions;
using Posts.JsonPlaceHolderAPI.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Posts.JsonPlaceHolderAPI.Services
{
    public class PostService : IPostService
    {
        private readonly JsonPlaceHolderAPIHttpClient _client;

        public PostService(JsonPlaceHolderAPIHttpClient client)
        {
            _client = client;
        }
        public async Task<IEnumerable<PostModel>> GetPosts()
        {
            var endpoint = "/posts";
            var posts = await _client.GetAsync<IEnumerable<PostModel>>(endpoint);
            return posts;
        }
    }
}
