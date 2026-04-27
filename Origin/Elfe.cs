public class Elfe : Origin
{
    public static void BonusOrigin(List<Champion> champions)
    {
        if (GameManager.nbElfe >= 2)
        {
            foreach(Champion c in champions)
            {
                // On ne booste que ceux qui appartiennent à cette origine
                if (c.Origine is Elfe) 
                {
                    c.Esquive ++ ; 
                    c.Speed +=2;
                    Console.WriteLine($"Boost d'ésquive de 1 appliqué à {c.Nom} !");
                    System.Threading.Thread.Sleep(1000);


                }
            }
        }
    }
    
}
