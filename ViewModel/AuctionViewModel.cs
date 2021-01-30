using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Model;

namespace ViewModel {
    public class AuctionViewModel : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        int time = 120;
        DispatcherTimer timer;
        private string formatText;
        public Auction auctionInstance = Auction._Instance;

        public Auction AuctionInstance {
            get { return auctionInstance; }
        }

        /*private static bool startAuctionFlag = false;

        public static bool StartAuctionFlag {
            get { return startAuctionFlag; }
            set { startAuctionFlag = value; }
        }*/

        public string FormatText {
            get { return formatText; }
            set {
                formatText = value;
                OnPropertyChanged(new PropertyChangedEventArgs("FormatText"));
            }
        }

        public AuctionViewModel() {
            timer = auctionInstance.timer;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += this.Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e) {
            FormatText = string.Format("0{0}:{1}", time / 60, time % 60);
            if (time >= 0)
                time--;
            if (time == 0) {
                timer.Stop();
                MessageBox.Show("The auction is closed. The winner is:" + 
                    Auction._Instance.CurrentItemLastBidder.UserName);
                RegularUserWindowViewModel.auctionFinished = true;
            }
        }

        public void ResetTimer() {
            time = 120;
            time += 120;
        }  
    }
}
