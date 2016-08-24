using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BusinessLogic;

namespace Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClientListViewModel _clientListViewModel;

        public MainWindow()
        {
            InitializeComponent();
            _clientListViewModel = new ClientListViewModel();
            DataContext = _clientListViewModel;
        }
    }
}
