using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FindPlayers.Models
{
    public class User : INotifyPropertyChanged {
        private string username;
        public string Username {
            get { return username; }
            set { username = value; OnPropertyChanged("Username"); }
        }

        private string password;
        public string Password {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }

        private string fullInfo;
        public string FullInfo {
            get { return username + " " + password; }
            set { fullInfo = value; OnPropertyChanged("FullInfo"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
