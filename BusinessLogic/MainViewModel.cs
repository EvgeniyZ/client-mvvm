using System;
using System.Windows.Input;
using Data;
using Models;

namespace BusinessLogic
{
    public class MainViewModel
    {
        private readonly DateTime _dateTimeNullValue = new DateTime();
        private ICommand _saveCommand;
        public ClientListViewModel ClientListViewModel { get; set; }
        public SaveClientViewModel SaveClientViewModel { get; set; }

        public ICommand Save
        {
            get { return _saveCommand ?? (_saveCommand = new RelayCommand(SaveClient)); }
        }

        public MainViewModel()
        {
            ClientListViewModel = new ClientListViewModel();
            SaveClientViewModel = new SaveClientViewModel();
        }

        private void SaveClient()
        {
            if (!string.IsNullOrEmpty(SaveClientViewModel.LastName) ||
                !string.IsNullOrEmpty(SaveClientViewModel.FirstName) ||
                SaveClientViewModel.Birthday != _dateTimeNullValue)
            {
                var client = new Client
                {
                    LastName = SaveClientViewModel.LastName,
                    FirstName = SaveClientViewModel.FirstName,
                    Birthday = SaveClientViewModel.Birthday
                };
                var viewModel = new ClientViewModel(client);
                using (var context = new ClientsContext())
                {
                    var id = context.CreateClient(client);
                    viewModel.Client.Id = id;
                }
                ClientListViewModel.Clients.Add(viewModel);
            }
        }
    }
}
