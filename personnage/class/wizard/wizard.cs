public abstract class Wizard : Champion
{
    public Wizard(string Nom, int force, int pv) : base(Nom, force, pv)
    {
    }

    public override void CompetencesClass(Champion cible)
    {
        //si ennemi coller, recule de 1 car portée de 2 et envoie son sort d'attaque 
    }
    public virtual void Soigner(Champion cible)
    {
        // si allié a proximite, soigner et attaquer apres 
    }

    
}
