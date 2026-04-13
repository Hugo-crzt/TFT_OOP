public class Ashe : MarksMan
{
    public Ashe() : base("Ashe", 60, 550, 20, 2, new Elfe(),4)
    {
        this.resourceBar = new ResourceBar(ResourceBar.ResourceType.Mana,20,80);        
    }
    public override char GetSymbol()
    {
        return 'a';
    }
}