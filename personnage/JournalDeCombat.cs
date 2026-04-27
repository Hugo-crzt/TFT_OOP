public class JournalDeCombat
{
    // Cette classe "observe" le champion
    public void annoncerDecès(Champion defunt)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"tragedie {defunt.Nom} est mort dans d'atroce souffrance");
        Console.ResetColor();
    }
    public void déplacer(Champion mouvant, Champion cible)
    {
        Console.WriteLine($"{mouvant.Nom} est trop loin, il se déplace vers {cible.Nom}...");
        Console.WriteLine($"{mouvant.Nom} est maintenant en ({mouvant.X}, {mouvant.Y})");
    }
    public void esquiver(Champion mouvant, Champion cible)
    {
        Console.WriteLine($"{cible.Nom} esquive l'attaque de {mouvant.Nom} ! ! ! ");
    }
    public void speedAttack(Champion lanceur,Champion cible)
    {
        Console.WriteLine($"{lanceur.Nom} va trop vite pour {cible.Nom} et l'attaque 2 fois !!!");  
    }

    public void displayattack(Champion lanceur,Champion cible,float degats)
    {
        Console.WriteLine($"{lanceur.Nom} attaque {cible.Nom} et lui inflige {degats} degats.");
    }


    public void Link(Champion champion)
    {
        // On se désabonne d'abord (au cas où il est déjà lié)
        champion.OnMort -= annoncerDecès;
        champion.OnAvancer -= déplacer;
        champion.OnEsquiver -= esquiver;
        champion.OnSpeed -= speedAttack;
        champion.OnAttaquer -= displayattack;

        // On s'abonne ensuite
        champion.OnMort += annoncerDecès;
        champion.OnAvancer += déplacer;
        champion.OnEsquiver += esquiver;
        champion.OnSpeed += speedAttack;
        champion.OnAttaquer += displayattack;
    }



}