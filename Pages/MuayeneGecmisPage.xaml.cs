using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace hastane_odev.Pages
{
    public partial class MuayeneGecmisPage : Page
    {
        public MuayeneGecmisPage()
        {
            InitializeComponent();
        }

        private void BtnGetir_Click(object sender, RoutedEventArgs e)
        {
            string tckn = txtTCKN.Text.Trim();

            if (string.IsNullOrEmpty(tckn))
            {
                MessageBox.Show("Lütfen TCKN giriniz.", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Stack<Muayene> gecmis = MuayeneVeri.Getir(tckn);

            if (gecmis.Count == 0)
            {
                MessageBox.Show("Bu hastaya ait muayene geçmişi bulunamadı.", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
                lstGecmis.ItemsSource = null;
                return;
            }

            List<string> gosterilecekler = new List<string>();
            foreach (var m in gecmis)
            {
                gosterilecekler.Add($"{m.Tarih} - {m.Tani} - {m.Islem}");
            }

            lstGecmis.ItemsSource = gosterilecekler;
        }
    }
}
