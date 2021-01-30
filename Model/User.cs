using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public class User : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        private int userID;
        private string userName;
        private string userPassword;
        private bool isAdmin;

        public int UserID {
            get { return userID; }
            set {
                userID = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Id"));
            }
        }

        public string UserName {
            get { return userName; }
            set {
                userName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UserName"));
            }
        }

        public string UserPassword {
            get { return userPassword; }
            set {
                userPassword = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UserPassword"));
            }
        }

        public bool IsAdmin {
            get { return isAdmin; }
            set {
                isAdmin = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsAdmin"));
            }
        }

        public User(int userId, string userName, string userPassword, bool isAdmin) {
            this.UserID = userId;
            this.UserName = userName;
            this.UserPassword = userPassword;
            this.IsAdmin = isAdmin;
        }

        public User() { }
    }
}
