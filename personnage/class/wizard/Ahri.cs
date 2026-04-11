public class Arhi : Wizard
{
    public Arhi() : base("Ahri",30,650,25,3,new Sauvage(),4) //toute les ahri
    {
        this.resourceBar = new ResourceBar(ResourceBar.ResourceType.Mana,0,30);        
    }
}