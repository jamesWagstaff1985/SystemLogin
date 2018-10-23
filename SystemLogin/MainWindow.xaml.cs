using System.Windows;

namespace SystemLogin
{
    using ReactiveUI;

    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.LoginWindow(new Model.DataHandling());
        }
    }
}
