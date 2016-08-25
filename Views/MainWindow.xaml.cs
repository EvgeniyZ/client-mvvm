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
        private MainViewModel _mainViewModel;

        public MainWindow()
        {
            InitializeComponent();
            _mainViewModel = (MainViewModel) DataContext;
        }
    }
}
