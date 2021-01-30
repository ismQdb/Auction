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

namespace AukcijskaProdaja {
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window {
        public AdminWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            AddItemWindow addItemWindow = new AddItemWindow();
            addItemWindow.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            AdminWindowViewModel adminWindowViewModel = new AdminWindowViewModel();
            this.DataContext = adminWindowViewModel;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
