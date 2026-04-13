public class Zed : Assassin
{
    public Zed():base("Zed",50,1050,65,4,new Ninja(),1)
    {
        this.resourceBar = new ResourceBar(ResourceBar.ResourceType.Mana,30,50);        
    }      

    public override char GetSymbol()
    {
        return 'Z';
    }
}