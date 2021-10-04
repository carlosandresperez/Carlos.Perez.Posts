using System.Windows;

namespace Posts.WPF.Views
{
    /// <summary>
    /// Interaction logic for PostView.xaml
    /// </summary>
    public partial class PostView : Window
    {
        public PostView(object dataContext)
        {
            InitializeComponent();

            DataContext = dataContext;
        }
    }
}
