using System.Collections.Generic;
using hastane_odev.Models;
public static class MuayeneVeri
{
    // Her hastanın TCKN'sine karşılık stack tutar
    public static Dictionary<string, Stack<Muayene>> Gecmisler = new Dictionary<string, Stack<Muayene>>();

    public static void Ekle(string tckn, Muayene muayene)
    {
        if (!Gecmisler.ContainsKey(tckn))
            Gecmisler[tckn] = new Stack<Muayene>();

        Gecmisler[tckn].Push(muayene);
    }

    public static Stack<Muayene> Getir(string tckn)
    {
        return Gecmisler.ContainsKey(tckn) ? new Stack<Muayene>(Gecmisler[tckn]) : new Stack<Muayene>();
    }
}
