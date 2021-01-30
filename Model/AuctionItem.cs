using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Model {
    public class AuctionItem : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        private int auctionItemID;
        private string auctionItemName;
        private int auctionItemPrice;
        private string auctionItemLastBidder;

        public int AuctionItemID {
            get { return auctionItemID; }
            set {
                auctionItemID = value;
                OnPropertyChanged(new PropertyChangedEventArgs("AuctionItemID"));
            }
        }

        public string AuctionItemName {
            get { return auctionItemName; }
            set {
                auctionItemName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("AuctionItemName"));
            }
        }

        public int AuctionItemPrice {
            get { return auctionItemPrice; }
            set {
                auctionItemPrice = value;
                OnPropertyChanged(new PropertyChangedEventArgs("AuctionItemPrice"));
            }
        }

        public string AuctionItemLastBidder {
            get { return auctionItemLastBidder; }
            set {
                auctionItemLastBidder = value;
                OnPropertyChanged(new PropertyChangedEventArgs("AuctionItemLastBidder"));
            }
        }

        public AuctionItem(int ItemId, string ItemName, int ItemPrice, string ItemLast) {
            this.AuctionItemID = ItemId;
            this.AuctionItemName = ItemName;
            this.AuctionItemPrice = ItemPrice;
            this.AuctionItemLastBidder = ItemLast;
        }

        public AuctionItem(int ItemId, string ItemName, int ItemPrice) {
            this.AuctionItemID = ItemId;
            this.AuctionItemName = ItemName;
            this.AuctionItemPrice = ItemPrice;
            this.AuctionItemLastBidder = "NA";
        }

        public AuctionItem() {
            this.AuctionItemLastBidder = "NA";
        }
    }
}
