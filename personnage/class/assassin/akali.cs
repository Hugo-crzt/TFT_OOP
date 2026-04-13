public class Akali : Assassin
{
    public Akali():base("Akali",30,1050,65,4,new Ninja(),1)
    {
        this.resourceBar = new ResourceBar(ResourceBar.ResourceType.Mana,0,30);        
    }

    public override char GetSymbol()
    {
        return 'A';
    }
}