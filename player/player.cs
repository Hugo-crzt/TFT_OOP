    public class Joueur
{
    public int PV = 100;
    public List<IConsommable> inventaireJoueur = new List<IConsommable>();
    public void AppliquerLoot(int saisieUtilisateur,Champion cible)
    {
        // On convertit tout de suite le "1" de l'utilisateur en "0" pour le C#
        int indexReel = saisieUtilisateur - 1;

        // On vérifie si l'index est valide dans la liste
        if (indexReel >= 0 && indexReel < inventaireJoueur.Count)
        {
            var objet = inventaireJoueur[indexReel];
            objet.Consommer(cible);
            inventaireJoueur.RemoveAt(indexReel);
        }
        else
        {
            Console.WriteLine("Choix invalide ! L'objet n'existe pas.");
        }
    }
}