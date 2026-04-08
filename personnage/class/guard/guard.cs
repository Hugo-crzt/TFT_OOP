public abstract class Guard : Champion
{
    public Guard(string Nom, int force, int pv) : base(Nom, force, pv)
    {
        this.Defense = 50;
    }

    public virtual void SeProteger(Champion cible)
    {
        //implementer une fonction qui permet de se proteger pendant 2 attaques 
    }
}
