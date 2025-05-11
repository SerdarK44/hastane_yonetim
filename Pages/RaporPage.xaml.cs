using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using hastane_odev.Models;
using hastane_odev.DataStructures;

namespace hastane_odev.Pages
{
    public partial class RaporPage : Page
    {
        public RaporPage()
        {
            InitializeComponent();
        }

        private void BtnRaporla_Click(object sender, RoutedEventArgs e)
        {
            string tckn = txtTCKN.Text.Trim();
            var hasta = HastaAgaci.Ara(tckn);

            if (hasta == null)
            {
                MessageBox.Show("Hasta bulunamadı.");
                return;
            }

            var muayeneler = MuayeneVeri.Getir(tckn);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Hasta Bilgileri");
            sb.AppendLine($"Ad Soyad: {hasta.AdSoyad}");
            sb.AppendLine($"TCKN: {hasta.TCKN}");
            sb.AppendLine($"Doğum Tarihi: {hasta.DogumTarihi:dd.MM.yyyy}");
            sb.AppendLine($"Teşhis: {hasta.Teshis}");
            sb.AppendLine();
            sb.AppendLine("Muayene Geçmişi:");
            sb.AppendLine("Tarih		Tanı		İşlem");

            foreach (var m in muayeneler)
            {
                sb.AppendLine($"{m.Tarih}	{m.Tani}	{m.Islem}");
            }

            txtRapor.Text = sb.ToString();
        }

        private void BtnKaydet_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text Dosyası|*.txt";
            dialog.FileName = "HastaRapor.txt";

            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, txtRapor.Text);
                MessageBox.Show("Rapor başarıyla kaydedildi.");
            }
        }
    }
}
