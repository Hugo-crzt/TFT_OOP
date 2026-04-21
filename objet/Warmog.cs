public class Warmog : IConsommable
{
    public string Nom => "Warmog's Armor";
    public void equiper(Champion cible)
    {
        Console.WriteLine($"[TFT ITEM] {cible.Nom} équipe la Warmog. Ses PV max augmentent de 500 !");
        cible.PVMax += 500; 
    }
}