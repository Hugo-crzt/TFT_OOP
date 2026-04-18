public class Arhi : Wizard
{
    public Arhi() : base("Ahri",30,650,25,3,new Sauvage(),4) //toute les ahri
    {
        this.resourceBar = new ResourceBar(ResourceBar.ResourceType.Mana,0,30);        
    }
    public override char GetSymbol()
    {
        return 'à';
    }
    public override void UpgradeStats()
    {
        if(this.Nv == 2)
        {
            this._baseForce = 45;
            this._basePVMax = 1170;
            this.PV = this._basePVMax;

        }
        else if(this.Nv == 3)
        {
            this._baseForce = 68;
            this._basePVMax = 2106;
            this.PV = this._basePVMax;

        }
        else if(this.Nv == 4)
        {
            this._baseForce = 102;
            this._basePVMax = 3790;  
            this.PV = this._basePVMax;
          
        }
    }
}