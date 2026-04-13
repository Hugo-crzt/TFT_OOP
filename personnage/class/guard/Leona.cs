public class Leona : Guard
{
    public Leona():base("Leona",50,1000,60,3,new Noble(),1)
    {
        this.resourceBar = new ResourceBar(ResourceBar.ResourceType.Mana,70,120);          
    }

    public override char GetSymbol()
    {
        return 'L';
    }
}