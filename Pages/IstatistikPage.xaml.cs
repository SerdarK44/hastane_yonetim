using hastane_odev.Models;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using hastane_odev.DataStructures;

namespace hastane_odev.Pages
{
    public partial class IstatistikPage : Page
    {
        public IstatistikPage()
        {
            InitializeComponent();
            VerileriGetir();
        }

        private void VerileriGetir()
        {
            // 1. Toplam Hasta
            int toplamHasta = 0;
            var temp = HastaLinkedList.Bas;
            while (temp != null)
            {
                toplamHasta++;
                temp = temp.Sonraki;
            }

            // 2. Acil Kuyruk
            var toplam = hastane_odev.Models.AcilVeri.Listele().Count;


            // 3. Bugünkü Muayene Sayısı
            int bugunMuayene = 0;
            DateTime bugun = DateTime.Today;

            foreach (var pair in MuayeneVeri.Gecmisler)
            {
                foreach (var m in pair.Value)
                {
                    if (DateTime.TryParse(m.Tarih, out DateTime tarih) && tarih.Date == bugun)
                    {
                        bugunMuayene++;
                    }
                }
            }

            // 4. BST düğüm sayısı
            int bstSayi = 0;
            SayBST(HastaAgaci.Kok, ref bstSayi);

            // UI'ya yaz
            txtToplamHasta.Text = toplamHasta.ToString();
            int acilSayi = AcilVeri.Listele().Count;
            txtAcilSayi.Text = acilSayi.ToString();

            txtBugunMuayene.Text = bugunMuayene.ToString();
            txtBSTToplam.Text = bstSayi.ToString();
        }

        private void SayBST(BSTNode node, ref int sayac)
        {
            if (node == null) return;
            sayac++;
            SayBST(node.Sol, ref sayac);
            SayBST(node.Sag, ref sayac);
        }
    }
}
