public abstract class Assassin : Champion
{
    public Assassin(string Nom, int force, int pv, int defense, int cost, Origin origine,int portée) : base(Nom, force, pv,defense,cost,origine,portée)
    {
    }

    public override void CompetencesClass(Champion cible)
    {
        //implementer une fonction qui va couter tant de mana et qui permet a l'assassin de se rapprocher d'attaquer puis de reculer 
    }

}
