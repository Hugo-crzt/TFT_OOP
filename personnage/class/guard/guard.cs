public abstract class Guard : Champion
{
    public Guard(string Nom, int force, int pv, int defense, int cost, Origin origine,int portée) : base(Nom, force, pv,defense,cost,origine,portée)
    {
    }
    public override void CompetencesClass(Champion cible)
    {
        base.CompetencesClass(cible); //pour l'instant de ne fait rien a determiner 
    }


}
