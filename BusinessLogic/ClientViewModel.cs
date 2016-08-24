using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Data;
using Models;

namespace BusinessLogic
{
    public class ClientViewModel : INotifyPropertyChanged
    {
        private Client _client;

        public int Id { get { return _client.Id; } }

        public string LastName
        {
            get { return _client.LastName;}
            set
            {
                _client.LastName = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get { return _client.FirstName;}
            set
            {
                _client.FirstName = value;
                OnPropertyChanged();
            }
        }

        public DateTime Birthday
        {
            get { return _client.Birthday; }
            set
            {
                _client.Birthday = value;
                OnPropertyChanged();
            }
        }

        public Client Client
        {
            get { return _client;}
        }

        public ClientViewModel(Client client)
        {
            _client = client;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            using (var context = new ClientsContext())
            {
                context.UpdateClient(_client);
            }
        }
    }
}