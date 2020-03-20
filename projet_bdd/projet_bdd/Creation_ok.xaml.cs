using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace projet_bdd
{
    /// <summary>
    /// Logique d'interaction pour Creation_ok.xaml
    /// </summary>
    public partial class Creation_ok : Window
    {
        public Creation_ok()
        {
            InitializeComponent();
        }

        private void ok(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }
    }
}
