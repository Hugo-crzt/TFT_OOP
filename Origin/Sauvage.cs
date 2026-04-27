public class Sauvage : Origin
{
    public static void BonusOrigin(List<Champion> champions)
    {
        if (GameManager.nbSauvage >= 2) // Ton palier
        {
            foreach(Champion c in champions)
            {
                // On ne booste que ceux qui appartiennent à cette origine
                if (c.Origine is Sauvage) 
                {
                    c.Force +=40;
                    Console.WriteLine($"Boost d'attaque de 40 appliqué à {c.Nom} !");
                    System.Threading.Thread.Sleep(1000);

                }
            }
        }
    }
}