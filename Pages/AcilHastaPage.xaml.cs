using System.Windows;
using System.Windows.Controls;
using hastane_odev.Models;     // AcilVeri ve AcilHasta burada tanımlı

namespace hastane_odev.Pages
{
    public partial class AcilHastaPage : Page
    {
        public AcilHastaPage()
        {
            InitializeComponent();
            ListeyiYenile();
        }

        private void BtnEkle_Click(object sender, RoutedEventArgs e)
        {
            // 1) Kullanıcı girdilerini oku
            string ad = txtAdSoyad.Text.Trim();
            string tckn = txtTCKN.Text.Trim();
            // ComboBoxItem.Tag ile sadece "Kritik"/"Orta"/"Hafif" alıyoruz
            string aciliyet = cmbAciliyet.SelectedValue as string ?? "";

            // 2) Zorunlu alan kontrolü
            if (string.IsNullOrEmpty(ad) ||
                string.IsNullOrEmpty(tckn) ||
                string.IsNullOrEmpty(aciliyet))
            {
                MessageBox.Show(
                    "Lütfen Ad Soyad, T.C. Kimlik No ve Aciliyet bilgilerini eksiksiz girin.",
                    "Uyarı",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );
                return;
            }

            // 3) Yeni AcilHasta nesnesi oluştur
            var hasta = new AcilHasta
            {
                AdSoyad = ad,
                TCKN = tckn,
                Aciliyet = aciliyet
            };

            // 4) Önceliğe göre kuyruğa ekle
            switch (aciliyet)
            {
                case "Kritik":
                    AcilVeri.Kritiklar.Enqueue(hasta);
                    break;
                case "Orta":
                    AcilVeri.Ortalar.Enqueue(hasta);
                    break;
                case "Hafif":
                    AcilVeri.Hafifler.Enqueue(hasta);
                    break;
            }

            // 5) Debug çıktısı (isteğe bağlı)
            System.Diagnostics.Debug.WriteLine(
                $"[AcilHastaPage] Eklendi: {hasta.AdSoyad} ({hasta.Aciliyet})"
            );

            // 6) Listeyi güncelle ve formu temizle
            ListeyiYenile();
            txtAdSoyad.Clear();
            txtTCKN.Clear();
            cmbAciliyet.SelectedIndex = -1;
        }

        private void BtnCagir_Click(object sender, RoutedEventArgs e)
        {
            var hasta = AcilVeri.Cagir();
            if (hasta != null)
            {
                MessageBox.Show(
                    $"{hasta.AdSoyad} ({hasta.Aciliyet}) çağrıldı.",
                    "Hasta Çağırıldı",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );
            }
            else
            {
                MessageBox.Show(
                    "Kuyrukta bekleyen hasta yok.",
                    "Bilgi",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );
            }

            ListeyiYenile();
        }

        private void ListeyiYenile()
        {
            lstKuyruk.ItemsSource = null;
            lstKuyruk.ItemsSource = AcilVeri.Listele();
        }
    }
}
