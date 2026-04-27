public class Banc 
{
    private int _widthBanc;
    private int _heightBanc;
    private Champion[,] _banc;

    public List<Champion> ListeChampionBanc = new List<Champion>();

    public Banc()
    {
        _heightBanc = 1;
        _widthBanc = 9 ;
        _banc = new Champion[_widthBanc,_heightBanc];
    }
    public void displayBanc()
    {
        Console.WriteLine($"---BANC---");
        for (int x = 0; x < _banc.GetLength(0); x++)
        {
            if (_banc[x, 0] == null)
            {
                Console.Write(". ");
            }
            else
            {
                Console.Write(_banc[x, 0].GetSymbol() + " ");
            }
        }
        Console.WriteLine("");
    }

    public void PlaceChampionBanc(Champion cible)
    {
        if (_banc.Cast<Champion>().Any(c => c == null) == true)
        {
            for (int i = 0 ; i< _banc.GetLength(0);i++)
            {

                if(_banc[i,0]== null)
                {
                    _banc[i,0] = cible;
                    ListeChampionBanc.Add(cible);
                    return;
                }
            }
        }
        else
        {
            throw new GameRuleException($"Votre banc est plein !!!! Veuillez vendre certains de vos champions pour liberer de l'espace sur votre banc .");
        }
    }
    public void RemoveFromBanc(Champion cible)
    {
        for (int i = 0; i < _banc.GetLength(0); i++)
        {
            if (_banc[i, 0] == cible)
            {
                _banc[i, 0] = null; // On libère la place
                ListeChampionBanc.Remove(cible);
                return; 
            }
        }
    }
}