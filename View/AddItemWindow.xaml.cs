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
using System.Windows.Shapes;
using ViewModel;
using Model;

namespace AukcijskaProdaja {
    /// <summary>
    /// Interaction logic for AddItemWindow.xaml
    /// </summary>
    public partial class AddItemWindow : Window {
        public AddItemWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            AddItemWindowViewModel addItemWindowViewModel = new AddItemWindowViewModel();
            this.DataContext = addItemWindowViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Item added successfully.");
            //AuctionViewModel.StartAuctionFlag = true;
            MainWindow.StartTimer();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
