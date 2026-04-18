using System.Security.AccessControl;

public class Lulu : Wizard
{
    public Lulu() : base("Lulu",30,650,25,3,new Elfe(),4) //toute les lulu
    {
        this.resourceBar = new ResourceBar(ResourceBar.ResourceType.Mana,0,60);
        this.Esquive = 1;
                
    }
    public override char GetSymbol()
    {
        return 'L';
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

    }
}