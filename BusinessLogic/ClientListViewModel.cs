using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Data;
using Models;

namespace BusinessLogic
{
    public class ClientListViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<ClientViewModel> _clients = new ObservableCollection<ClientViewModel>();
        private Client _selectedClient = null;

        public ICommand Add { get; private set; }

        public ObservableCollection<ClientViewModel> Clients
        {
            get
            {
                return _clients;
            }
        }

        public Client SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                if (value == _selectedClient) return;
                _selectedClient = value;
                OnPropertyChanged();
            }
        }

        public ClientListViewModel()
        {
            using (var context = new ClientsContext())
            {
                context.Clients.ToList().ForEach(x => _clients.Add(new ClientViewModel(x)));
            }
            Add = new RelayCommand(client =>
            {
                using (var context = new ClientsContext())
                {
                    var viewModel = client as ClientViewModel;
                    if (viewModel != null)
                    {
                        _clients.Add(viewModel);
                        context.Clients.Add(viewModel.Client);
                    }
                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}