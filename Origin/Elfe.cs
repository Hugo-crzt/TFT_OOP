public class Elfe : Origin
{
    public static void BonusOrigin(List<Champion> champions)
    {
        Console.WriteLine($"Nombre d'Elfe : {GameManager.nbElfe}"); // DEBUG
        if (GameManager.nbElfe >= 2) // Ton palier
        {
            foreach(Champion c in champions)
            {
                // On ne booste que ceux qui appartiennent à cette origine
                if (c.Origine is Elfe) 
                {
                    c.Esquive ++ ; 
                    c.Speed +=2;
                    Console.WriteLine($"Boost de vitesse de 2 appliqué à {c.Nom} !");
                    Console.WriteLine($"Boost d'ésquive de 1 appliqué à {c.Nom} !");

                }
            }
        }
    }
    
}
