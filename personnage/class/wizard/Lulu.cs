using System.Security.AccessControl;

public class Lulu : Wizard
{
    public Lulu() : base("Lulu",25,500,15,1,new Elfe(),4) //toute les lulu
    {
        this.resourceBar = new ResourceBar(ResourceBar.ResourceType.Mana,10,55);        
    }
    public override char GetSymbol()
    {
        return 'L';
    }
}