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
    /// Logique d'interaction pour New_compte.xaml
    /// </summary>
    public partial class New_compte : Window
    {
        public New_compte()
        {
            InitializeComponent();
        }

        private void creation(object sender, RoutedEventArgs e)
        {
            //if(tous est validé)
            Creation_ok a = new Creation_ok();
            a.Show();
            this.Close();

        }

        private void retour(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }
    }
}
