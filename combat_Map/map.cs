using System;
public class Map
{
    private Champion[,] _map;
    private int _width;
    private int _height;
    public List<Champion> ListeChampion = new List<Champion>();

    public Banc Banc;
    

    //crée la map

    public Map()
    {
        _width = 7;
        _height = 6;
        _map = new Champion[_width,_height];
        Banc = new Banc();
    }



    //afiche la map 
    public void display()
    {
        Console.WriteLine($"---MAP---");
        for (int y = 0; y < _map.GetLength(1); y++)
        {
            for (int x = 0; x < _map.GetLength(0); x++)
            {
                if (_map[x, y] == null)
                {
                    Console.Write(". ");
                }
                else
                {
                    Console.Write(_map[x, y].GetSymbol() + " ");
                }
            }

            Console.WriteLine(); // saut de ligne après chaque ligne
        }
        Banc.displayBanc();
    }

    //aficher le banc 

    //placer des champions sur le banc 

    //placer un champion sur la zone de jeu 
    public void PlaceChampion(Champion cible, int x, int y)
    {
        if(cible.X < 0 || cible.Y < 0|| cible.X >= _map.GetLength(0) || cible.Y >= _map.GetLength(1))
        {
            throw new GameRuleException($"Coordonnées Incorrect ! Essayez de placer {cible.Nom} à une autre pose.");
        }
        if(_map[cible.X,cible.Y] != null)
        {
            throw new GameRuleException($"un champion {_map[cible.X,cible.Y].Nom} est déjà sur cette coordonnées, essayez une autre.");
        }
        else
        {
            _map[cible.X,cible.Y] = cible;
            
            ListeChampion.Add(cible);
            
        }
        ActualiserNbOrigin(ListeChampion);
        

    }
    //enlever un champion de la zone de jeu 
    public void RemoveChampion(Champion cible)
    {
        try
        {
            Banc.PlaceChampionBanc(cible);
            _map[cible.X,cible.Y] = null ;
            ListeChampion.Remove(cible);
        }
        catch (GameRuleException)
        {
            Console.WriteLine($"vous ne pouvez pas enlever {cible.Nom} car le banc est plein.");
        }
         
        
    }

    public void ActualiserNbOrigin(List<Champion> champions)
    {
        
        GameManager.ResetCounter();
        List<Tuple<string, Origin>> liste = new List<Tuple<string, Origin>>();        
        foreach(Champion champ in champions){
            liste.Add(Tuple.Create(champ.Nom,champ.Origine));

        }
        var uniqueList = liste.Distinct().ToList();
        foreach(Tuple<string,Origin> elements in uniqueList)
        {
            if (elements.Item2 is Elfe elfe)
            {
                GameManager.nbElfe++ ;
            }
            else if (elements.Item2 is Noble noble )
            {
                GameManager.nbNoble++ ; 
            }
            else if (elements.Item2 is Sauvage sauvage)
            {
                GameManager.nbSauvage++ ; 
            }
            else
            {
                GameManager.nbNinja++ ; 
            }
        }
        AppliquerBonus(ListeChampion);

        
    }

    public void AppliquerBonus(List<Champion> unique)
    {
        foreach(Champion c in ListeChampion)
        {
            c.ResetStats();
        }

        Elfe.BonusOrigin(ListeChampion);
        Noble.BonusOrigin(ListeChampion);
        Sauvage.BonusOrigin(ListeChampion);
        Ninja.BonusOrigin(ListeChampion);
    }



} 