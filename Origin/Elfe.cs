public class Elfe : Origin
{
    public static void BonusOrigin(List<Champion> champions)
    {
        Console.WriteLine($"Vérification Elfe : nb = {GameManager.nbElfe}"); // DEBUG
        if (GameManager.nbElfe >= 2) // Ton palier
        {
            foreach(Champion c in champions)
            {
                // On ne booste que ceux qui appartiennent à cette origine
                if (c.Origine is Elfe) 
                {
                    c.Speed ++;
                    Console.WriteLine($"Boost appliqué à {c.Nom} ! Nouvelle vitesse : {c.Speed}");
                }
            }
        }
    }
    
}