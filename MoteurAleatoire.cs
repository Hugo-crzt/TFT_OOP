public static class MoteurAleatoire
{
    private static Random rnd = new Random(); // On le met en dehors pour plus d'efficacité

    public static Champion TirerAuSort(List<Champion> liste)
    {
        Champion randomItem = liste[rnd.Next(liste.Count)];
        return randomItem.Clone(); // On renvoie une COPIE, pas l'original
    }
}