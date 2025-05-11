using System.Windows;
using System.Windows.Controls;

namespace hastane_odev.Pages
{
    public partial class TcAramaPage : Page
    {
        public TcAramaPage()
        {
            InitializeComponent();
        }

        private void BtnAra_Click(object sender, RoutedEventArgs e)
        {
            string tckn = txtTCKN.Text.Trim();

            if (string.IsNullOrEmpty(tckn))
            {
                MessageBox.Show("Lütfen bir TCKN girin.", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var hasta = HastaAgaci.Ara(tckn);

            if (hasta == null)
            {
                txtSonuc.Text = "❌ Hasta bulunamadı.";
            }
            else
            {
                txtSonuc.Text = $"👤 {hasta.AdSoyad}\n" +
                                $"🆔 TC: {hasta.TCKN}\n" +
                                $"📅 Doğum: {hasta.DogumTarihi}\n";
            }
        }
    }
}
