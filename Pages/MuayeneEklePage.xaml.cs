using System.Windows;
using System.Windows.Controls;
using hastane_odev.Models;         // Hasta ve Muayene modelleri
using hastane_odev.DataStructures; // HastaAgaci (BST) ve MuayeneVeri (stack)

namespace hastane_odev.Pages
{
    public partial class MuayeneEklePage : Page
    {
        private Hasta seciliHasta;

        public MuayeneEklePage()
        {
            InitializeComponent();
        }

        private void BtnGetir_Click(object sender, RoutedEventArgs e)
        {
            string tckn = txtTCKN.Text.Trim();
            if (string.IsNullOrEmpty(tckn))
            {
                MessageBox.Show("Lütfen bir T.C. Kimlik No girin.", "Uyarı",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // BST üzerinden hasta ara
            seciliHasta = HastaAgaci.Ara(tckn);

            if (seciliHasta == null)
            {
                MessageBox.Show("Hasta bulunamadı.", "Bilgi",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                panelBilgi.Visibility = Visibility.Collapsed;
                return;
            }

            // Hasta bulundu, ekrana yaz
            lblAd.Text = $"👤 {seciliHasta.AdSoyad}";
            lblDogum.Text = $"📅 Doğum: {seciliHasta.DogumTarihi:dd.MM.yyyy}";
            lblTeshis.Text = $"🩺 Teşhis: {seciliHasta.Teshis}";
            panelBilgi.Visibility = Visibility.Visible;
        }

        private void BtnKaydet_Click(object sender, RoutedEventArgs e)
        {
            if (seciliHasta == null)
                return;

            var muayene = new Muayene
            {
                Tarih = dpTarih.SelectedDate?.ToString("dd.MM.yyyy"),
                Tani = txtTani.Text.Trim(),
                Islem = txtIslem.Text.Trim()
            };

            // Stack’e ekle
            MuayeneVeri.Ekle(seciliHasta.TCKN, muayene);

            MessageBox.Show("Muayene kaydedildi.", "Başarılı",
                            MessageBoxButton.OK, MessageBoxImage.Information);

            // Formu temizle
            txtTani.Clear();
            txtIslem.Clear();
            dpTarih.SelectedDate = null;
        }
    }
}
