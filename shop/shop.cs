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

    //faire pour actualiser un seul champion
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

    public void acheterChampion(Banc banc, int choix)
    {
        choix-- ; //pour avoir le bon index 
        if(GameManager.Money >= ListeShop[choix].ChampionsCost)
        {
                banc.PlaceChampionBanc(ListeShop[choix]);
                GameManager.Money -= ListeShop[choix].ChampionsCost; 
                ListeShop[choix] = null; 
                ActualiserAchat();
                displayShop();               
        }
        else
        {
            throw new GameFundsException($"vous n'avez pas assez d'argent pour acheter {ListeShop[choix].Nom}");
        }

    }

    public void ChoixShop(Banc banc)
    {
        bool check = false;
        Console.WriteLine("choisissez un champion a acheter ou quittez ");
        while(check == false){
            string saisie = Console.ReadLine();
            if (int.TryParse(saisie, out int choix))
            {
                choix -= 1;
                if (choix == 4)
                {
                    return;
                }
                if(choix<ListeShop.Count && choix >= 0)
                {
                    try
                    {
                        acheterChampion(banc, choix);
                        ActualiserShop();
                        check = true;                        
                    }
                    catch (GameRuleException)
                    {
                        Console.WriteLine("vous n'avez pas de place sur le banc");
                    }
                    catch (GameFundsException)
                    {
                        Console.WriteLine("vous n'avez pas assez de sous");
                    }

                }
            }
            else
            {
                Console.WriteLine("Veuillez saisir un nombre valide");
            }
        }
    }


    public void displayShop()
    {
        Console.WriteLine("\n-----SHOP-----");
        foreach(Champion champ in ListeShop)
        {
            Console.Write($"--- {champ.Nom} : {champ.ChampionsCost} ---");
        }
        Console.WriteLine("\n--------------");
    }

    public Shop()
    {
        definirChampion();
        ActualiserShop();
    }
}