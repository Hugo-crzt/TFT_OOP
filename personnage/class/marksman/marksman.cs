public abstract class MarksMan : Champion
{
    public MarksMan(string Nom, int force, int pv, int defense, int cost, Origin origine,int portée) : base(Nom, force, pv, defense, cost, origine, portée)
    {
       this.Portée = 4; //pour l'instant on laisse car les deux persos ont 4 de portée  
    }
    


    
}
