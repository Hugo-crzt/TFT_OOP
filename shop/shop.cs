public class Shop
{
    public List<Champion> ListeDeTousLesChampions = new List<Champion>();
    public List<Champion> ListeShop = new List<Champion>();

    public void definirChampion()
    {
        ListeDeTousLesChampions.Add(new Akali());
        ListeDeTousLesChampions.Add(new Zed());
        ListeDeTousLesChampions.Add(new Garen());
        ListeDeTousLesChampions.Add(new Leona());
        ListeDeTousLesChampions.Add(new Ashe());
        ListeDeTousLesChampions.Add(new Varus());
        ListeDeTousLesChampions.Add(new Arhi());
        ListeDeTousLesChampions.Add(new Lulu());
    }
    public void ActualiserShop()
    {

        ListeShop.Clear();
        for(int i = 0; i < 4; i++)
        {
            ListeShop.Add(MoteurAleatoire.TirerAuSort(ListeDeTousLesChampions));
        }
    }

    //actualiser qu'un seul champion quand on achète
    public void ActualiserAchat()
    {
        for (int i = 0; i < ListeShop.Count; i++)
        {
            if(ListeShop[i] == null)
            {
                ListeShop[i] = MoteurAleatoire.TirerAuSort(ListeDeTousLesChampions);
            }
        }
    }

    public void acheterChampion(Banc banc, int choix,Map map)
    {
        choix-- ; //pour avoir le bon index 
        if(GameManager.Money >= ListeShop[choix].ChampionsCost)
        {
                banc.PlaceChampionBanc(ListeShop[choix]);
                GameManager.Money -= ListeShop[choix].ChampionsCost; 
                Fusion.fusionnerChampion(ListeShop[choix],map.ListeChampion,banc.ListeChampionBanc, map, banc);
                ListeShop[choix] = null; 
                ActualiserAchat();
                displayShop();               
        }
        else
        {
            throw new GameFundsException($"vous n'avez pas assez d'argent pour acheter {ListeShop[choix].Nom}");
        }

    }

    public void displayShop()
    {
        Console.WriteLine("\n----- SHOP (Fortune: " + GameManager.Money + " PO) -----");
        for (int i = 0; i < ListeShop.Count; i++)
        {
            var champ = ListeShop[i];
            if (champ != null)
                Console.Write($"[{i + 1}] {champ.Nom} ({champ.ChampionsCost} PO)  ");
            else
                Console.Write($"[{i + 1}] VIDE  ");
        }
        Console.WriteLine("\n[R] Refresh (2 PO) | [S] Vendre un champion | [C] Catalogue des champions |[0] Quitter");
        Console.WriteLine("------------------------------------------");
    }

    public void ChoixShop(Banc banc, Map map)
    {
        bool check = false;
        while (!check)
        {
            map.display(); 
            banc.displayBanc(); // important de voir son banc avant d'acheter/vendre
            displayShop(); 
            
            Console.WriteLine("Entrez une option :");
            string saisie = Console.ReadLine()?.ToUpper();

            if (saisie == "0") return;

            // refresh le shop
            if (saisie == "R") {
                if (GameManager.Money >= 2) {
                    GameManager.Money -= 2;
                    ActualiserShop();
                } else {
                    Console.WriteLine("Pas assez d'or !");
                    System.Threading.Thread.Sleep(1000);
                }
                continue;
            }

            //vendre un perso 
            if (saisie == "S") {
                GererInterfaceVente(banc, map);
                continue;
            }
            //afficher le catalogue des perso
            if (saisie == "C")
            {
                AfficherCatalogueComplet();
            }

            // acheter un personage 
            if (int.TryParse(saisie, out int choix))
            {
                if (choix >= 1 && choix <= ListeShop.Count && ListeShop[choix-1] != null)
                {
                    try {
                        acheterChampion(banc, choix, map);
                    }
                    catch (Exception ex) { 
                        Console.WriteLine(ex.Message); 
                        System.Threading.Thread.Sleep(1000); 
                    }
                }
            }
        }
    }

    private void GererInterfaceVente(Banc banc, Map map)
    {
        // On récupère tous les champions possédés
        List<Champion> tousMesChamps = new List<Champion>();
        tousMesChamps.AddRange(map.ListeChampion);
        tousMesChamps.AddRange(banc.ListeChampionBanc);

        if (tousMesChamps.Count == 0) {
            Console.WriteLine("Vous n'avez aucun champion à vendre !");
            System.Threading.Thread.Sleep(1000);
            return;
        }
        if (tousMesChamps.Count <= 1) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n[ERREUR] Impossible de vendre : vous devez garder au moins un champion !");
            Console.ResetColor();
            System.Threading.Thread.Sleep(1500);
            return;
        }

        Console.WriteLine("\n--- MODE VENTE (Choisissez le numéro à vendre ou [0] pour annuler) ---");
        for (int i = 0; i < tousMesChamps.Count; i++)
        {
            var c = tousMesChamps[i];
            string lieu = map.ListeChampion.Contains(c) ? "Terrain" : "Banc";
            Console.WriteLine($"[{i + 1}] {c.Nom} (Niv {c.Nv}) - Prix: {c.ChampionsCost} PO | Position: {lieu}");
        }

        string choixVente = Console.ReadLine();
        if (int.TryParse(choixVente, out int index) && index > 0 && index <= tousMesChamps.Count)
        {
            VendreChampion(tousMesChamps[index - 1], map.ListeChampion, banc.ListeChampionBanc, map, banc);
        }
    }
    public Shop()
    {
        definirChampion();
        ActualiserShop();
    }
    public void VendreChampion(Champion cible, List<Champion> championMap, List<Champion> championBanc, Map map, Banc banc)
    {
        // remboursement en fonction du niveau
        if (cible.Nv == 1){
            GameManager.Money += cible.ChampionsCost;
        }
        if (cible.Nv == 2)
        {
            GameManager.Money = GameManager.Money + cible.ChampionsCost + 2;
        }
        if (cible.Nv == 3)
        {
            GameManager.Money = GameManager.Money + cible.ChampionsCost + 4; 
        }
        
        // Suppression physique 
        Fusion.SupprimerChampionPhysiquement(cible, championMap, championBanc, map, banc);
        
        Console.WriteLine($"\n{cible.Nom} a été vendu pour {cible.ChampionsCost} pièces.");
        System.Threading.Thread.Sleep(1000);
    }

    //pour connaitre les infos de tous les champions dispo
    public void AfficherCatalogueComplet()
    {
        Console.WriteLine("============================================================");
        Console.WriteLine("             CATALOGUE COMPLET DES CHAMPIONS                ");
        Console.WriteLine("============================================================\n");

        // On boucle sur la liste des champions
        foreach (var c in this.ListeDeTousLesChampions)
        {
            // On affiche les stats de base de chaque modèle
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{c.Nom,-12}");
            Console.ResetColor();
            
            Console.WriteLine($" | Prix: {c.ChampionsCost} PO | Force: {c.Force} | Def: {c.Defense} | Portée: {c.Portée} | Origine : {c.Origine}");
        }
        Console.WriteLine("\n============================================================");
        Console.WriteLine("Appuyez sur une touche pour fermer le catalogue...");
        Console.ReadKey();
    }
    
}