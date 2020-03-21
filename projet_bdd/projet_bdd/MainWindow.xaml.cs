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

namespace projet_bdd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void conexion(object sender, RoutedEventArgs e)
        {
            if ((pseudo.Text=="" )|| (mdp.Text==""))
            {
                erreur_connexion a = new erreur_connexion();
                a.Show();

            }
            else
            {
                Acceuil page = new Acceuil();
                page.Show();
                this.Close();
            }

        }

        private void notyet(object sender, RoutedEventArgs e)
        {
            New_compte page = new New_compte();
            page.Show();
            this.Close();
        }

        private void leave(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
