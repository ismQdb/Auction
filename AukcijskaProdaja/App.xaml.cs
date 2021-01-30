﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AukcijskaProdaja {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        public App() {
            Startup += this.App_Startup;
        }

        private void App_Startup(object sender, StartupEventArgs e) {
            AukcijskaProdaja.MainWindow.Instance.Show();
        }
    }
}
