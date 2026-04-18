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

    public override void UpgradeStats()
    {
        if(this.Nv == 2)
        {
            this._baseForce = 98;
            this._basePVMax = 2160;
            this.PV = this._basePVMax;

        }
        else if(this.Nv == 3)
        {
            this._baseForce = 147;
            this._basePVMax = 3888;
            this.PV = this._basePVMax;

        }
    }
}