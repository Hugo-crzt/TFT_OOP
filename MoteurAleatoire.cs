public static class MoteurAleatoire
{
    private static Random rnd = new Random();

    public static T TirerAuSort<T>(List<T> liste)
    {
        if (liste == null || liste.Count == 0) return default(T);

        T item = liste[rnd.Next(liste.Count)];

        // Si c'est un Champion, on clone
        if (item is Champion champion)
        {
            return (T)(object)champion.Clone();
        }
        
        // Si c'est un objet (IConsommable), on crée une nouvelle instance du même type
        if (item is IConsommable)
        {
            return (T)Activator.CreateInstance(item.GetType());
        }

        return item;
    }

    public static int Random10()
    {
        Random rnd = new Random();
        int resultat = rnd.Next(1, 11);
        return resultat;
    }

    public static int Random5()
    {
        Random rnd = new Random();
        int resultat = rnd.Next(1, 6);
        return resultat;       
    }
    public static bool ChanceUnSurTrois() => rnd.Next(0, 3) == 0;
}