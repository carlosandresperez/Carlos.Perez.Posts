using Posts.Domain.Model;
using Posts.JsonPlaceHolderAPI.Abstractions;
using Posts.WPF.Commands;
using Posts.WPF.ViewModels.Base;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Posts.WPF.ViewModels
{
    public class PostViewModel: ViewModelBase
    {
        private IEnumerable<PostModel> _posts;
        private bool _hideId;
        public IEnumerable<PostModel> Posts 
        {
            get { return _posts; }
            set
            {
                _posts = value;
                OnPropertyChanged(nameof(Posts));
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }
        public bool HideId
        {
            get
            {
                return _hideId;
            }
            set
            {
                _hideId = value;
                OnPropertyChanged(nameof(HideId));
                OnPropertyChanged(nameof(HideIdVisibility));
                OnPropertyChanged(nameof(HideUserIdVisibility));
            }
        }

        public Visibility HideIdVisibility => _hideId ? Visibility.Hidden : Visibility.Visible;
        public Visibility HideUserIdVisibility => _hideId ? Visibility.Visible : Visibility.Hidden;

        public ICommand LoadPostsCommand { get; }
        public ICommand HideIdCommand { get; }

        public PostViewModel(IPostService postService)
        {
            LoadPostsCommand = new LoadPostsCommand(this, postService);
            HideIdCommand = new HideIdCommand(this);
            LoadPostsCommand.Execute(null);

        }

        public static PostViewModel LoadPostViewModel(IPostService postService)
        {
            PostViewModel postViewModel = new PostViewModel(postService);
            postViewModel.LoadPostsCommand.Execute(null);
            return postViewModel;
        }
    }
}
