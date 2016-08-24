using System.Windows;
using BusinessLogic;

namespace TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClientsViewModel _clientsViewModel;

        public MainWindow()
        {
            InitializeComponent();
            _clientsViewModel = new ClientsViewModel();
            DataContext = _clientsViewModel;
        }
    }
}
