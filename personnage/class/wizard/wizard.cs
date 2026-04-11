public abstract class Wizard : Champion
{
    public Wizard(string Nom, int force, int pv, int defense,int championcost,Origin origine,int portée) : base(Nom, force, pv,defense,championcost,origine,portée)
    {
    }

    public override void CompetencesClass(Champion cible)
    {
    }
    public virtual void Soigner(Champion cible)
    {
        // si allié a proximite, soigner et attaquer apres 
    }

    
}
