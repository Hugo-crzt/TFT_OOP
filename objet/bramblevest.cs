public class BrambleVest : IConsommable
{
    public string Nom => "Bramble Vest";
    public void Consommer(Champion cible)
    {
        Console.WriteLine($"[TFT ITEM] {cible.Nom} équipe la Bramble Vest. La défense augmente de 40 !");
        cible.Defense += 40;
    }
}