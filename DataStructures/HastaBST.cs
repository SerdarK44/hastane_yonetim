public class BSTNode
{
    public Hasta Veri { get; set; }
    public BSTNode Sol { get; set; }
    public BSTNode Sag { get; set; }

    public BSTNode(Hasta veri)
    {
        Veri = veri;
        Sol = null;
        Sag = null;
    }
}

public static class HastaAgaci
{
    public static BSTNode Kok = null;

    public static void Ekle(Hasta yeni)
    {
        Kok = EkleRecursive(Kok, yeni);
    }

    private static BSTNode EkleRecursive(BSTNode node, Hasta yeni)
    {
        if (node == null)
            return new BSTNode(yeni);

        if (string.Compare(yeni.TCKN, node.Veri.TCKN) < 0)
            node.Sol = EkleRecursive(node.Sol, yeni);
        else if (string.Compare(yeni.TCKN, node.Veri.TCKN) > 0)
            node.Sag = EkleRecursive(node.Sag, yeni);

        return node;
    }

    public static Hasta Ara(string tckn)
    {
        return AraRecursive(Kok, tckn);
    }

    private static Hasta AraRecursive(BSTNode node, string tckn)
    {
        if (node == null)
            return null;

        if (node.Veri.TCKN == tckn)
            return node.Veri;

        if (string.Compare(tckn, node.Veri.TCKN) < 0)
            return AraRecursive(node.Sol, tckn);
        else
            return AraRecursive(node.Sag, tckn);
    }
}
