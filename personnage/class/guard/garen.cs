public class Garen : Guard
{
    public Garen():base("Garen",65,1200,60,4,new Noble(),1)
    {
        this.resourceBar = new ResourceBar(ResourceBar.ResourceType.Mana,50,130);        
    }
    public override char GetSymbol()
    {
        return 'G';
    }
}