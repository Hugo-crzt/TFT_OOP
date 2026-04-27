Joueur joueurHumain = new Joueur();
int pvEnnemi = 100; 
Map maMap = new Map();
Shop monShop = new Shop();
Gameloop moteurJeu = new Gameloop();
JournalDeCombat journal = new JournalDeCombat();
List<IConsommable> catalogueObjets = new List<IConsommable> 
{ 
    new Deathblade(), 
    new Warmog(), 
    new BrambleVest(),  
};

static void AfficherSynergies()
{
    Console.WriteLine("\n--- SYNERGIES ACTIVES ---");
    bool aucune = true;

    if (GameManager.nbNinja > 0) { Console.ForegroundColor = ConsoleColor.Magenta; Console.Write($"[Ninja: {GameManager.nbNinja}] "); aucune = false; }
    if (GameManager.nbElfe > 0) { Console.ForegroundColor = ConsoleColor.Green; Console.Write($"[Elfe: {GameManager.nbElfe}] "); aucune = false; }
    if (GameManager.nbNoble > 0) { Console.ForegroundColor = ConsoleColor.Yellow; Console.Write($"[Noble: {GameManager.nbNoble}] "); aucune = false; }
    if (GameManager.nbSauvage > 0) { Console.ForegroundColor = ConsoleColor.Red; Console.Write($"[Sauvage: {GameManager.nbSauvage}] "); aucune = false; }

    if (aucune) Console.Write("Aucune synergie active.");
    
    Console.ResetColor();
    Console.WriteLine("\n-------------------------");
}


static void GererPlacementJoueur(Joueur j, Map map, Gameloop loop, int numeroManche, Shop shop)
{
    bool fini = false;
    while (!fini)
    {
        map.display();
        AfficherSynergies();

        Console.WriteLine($"\n--- PHASE DE PRÉPARATION (Manche {numeroManche}) ---");
        Console.WriteLine($"Unités sur le terrain : {map.ListeChampion.Count} / {numeroManche}");
        Console.WriteLine("Options : [P] Placer | [D] Déplacer | [B] Banc | [I] Inventaire | [C]Catalogue | [V] Valider");    
        string choix = Console.ReadLine()?.ToUpper();

        if (choix == "P") { //placer un personnage
            if (map.ListeChampion.Count >= numeroManche) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[LIMITE] Vous ne pouvez placer que {numeroManche} champions !");
                Console.ResetColor();
                System.Threading.Thread.Sleep(1000);
                continue;
            }
            if (map.Banc.ListeChampionBanc.Count == 0) continue;

            Console.WriteLine($"Index du champion sur le BANC (1 à {map.Banc.ListeChampionBanc.Count}) :");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= map.Banc.ListeChampionBanc.Count) {
                Champion choisi = map.Banc.ListeChampionBanc[idx - 1];
                map.Banc.RemoveFromBanc(choisi); 
                loop.DeplacerAuClavier(choisi, map); 
                if (!map.ListeChampion.Contains(choisi)) map.ListeChampion.Add(choisi);
                map.ActualiserNbOrigin(map.ListeChampion);
            }
        }
        else if (choix == "D" || choix == "B") {// deplacer un champion du banc vers le plateau et inversemet
            if (map.ListeChampion.Count == 0) continue;
            Console.WriteLine($"\n--- Choisissez un champion sur le TERRAIN ---");
            for (int i = 0; i < map.ListeChampion.Count; i++) {
                var c = map.ListeChampion[i];
                Console.WriteLine($"[{i + 1}] {c.Nom} (Niv {c.Nv}) | Pos: {c.X},{c.Y}");
            }
            if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= map.ListeChampion.Count) {
                Champion cible = map.ListeChampion[idx - 1];
                if (choix == "D") loop.DeplacerAuClavier(cible, map);
                else if (choix == "B") {
                    if (map.Banc.ListeChampionBanc.Count < 9) {
                        var grille = map.GetTabMap();
                        for (int x = 0; x < grille.GetLength(0); x++)
                            for (int y = 0; y < grille.GetLength(1); y++)
                                if (grille[x, y] == cible) grille[x, y] = null;
                        map.ListeChampion.Remove(cible);
                        map.Banc.PlaceChampionBanc(cible);
                        map.ActualiserNbOrigin(map.ListeChampion);
                    }
                }
            }
        }
        if (choix == "I") //inventaire des objets
        {
            if (j.inventaireJoueur.Count == 0)
            {
                Console.WriteLine("Votre inventaire est vide !");
                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("\n--- INVENTAIRE ---");
                for (int i = 0; i < j.inventaireJoueur.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {j.inventaireJoueur[i].Nom}");
                }
                Console.WriteLine("[0] Annuler");

                if (int.TryParse(Console.ReadLine(), out int idxItem) && idxItem > 0 && idxItem <= j.inventaireJoueur.Count)
                {
                    Console.WriteLine("\nSur quel champion du TERRAIN voulez-vous l'équiper ?");
                    for (int i = 0; i < map.ListeChampion.Count; i++)
                    {
                        Console.WriteLine($"[{i + 1}] {map.ListeChampion[i].Nom}");
                    }

                    if (int.TryParse(Console.ReadLine(), out int idxChamp) && idxChamp > 0 && idxChamp <= map.ListeChampion.Count)
                    {
                        j.AppliquerLoot(idxItem, map.ListeChampion[idxChamp - 1]);
                    }
                }
            }
        }
        if (choix == "C") //afficher le catalogue 
        {
            shop.AfficherCatalogueComplet();
        }
        else if (choix == "V") {
            if (map.ListeChampion.Count > 0) fini = true;
            else {
                Console.WriteLine("Placez au moins un champion !");
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}

static List<Champion> GenererEnnemis(int manche, List<Champion> catalogue)
{
    List<Champion> ennemis = new List<Champion>();
    
    // L'ennemi a autant d'unités que le numéro de la manche
    int nbEnnemis = manche; 
    bool messageAffiche = false;

    // Si au moins une synergie, on en ajoute un de plus
    if (GameManager.nbElfe >= 2) 
    {
        nbEnnemis += 1;
        messageAffiche = true;
    }
    if (GameManager.nbNinja >= 2) 
    {
        nbEnnemis += 1;
        messageAffiche = true;
    } 
    if (GameManager.nbNoble >= 2) 
    {
        nbEnnemis += 1;
        messageAffiche = true;
    }
    if (GameManager.nbSauvage >= 2) 
    {
        nbEnnemis += 1;
        messageAffiche = true;
    }
    if (messageAffiche)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n[ALERTE] L'ennemi détecte vos puissantes synergies et envoie des renforts !");
        Console.ResetColor();        
    }

    // Sécurité pour ne pas dépasser la taille de la map
    nbEnnemis = Math.Min(nbEnnemis, 14); 

    for (int i = 0; i < nbEnnemis; i++) 
    {
        Champion e = MoteurAleatoire.TirerAuSort(catalogue).Clone();

        // Avant manche 5 : 33% de chance de Niv 2
        // Après manche 5 : 50% de chance de Niv 2
        // Après manche 10 : Garanti Niv 2 minimum, chance de Niv 3
        double chanceNiv2 = (manche > 5) ? 0.5 : 0.33;

        if (manche > 10)
        {
            e.Nv = (new Random().Next(0, 2) == 0) ? 2 : 3;
        }
        else if (new Random().NextDouble() < chanceNiv2)
        {
            e.Nv = 2;
        }

        e.UpgradeStats();

        // 4. PLACEMENT : On remplit les deux dernières lignes (6 et 5)
        e.X = 6 - (i / 7); 
        e.Y = i % 7;
        
        ennemis.Add(e);
    }
    return ennemis;
}

