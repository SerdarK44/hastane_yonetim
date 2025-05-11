using System.Collections.Generic;
using hastane_odev.Models;  // Muayene modeli burada tanımlı

namespace hastane_odev.DataStructures
{
    public static class MuayeneVeri
    {
        // Her hastanın TCKN'sine karşılık muayene yığını
        public static Dictionary<string, Stack<Muayene>> Gecmisler =
            new Dictionary<string, Stack<Muayene>>();

        public static void Ekle(string tckn, Muayene muayene)
        {
            if (!Gecmisler.ContainsKey(tckn))
                Gecmisler[tckn] = new Stack<Muayene>();
            Gecmisler[tckn].Push(muayene);
        }

        public static Stack<Muayene> Getir(string tckn)
        {
            return Gecmisler.ContainsKey(tckn)
                ? new Stack<Muayene>(Gecmisler[tckn])
                : new Stack<Muayene>();
        }
    }
}
