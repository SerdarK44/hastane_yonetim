using System.Windows;
using System.Windows.Controls;
using hastane_odev.Pages;

namespace hastane_odev
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContent.Navigate(new IstatistikPage()); // Açılış sayfası
        }

        private void BtnHastaEkle_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new HastaEklePage());
        }

        private void BtnHastaListele_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new HastaListePage());
        }

        private void BtnMuayeneEkle_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new MuayeneEklePage());
        }

        private void BtnGecmis_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new MuayeneGecmisPage());
        }

        private void BtnAcil_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new AcilHastaPage());
        }

        private void BtnArama_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new TcAramaPage());
        }

        private void BtnIstatistik_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new IstatistikPage());
        }

        private void BtnRapor_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new RaporPage());
        }

        private void BtnHakkinda_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new HakkindaPage());
        }
    }
}
