public class Deathblade : IConsommable
{
    public string Nom => "Deathblade";
    public void Consommer(Champion cible)
    {
        Console.WriteLine($"[TFT ITEM] {cible.Nom} équipe la Deathblade. Force brute augmentée !");
        cible.Force += 25; 
    }
}