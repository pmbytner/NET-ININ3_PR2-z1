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

namespace NET_ININ3_PR2_z1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model model = new Model();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = model;
        }

        private void Cyfra(object sender, RoutedEventArgs e)
        {
            model.DopiszCyfrę(
                (string)((Button)sender).Content
                );
        }

        private void ZmianaZnaku(object sender, RoutedEventArgs e)
        {
            model.ZmieńZnak();
        }

        private void Przecinek(object sender, RoutedEventArgs e)
        {
            model.PostawPrzecinek();
        }

        private void Cofnij(object sender, RoutedEventArgs e)
        {
            model.Cofnij();
        }

        private void Resetuj(object sender, RoutedEventArgs e)
        {
            model.Resetuj();
        }

        private void Zeruj(object sender, RoutedEventArgs e)
        {
            model.Zeruj();
        }

        private void DziałanieZwykłe(object sender, RoutedEventArgs e)
        {
            model.DziałanieZwykłe(
                ((Button)sender).Content.ToString()
                );
        }

        private void PodajWynik(object sender, RoutedEventArgs e)
        {
            model.PodajWynik();
        }

        private void DziałanieJednoargumentowe(object sender, RoutedEventArgs e)
        {
            model.DziałanieJednoargumentowe(
                ((Button)sender).Content.ToString()
                );
        }

        private void DziałanieProcentowe(object sender, RoutedEventArgs e)
        {
            model.Procent();
        }
    }
}
