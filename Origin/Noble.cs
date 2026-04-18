public class Noble : Origin
{
    public static void BonusOrigin(List<Champion> champions)
    {
        if (GameManager.nbNoble >= 2) // Ton palier
        {
            foreach(Champion c in champions)
            {
                // On ne booste que ceux qui appartiennent à cette origine
                if (c.Origine is Noble) 
                {
                    c.Speed ++;
                }
            }
        }
    }
}