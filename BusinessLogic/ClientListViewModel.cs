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
        private ClientViewModel _selectedClient = null;
        private ICommand _deleteCommand;

        public ICommand Delete
        {
            get { return _deleteCommand ?? (_deleteCommand = new RelayCommand(DeleteSelected)); }
        }

        public ObservableCollection<ClientViewModel> Clients
        {
            get
            {
                return _clients;
            }
        }

        public ClientViewModel SelectedClient
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
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void DeleteSelected()
        {
            if (SelectedClient != null)
            {
                using (var context = new ClientsContext())
                {
                    context.DeleteClient(SelectedClient.Id);
                }
                _clients.Remove(SelectedClient);
                SelectedClient = null;
            }
        }
    }
}