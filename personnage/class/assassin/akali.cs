public class Akali : Assassin
{
    public Akali():base("Akali",45,750,50,2,new Ninja(),1)
    {
        this.resourceBar = new ResourceBar(ResourceBar.ResourceType.Mana,0,30);   
        this.Esquive = 1;     
    }

    public override char GetSymbol()
    {
        return 'A';
    }

    public override void UpgradeStats()
    {
        if(this.Nv == 2)
        {
            this._baseForce = 68;
            this._basePVMax = 1350;
            this.PV = this._basePVMax;
        }
        else if(this.Nv == 3)
        {
            this._baseForce = 101;
            this._basePVMax = 2430;
            this.PV = this._basePVMax;
        }
        else if(this.Nv == 4)
        {
            this._baseForce = 151;
            this._basePVMax = 4374;
            this.PV = this._basePVMax;            
        }
    }
}