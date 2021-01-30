using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Model;
using System.Windows.Threading;
using System.Windows.Input;

namespace ViewModel {
    public class MainWindowViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }


        private List<User> users = new List<User>();
        private List<AuctionItem> auctionItems = new List<AuctionItem>();

        public List<User> Users {
            get { return users; }
            set { 
                users = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Users"));
            }
        }

        public List<AuctionItem> AuctionItems {
            get { return auctionItems; }
            set { 
                auctionItems = value;
                OnPropertyChanged(new PropertyChangedEventArgs("AuctionItems"));
            }
        }

        public MainWindowViewModel() {
            AuctionItems = AuctionItemsCollection.GetAllAuctionItems();
            UpdateCommand = new CommandTemplate(UpdateUsers, CanUpdateUsers);
        }

        private ICommand updateCommand;

        public ICommand UpdateCommand {
            get { return updateCommand; }
            set {
                if (updateCommand == value) return;
                updateCommand = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UpdateCommand"));
            }
        }

        public bool CanUpdateUsers(object parameter) {
            return true;
        }

        public void UpdateUsers(object parameter) {
            AuctionItems = AuctionItemsCollection.GetAllAuctionItems();
        }
    }
}
