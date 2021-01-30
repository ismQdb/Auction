using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
/*
namespace Model {
    public class Auction {
        public AuctionItem currentAuctionItem;
        public int currentAuctionItemPrice;
        DispatcherTimer timer = new DispatcherTimer();

        public Auction(AuctionItem item) {
            currentAuctionItem = item;
            currentAuctionItemPrice = 0;
            timer.Interval = TimeSpan.FromSeconds(1);
        }

        public void StartAuction() {
            
        }
    }
} */
 
namespace Model {
    public sealed class Auction {
        private static Auction _instance = new Auction();

        protected Auction() { }

        public static Auction _Instance {
            get {
                if (_instance == null)
                    _instance = new Auction();
                return _instance;
            }
        }

        public AuctionItem CurrentAuctionItem { get; set; }
        public int CurrentItemPrice { get; set; }
        public User CurrentItemLastBidder { get; set; }
        public DispatcherTimer timer = new DispatcherTimer();
        public bool CanBidBeMade { get; set; }
        public User CurrentUser { get; set; }


        /*public void StartAuction() {
            timer.Interval = TimeSpan.FromSeconds(1);
            canBidBeMade = true;
        }*/
    }
}

