using System.Collections.Generic;

namespace hastane_odev.Models
{
    public static class AcilVeri
    {
        public static Queue<AcilHasta> Kritiklar = new Queue<AcilHasta>();
        public static Queue<AcilHasta> Ortalar = new Queue<AcilHasta>();
        public static Queue<AcilHasta> Hafifler = new Queue<AcilHasta>();

        public static List<AcilHasta> Listele()
        {
            List<AcilHasta> tum = new List<AcilHasta>();
            tum.AddRange(Kritiklar);
            tum.AddRange(Ortalar);
            tum.AddRange(Hafifler);
            return tum;
        }

        public static AcilHasta Cagir()
        {
            if (Kritiklar.Count > 0) return Kritiklar.Dequeue();
            if (Ortalar.Count > 0) return Ortalar.Dequeue();
            if (Hafifler.Count > 0) return Hafifler.Dequeue();
            return null;
        }
    }
}
