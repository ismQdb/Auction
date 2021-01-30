using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using ViewModel;

namespace AukcijskaProdaja {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public static MainWindow Instance { get; private set; }
        private static AuctionViewModel AuctionViewModelProperty {
            get {
                AuctionViewModel auctionViewModel = (AuctionViewModel)Instance.FindResource("AuctionDataContext");
                return auctionViewModel;
            }
        }

        public static void StartTimer() {
            AuctionViewModelProperty.auctionInstance.timer.Start();
        }

        public static void ResetTimer() {
            AuctionViewModelProperty.ResetTimer();
        }

        static MainWindow() {
            Instance = new MainWindow();

            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Instance.DataContext = mainWindowViewModel;
        }
        private MainWindow() {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e) {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            //this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
