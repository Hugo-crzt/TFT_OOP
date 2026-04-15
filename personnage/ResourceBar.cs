public class ResourceBar 
{
    public int Value { get; set; }
    public enum ResourceType { Mana, Endurance, Energy, Rage }
    public int MaxValue { get; set; }
    public ResourceType Type { get; set; }

    // Le constructeur demande quel est le type de barre
    public ResourceBar(ResourceType type, int initialValue, int maxValue)
    {
        this.Type = type;
        this.Value = initialValue;
        this.MaxValue = maxValue;
    }

    public void AfficherResourceBar()
    {
        Console.Write("\n---barre de mana : ");
        for(int i = 0; i < this.MaxValue; i++)
        {
            if (i <= this.Value)
            {
                Console.Write("|");
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.Write($" {this.Value}/{this.MaxValue} ---\n");
    }
}