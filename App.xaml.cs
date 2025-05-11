using System.Configuration;
using System.Data;
using System.Windows;

namespace hastane_odev
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var girisPenceresi = new Giris();
            girisPenceresi.Show();
        }
    }

}
