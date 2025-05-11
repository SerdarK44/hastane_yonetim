// DataStructures/HastaLinkedList.cs
using System.Collections.Generic;
using hastane_odev.Models;

namespace hastane_odev.DataStructures
{
    public class HastaNode
    {
        public Hasta Veri { get; set; }
        public HastaNode Sonraki { get; set; }
        public HastaNode(Hasta veri)
        {
            Veri = veri;
            Sonraki = null;
        }
    }

    public static class HastaLinkedList
    {
        public static HastaNode Bas = null;

        public static void Ekle(Hasta yeniHasta)
        {
            var yeniNode = new HastaNode(yeniHasta);
            if (Bas == null)
                Bas = yeniNode;
            else
            {
                var temp = Bas;
                while (temp.Sonraki != null)
                    temp = temp.Sonraki;
                temp.Sonraki = yeniNode;
            }
        }

        public static List<Hasta> Listele()
        {
            var liste = new List<Hasta>();
            var temp = Bas;
            while (temp != null)
            {
                liste.Add(temp.Veri);
                temp = temp.Sonraki;
            }
            return liste;
        }
    }
}
