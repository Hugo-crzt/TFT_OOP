using System;
public class Map
{
    private Champion[,] _map;

    private int _width;
    private int _height;

    //crée la map 
    public Map(int width, int height)
    {
        _width = width;
        _height = height;
        _map = new Champion[_width,_height];
    }

    public void display()
    {
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
    }

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
        }

    }

} 