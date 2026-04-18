public static class MoteurAleatoire
{
    public static T TirerAuSort<T>(List<T> liste)
    {
        Random rnd = new Random();
        T randomItem = liste[rnd.Next(liste.Count)];
        return randomItem;
    }
}