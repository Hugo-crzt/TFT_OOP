public class Varus : MarksMan
{
    public Varus() : base("Varus",60,900,40,5,new Sauvage(),5 )
    {
        this.resourceBar = new ResourceBar(ResourceBar.ResourceType.Mana,15,85);        
    }
    
}