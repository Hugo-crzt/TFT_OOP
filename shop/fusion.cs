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
    public static void AfficherStatsFusion(Champion c) {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n FUSION RÉUSSIE ! ");
        Console.WriteLine($"{c.Nom} passe au niveau {c.Nv} !");
        Console.WriteLine($"Nouveaux PV : {c.PVMax} | Nouvelle Attaque : {c.Force}");
        Console.ResetColor();
        Console.ReadKey();
    }

    public static void fusionnerChampion(Champion cible, List<Champion> championMap, List<Champion> championBanc, Map map, Banc banc)   
    {
        List<Champion> Total = ObtenirInventaireTotal(championMap, championBanc);
        // On cherche les doublons de même nom et même niveau
        var doublons = Total.Where(c => c.Nom == cible.Nom && c.Nv == cible.Nv).ToList();

        if (doublons.Count >= 3)
        {            
            // 1. On choisit celui qui reste (le survivant)
            Champion survivant = doublons[0];
            
            // On mémorise les stats AVANT pour l'affichage
            float pvAvant = survivant.PVMax;
            float forceAvant = survivant.Force;

            // 2. Évolution
            survivant.Nv++;
            survivant.UpgradeStats();

            // 3. On supprime physiquement les deux autres
            for (int i = 1; i <= 2; i++)
            {
                SupprimerChampionPhysiquement(doublons[i], championMap, championBanc, map, banc);
            }

            // 4. AFFICHAGE (On utilise 'survivant' car c'est lui qui a les nouvelles stats)
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n FUSION ! {survivant.Nom} monte au Niveau {survivant.Nv} !");
            Console.WriteLine($"Stats : PV ({pvAvant} -> {survivant.PVMax}) | ATQ ({forceAvant} -> {survivant.Force})");
            Console.ResetColor();
            System.Threading.Thread.Sleep(1000);
            if (survivant.Nv < 3)
            {
                fusionnerChampion(survivant, championMap, championBanc, map, banc);
            }
        }
    }
    public static void SupprimerChampionPhysiquement(Champion cible, List<Champion> championMap, List<Champion> championBanc, Map map, Banc banc)
    {
        var grille = map.GetTabMap();
        for (int x = 0; x < grille.GetLength(0); x++)
        {
            for (int y = 0; y < grille.GetLength(1); y++)
            {
                if (grille[x, y] == cible) 
                {
                    grille[x, y] = null;
                }
            }
        }

        // 2. NETTOYAGE DES LISTES LOGIQUES
        if (championMap.Contains(cible))
        {
            championMap.Remove(cible);
        }
        
        if (championBanc.Contains(cible))
        {
            championBanc.Remove(cible);
        }

        // 3. NETTOYAGE DU BANC (VISUEL)
        banc.RemoveFromBanc(cible);
        
        // 4. MISE À JOUR DES SYNERGIES
        map.ActualiserNbOrigin(championMap);
    }
}