int numeroManche = 1;

// --- BOUCLE DE PARTIE ---
// MODIFICATION : On vérifie les PV des deux côtés
while (joueurHumain.PV > 0 && pvEnnemi > 0)
{
    Console.WriteLine($"========================================");
    Console.WriteLine($"      DEBUT DE LA MANCHE {numeroManche} ");
    Console.WriteLine($"   JOUEUR: {joueurHumain.PV} PV | ENNEMI: {pvEnnemi} PV"); // MODIFICATION : Affichage score
    Console.WriteLine($"========================================\n");

    // 1. PHASE DE PREPARATION
    if (numeroManche == 1) {
        Champion offert = MoteurAleatoire.TirerAuSort(monShop.ListeDeTousLesChampions).Clone();
        maMap.Banc.PlaceChampionBanc(offert);
        Console.WriteLine($"C'est le début ! Vous recevez {offert.Nom}.");
    } else {
        monShop.ActualiserShop();
        monShop.ChoixShop(maMap.Banc, maMap);
    }

    // 2. PHASE DE PLACEMENT
    GererPlacementJoueur(joueurHumain, maMap, moteurJeu, numeroManche, monShop);

    // 3. PHASE DE COMBAT 
    List<Champion> ennemis = GenererEnnemis(numeroManche, monShop.ListeDeTousLesChampions);
    foreach(var c in maMap.ListeChampion.Concat(ennemis)) journal.Link(c);

    Console.WriteLine("\n--- LE COMBAT COMMENCE ! ---");
    bool victoire = moteurJeu.LancerCombat(maMap.ListeChampion, ennemis);

    // 4. PHASE DE RESOLUTION & CALCUL DEGATS
    if (victoire) {
        // MODIFICATION : L'ennemi perd des PV  vous victoire
    
        int degatsInfliges = 5 + (maMap.ListeChampion.Count(a => !a.EstMort) * 2);
        pvEnnemi -= degatsInfliges;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nVICTOIRE ! L'ennemi perd {degatsInfliges} PV, il lui reste {pvEnnemi} PV.");
        if (new Random().Next(0, 2) == 0) 
        {
            //chance d'avoir un nouvel objet
            IConsommable loot = MoteurAleatoire.TirerAuSort(catalogueObjets);

            if (loot != null)
            {
                joueurHumain.inventaireJoueur.Add(loot);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\n[BUTIN] Incroyable ! Vous avez trouvé : {loot.Nom} !");
                Console.ResetColor();
                Console.ResetColor();
                Console.WriteLine("Appuyez sur une touche pour récupérer l'objet...");
                Console.ReadKey();
            }
        }
    } else {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\nDÉFAITE ! Vous perdez des PV.");
    }
    Console.ResetColor();

    // soigner les ennemis et donner les gains
    moteurJeu.GererFinDeManche(victoire, ennemis, joueurHumain, maMap, pvEnnemi);
    numeroManche++;
    Console.WriteLine("\nAppuyez sur une touche pour la manche suivante...");
    Console.ReadKey();
}

// FIN DE PARTIE 
if (joueurHumain.PV <= 0) {
    Console.WriteLine("\nGAME OVER... Votre légende s'arrête ici.");
} else {
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("\nFÉLICITATIONS ! L'ennemi est vaincu, vous avez gagné !");
    Console.ResetColor();
}


