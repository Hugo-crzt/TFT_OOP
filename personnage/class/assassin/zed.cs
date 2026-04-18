public class Zed : Assassin
{
    public Zed():base("Zed",85,1300,60,5,new Ninja(),1)
    {
        this.resourceBar = new ResourceBar(ResourceBar.ResourceType.Mana,50,100);  
        this.Esquive = 1;      
    }      

    public override char GetSymbol()
    {
        return 'Z';
    }

    public override void UpgradeStats()
    {
        if(this.Nv == 2)
        {
            this._baseForce = 128;
            this._basePVMax = 2340;
            this.PV = this._basePVMax;
        }
        else if(this.Nv == 3)
        {
            this._baseForce = 192;
            this._basePVMax = 4212;
            this.PV = this._basePVMax;

        }
    }
}