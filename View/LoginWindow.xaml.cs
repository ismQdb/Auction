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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window {
        public LoginWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            LoginWindowViewModel loginWindowViewModel = new LoginWindowViewModel();
            this.DataContext = loginWindowViewModel;
        }

        private void loginButton_Click(object sender, RoutedEventArgs e) {
            LoginWindowViewModel loginWindowViewModel = (LoginWindowViewModel)DataContext;

            switch (UserCollection.CheckUserStatus(loginWindowViewModel.CurrentlyLogingUser)) {
                case 0:
                    loginWindowViewModel.CurrentlyLogingUser.IsAdmin = true;
                    loginWindowViewModel.CanLoginProperty = true;
                    break;
                case 1:
                    loginWindowViewModel.CurrentlyLogingUser.IsAdmin = false;
                    loginWindowViewModel.CanLoginProperty = true;
                    break;
                case 2:
                    loginWindowViewModel.CurrentlyLogingUser.IsAdmin = false;
                    loginWindowViewModel.CanLoginProperty = false;
                    break;
                default:
                    MessageBox.Show("Error occurred. Please try again.");
                    this.Close();
                    break;
            }

            if (!loginWindowViewModel.CanLoginProperty) {
                MessageBox.Show("Invalid user data. Please try again.");
                this.Close();
            }
            else if (loginWindowViewModel.CurrentlyLogingUser.IsAdmin && 
                loginWindowViewModel.CanLoginProperty) {
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
            }
            else  {
                RegularUserWindow regularUserWindow = new RegularUserWindow();
                regularUserWindow.Show();
            }

            this.Close();
        }
    }
}
