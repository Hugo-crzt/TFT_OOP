public class Ninja : Origin
{
    public static void BonusOrigin(List<Champion> champions)
    {
        if (GameManager.nbNinja >= 2) // Ton palier
        {
            foreach(Champion c in champions)
            {
                // On ne booste que ceux qui appartiennent à cette origine
                if (c.Origine is Ninja) 
                {
                    c.Speed ++;
                    c.Esquive ++;
                    Console.WriteLine($"Boost d'ésquive de 1 appliqué à {c.Nom} !");
                    Console.WriteLine($"Boost de vitesse de 1 appliqué à {c.Nom} !");
                    System.Threading.Thread.Sleep(1000);

                }
            }
        }
    }
}