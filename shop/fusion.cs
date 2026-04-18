public static class Fusion
{
    public static List<Champion> ObtenirInventaireTotal(List<Champion> championMap, List<Champion> championBanc)
    {
        List<Champion> total = new List<Champion>();
        
        // On ajoute ceux du plateau
        total.AddRange(championMap);
        
        // On ajoute ceux du banc
        total.AddRange(championBanc);
        
        return total;
    }

    public static void fusionnerChampion(Champion cible, List<Champion> championMap, List<Champion> championBanc, Map map, Banc banc)
    {
        List<Champion> Total = ObtenirInventaireTotal(championMap, championBanc);
        var doublons = Total.Where(c => c.Nom == cible.Nom && c.Nv == cible.Nv).ToList();

        if (doublons.Count >= 3)
        {
            Console.WriteLine($"Fusion de {cible.Nom} réussie !");
            
            // 1. L'élu monte en niveau
            Champion survivant = doublons[0];
            survivant.Nv++;
            survivant.UpgradeStats();

            for (int i = 1; i <= 2; i++)
            {
                SupprimerChampionPhysiquement(doublons[i], championMap, championBanc, map, banc);
            }

            // 3. RÉCURSIVITÉ : On vérifie si ce nouveau niveau 2 peut fusionner en niveau 3
            if (survivant.Nv < 3)
            {
                fusionnerChampion(survivant, championMap, championBanc, map, banc);
            }
        }
    }
    public static void SupprimerChampionPhysiquement(Champion cible, List<Champion> championMap, List<Champion> championBanc,Map map,Banc banc)
    {
        // 1. On vérifie si le champion est sur le plateau
        if (championMap.Contains(cible))
        {
            // On vide la case dans le tableau 2D de la Map
            map.GetTabMap()[cible.X, cible.Y] = null;// On le retire de la liste passée en paramètre
            championMap.Remove(cible);
        }
        // 2. Sinon, on vérifie s'il est sur le banc
        else if (championBanc.Contains(cible))
        {
            // On appelle ta méthode pour vider la case visuelle du banc
            banc.RemoveFromBanc(cible);
            // On le retire de la liste passée en paramètre
            championBanc.Remove(cible);
        }
    }
}