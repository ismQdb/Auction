using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Model;
using System.Windows.Input;

namespace ViewModel {
    public class AddItemWindowViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        private AuctionItem itemToAdd;

        public AuctionItem ItemToAdd {
            get { return itemToAdd; }
            set {
                if (itemToAdd == value) return;
                itemToAdd = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ItemToAdd"));
            }
        }

        public AddItemWindowViewModel() {
            itemToAdd = new AuctionItem();
            AddNewItemCommand = new CommandTemplate(AddItemExecute, CanAddItem);
        }

        private ICommand addNewItemCommand;

        public ICommand AddNewItemCommand {
            get { return addNewItemCommand; }
            set {
                if (addNewItemCommand == value) return;
                addNewItemCommand = value;
                OnPropertyChanged(new PropertyChangedEventArgs("AddNewItemCommand"));
            }
        }

        void AddItemExecute(object obj) {
            if (ItemToAdd != null) {
                AuctionItemsCollection.AddNewItem(ItemToAdd);
                Auction._Instance.CurrentAuctionItem = ItemToAdd;
            }
            Auction._Instance.CurrentItemPrice = ItemToAdd.AuctionItemPrice;            
        }

        bool CanAddItem(object obj) {
            if (ItemToAdd != null)
                return true;
            else
                return false;
        }
    }
}
