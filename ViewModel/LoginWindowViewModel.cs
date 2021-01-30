using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Model;

namespace ViewModel {
    public class LoginWindowViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public User currentlyLogingUser = null;
        public bool canLogin = true;

        public User CurrentlyLogingUser {
            get { return currentlyLogingUser; }
            set {
                currentlyLogingUser = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CurrentlyLogingUser"));
            }
        }

        public bool CanLoginProperty {
            get { return canLogin; }
            set {
                canLogin = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CanLogin"));
            }
        }

        public LoginWindowViewModel() {
            CurrentlyLogingUser = new User();
            LoginCommand = new CommandTemplate(LoginExecute, CanLogin);
        }

        public ICommand loginCommand;

        public ICommand LoginCommand {
            get { return loginCommand; }
            set {
                loginCommand = value;
                OnPropertyChanged(new PropertyChangedEventArgs("LoginCommand"));
            }
        }

        public void LoginExecute(object parameter) {
            Auction._Instance.CurrentUser = this.CurrentlyLogingUser;
            this.CurrentlyLogingUser = null;
        }

        public bool CanLogin(object parameter) {
            if (currentlyLogingUser != null && CanLoginProperty)
                return true;
            else
                return false;
        }
    }
}
