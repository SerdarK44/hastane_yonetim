using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using hastane_odev.Models;
using hastane_odev.DataStructures;

namespace hastane_odev.Pages
{
    public partial class HastaListePage : Page
    {
        public HastaListePage()
        {
            InitializeComponent();
            HastalariListele();
        }

        private void BtnYenile_Click(object sender, RoutedEventArgs e)
        {
            HastalariListele();
        }

        private void HastalariListele()
        {
            List<Hasta> hastalar = new List<Hasta>();
            HastaNode temp = HastaLinkedList.Bas;

            while (temp != null)
            {
                var h = temp.Veri;

                // Stack'ten son muayene tarihi alınır
                string sonMuayeneTarihi = "";
                if (MuayeneVeri.Gecmisler.ContainsKey(h.TCKN) && MuayeneVeri.Gecmisler[h.TCKN].Count > 0)
                {
                    sonMuayeneTarihi = MuayeneVeri.Gecmisler[h.TCKN].Peek().Tarih;
                }

                hastalar.Add(new Hasta
                {
                    AdSoyad = h.AdSoyad,
                    TCKN = h.TCKN,
                    DogumTarihi = h.DogumTarihi,
                    SonMuayene = sonMuayeneTarihi,
                    Teshis = h.Teshis
                });

                temp = temp.Sonraki;
            }

            lstHastalar.ItemsSource = null;
            lstHastalar.ItemsSource = hastalar;
        }
    }
}
