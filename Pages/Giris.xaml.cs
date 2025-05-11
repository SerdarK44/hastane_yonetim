using System.Windows;

namespace hastane_odev
{
    public partial class Giris : Window
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void BtnGiris_Click(object sender, RoutedEventArgs e)
        {
            string kullanici = txtKullaniciAdi.Text;
            string sifre = txtSifre.Password;

            // Basit doğrulama (gerçek projede veri tabanına bağlanılır)
            if (kullanici == "admin" && sifre == "1234")
            {
                MainWindow anaPencere = new MainWindow();
                anaPencere.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre.", "Giriş Başarısız", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
