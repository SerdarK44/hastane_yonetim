// Models/AcilHasta.cs
using System;

namespace hastane_odev.Models
{
    public class AcilHasta
    {
        public string AdSoyad { get; set; }
        public string TCKN { get; set; }
        public string Aciliyet { get; set; }

        public override string ToString()
        {
            return $"{AdSoyad} – {TCKN} ({Aciliyet})";
        }
    }
}
