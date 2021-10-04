using Posts.JsonPlaceHolderAPI.Abstractions;
using Posts.WPF.ViewModels;
using System.Threading.Tasks;

namespace Posts.WPF.Commands
{
    public class LoadPostsCommand : AsyncCommandBase
    {
        private readonly PostViewModel _postViewModel;
        private readonly IPostService _postService;

        public LoadPostsCommand(PostViewModel postViewModel, IPostService postService)
        {
            _postViewModel = postViewModel;
            _postService = postService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _postViewModel.IsLoading = true;
            await Task.WhenAll(LoadPosts());

            _postViewModel.IsLoading = false;
        }

        private async Task LoadPosts()
        {
            _postViewModel.Posts = await _postService.GetPosts();
        }
    }
}
