public abstract class MarksMan : Champion
{
    public MarksMan(string Nom, int force, int pv) : base(Nom, force, pv)
    {
    }
    
    public override void CompetencesClass(Champion cible)
    {
        //implementer une fonction qui permet au tireur de tirer plus vite (ou plusieurs fois en un tour)
    }

    
}
