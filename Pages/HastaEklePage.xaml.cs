using System;
using System.Windows;
using System.Windows.Controls;
using hastane_odev.Models;
using hastane_odev.DataStructures; // HastaLinkedList ve HastaAgaci burada

namespace hastane_odev.Pages
{
    public partial class HastaEklePage : Page
    {
        public HastaEklePage()
        {
            InitializeComponent();
        }

        private void BtnKaydet_Click(object sender, RoutedEventArgs e)
        {
            // 1. Girdi verilerini al
            string adSoyad = txtAdSoyad.Text.Trim();
            string tckn = txtTCKN.Text.Trim();
            DateTime? dogum = dpDogumTarihi.SelectedDate;
            string teshis = txtTeshis.Text.Trim();

            // 2. Zorunlu alan kontrolü
            if (string.IsNullOrEmpty(adSoyad)
             || string.IsNullOrEmpty(tckn)
             || !dogum.HasValue)
            {
                MessageBox.Show(
                    "Ad Soyad, T.C. Kimlik No ve Doğum Tarihi zorunludur.",
                    "Uyarı",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );
                return;
            }

            // 3. Hasta modelini oluştur
            var yeniHasta = new Hasta
            {
                AdSoyad = adSoyad,
                TCKN = tckn,
                DogumTarihi = dogum.Value,
                Teshis = teshis,
                SonMuayene = "—"  // henüz yapılmamışsa placeholder
            };

            // 4. Bağlı listeye ekle
            HastaLinkedList.Ekle(yeniHasta);

            // 5. VEYA – BST'ye ekle
            HastaAgaci.Ekle(yeniHasta);

            // 6. Başarı mesajı
            MessageBox.Show(
                "Hasta başarıyla kaydedildi.",
                "Başarılı",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );

            // 7. Formu temizle
            txtAdSoyad.Clear();
            txtTCKN.Clear();
            dpDogumTarihi.SelectedDate = null;
            txtTeshis.Clear();
        }
    }
}
