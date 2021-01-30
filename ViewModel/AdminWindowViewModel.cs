using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Model;

namespace ViewModel {
    public class AdminWindowViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }


        private List<User> users = new List<User>();
        private List<AuctionItem> auctionItems = new List<AuctionItem>();
        private AuctionItem itemToDelete;
        //private Auction currentAuction;

        /*public Auction CurrentAuction {
            get { return currentAuction; }
            set {
                currentAuction = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CurrentAuction"));
            }
        }*/

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

        public AuctionItem ItemToDelete {
            get { return itemToDelete; }
            set {
                itemToDelete = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ItemToDelete"));
            } 
        }

        public AdminWindowViewModel() {
            //CurrentAuction = new Auction();
            AuctionItems = AuctionItemsCollection.GetAllAuctionItems();
            ItemToDelete = new AuctionItem();
            DeleteItemCommand = new CommandTemplate(DeleteItemExecute, DeleteItemCanExecute);
            UpdateCommand = new CommandTemplate(UpdateUsers, CanUpdateUsers);
        }

        private ICommand deleteItemCommand;

        public ICommand DeleteItemCommand {
            get { return deleteItemCommand; }
            set {
                deleteItemCommand = value;
                OnPropertyChanged(new PropertyChangedEventArgs("DeleteItemCommand"));
            }
        }

        void DeleteItemExecute(object obj) {
            if (ItemToDelete != null)
                AuctionItemsCollection.DeleteItem(ItemToDelete);
            
        }

        bool DeleteItemCanExecute(object obj) {
            if (ItemToDelete != null)
                return true;
            else
                return false;
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
