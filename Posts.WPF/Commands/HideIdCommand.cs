using Posts.WPF.ViewModels;
using System.Threading.Tasks;

namespace Posts.WPF.Commands
{
    public class HideIdCommand: AsyncCommandBase
    {
        private readonly PostViewModel _postViewModel;
        public HideIdCommand(PostViewModel postViewModel)
        {
            _postViewModel = postViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _postViewModel.HideId = !_postViewModel.HideId;
        }
    }
}
