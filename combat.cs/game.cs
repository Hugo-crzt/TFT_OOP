public class Gameloop
{
    public bool LancerCombat(List<Champion> alliés, List<Champion> ennemis)
    {

        // Boucle de combat (Tant qu'il reste du monde des deux côtés)
        while (alliés.Any(a => !a.EstMort) && ennemis.Any(e => !e.EstMort))
        {
            // 1. Les alliés attaquent
            foreach (var a in alliés.Where(c => !c.EstMort))
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                var cible = a.TrouverCibleLaPlusProche(ennemis);
                if (cible != null) a.Attaquer(cible);//ajouter des consoles Writeline et changer la couleur 
            }
            Console.ResetColor();

            // 2. Les ennemis attaquent
            foreach (var e in ennemis.Where(c => !c.EstMort))
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                var cible = e.TrouverCibleLaPlusProche(alliés);
                if (cible != null) e.Attaquer(cible);
            }
            Console.ResetColor();
            System.Threading.Thread.Sleep(1000); 
        }

        bool joueurAGagné = alliés.Any(a => !a.EstMort);
        
        if (joueurAGagné) {
            Console.WriteLine("\n>>> VICTOIRE DE VOTRE ÉQUIPE ! <<<");
        } else {
            Console.WriteLine("\n>>> DÉFAITE... TOUS VOS CHAMPIONS SONT TOMBÉS. <<<");
        }

        return joueurAGagné; 
    }
    public void DeplacerAuClavier(Champion c, Map map)
    {
        var grille = map.GetTabMap();
        int hauteur = grille.GetLength(1);
        int largeur = grille.GetLength(0);
        bool validé = false;

        // --- RECHERCHE AUTOMATIQUE D'UNE CASE VIDE ---
        int xTemp = -1;
        int yTemp = -1;

        // On parcourt la zone alliée (lignes 3, 4, 5) pour trouver une case LIBRE
        for (int y = 3; y <= 5; y++)
        {
            for (int x = 0; x < largeur; x++)
            {
                if (grille[x, y] == null)
                {
                    xTemp = x;
                    yTemp = y;
                    break;
                }
            }
            if (xTemp != -1) break;
        }

        // Sécurité si la map est pleine 
        if (xTemp == -1) { xTemp = 0; yTemp = 4; } 

        // Si le champion était déjà sur la map (coordonnées valides), on libère sa case
        if (c.X >= 0 && c.X < largeur && c.Y >= 0 && c.Y < hauteur)
        {
            grille[c.X, c.Y] = null;
        }

        while (!validé)
        {
            grille[xTemp, yTemp] = c;
            map.display(); 
            Console.WriteLine($"\n[DÉPLACEMENT] {c.Nom} | Flèches pour bouger, [ENTRÉE] pour valider");
            
            ConsoleKeyInfo touche = Console.ReadKey(true);
            grille[xTemp, yTemp] = null; // Nettoyage temporaire pour le mouvement

            int prochainX = xTemp;
            int prochainY = yTemp;

            switch (touche.Key)
            {
                case ConsoleKey.UpArrow:    prochainY--; break;
                case ConsoleKey.DownArrow:  prochainY++; break;
                case ConsoleKey.LeftArrow:  prochainX--; break;
                case ConsoleKey.RightArrow: prochainX++; break;
                case ConsoleKey.Enter:
                    c.X = xTemp;
                    c.Y = yTemp;
                    grille[c.X, c.Y] = c;
                    validé = true;
                    continue; 
            }

            // Vérification des collisions et des limites
            if (prochainX >= 0 && prochainX < largeur && prochainY >= 3 && prochainY <= 5)
            {
                if (grille[prochainX, prochainY] == null)
                {
                    xTemp = prochainX;
                    yTemp = prochainY;
                }
            }
        }
    }
    public void ResetChampionsApresCombat(List<Champion> alliés)
    {
        foreach (var c in alliés)
        {
            c.ResetStats();
        }
    }

    public void GererFinDeManche(bool victoire, List<Champion> ennemisSurvivants, Joueur joueur, Map map, int pvIA)
    {
        Console.WriteLine("\n--- BILAN DE LA MANCHE ---");

        // 1. Calcul des intérêts (Max 5 PO)
        int interets = Math.Min(GameManager.Money / 10, 5);

        // 2. Gestion Victoire / Défaite
        int gainCombat = 0;

        if (victoire)
        {
            gainCombat = 5; 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"VICTOIRE ! Gain de base : {gainCombat} PO.");
        }
        else
        {
            gainCombat = 3; // Consolation
            // Calcul des dégâts subis par le joueur
            int degats = 5 + (ennemisSurvivants.Count(e => !e.EstMort) * 2);
            joueur.PV -= degats;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"DÉFAITE... -{degats} PV. Gain de consolation : {gainCombat} PO.");
        }

        // 3. Application de l'argent
        GameManager.Money += (gainCombat + interets);
        
        Console.ResetColor();
        Console.WriteLine($"Intérêts perçus : {interets} PO.");
        Console.WriteLine($"Fortune : {GameManager.Money} PO | Vos PV : {joueur.PV} | PV Ennemi : {pvIA}");

        // 4. RESET : On soigne tout le monde pour la manche suivante
        foreach (var c in map.ListeChampion)
        {
            c.ResetStats();
        }
    }
}