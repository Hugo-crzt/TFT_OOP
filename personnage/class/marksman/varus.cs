public class Varus : MarksMan
{
    public Varus() : base("Varus",60,900,40,5,new Sauvage(),3 )
    {
        this.resourceBar = new ResourceBar(ResourceBar.ResourceType.Mana,15,85);        
    }
    
    public override char GetSymbol()
    {
        return 'V';
    }

    public override void UpgradeStats()
    {
        if(this.Nv == 2)
        {
            this._baseForce = 90;
            this._basePVMax = 1620;
            this.PV = this._basePVMax;

        }
        else if(this.Nv == 3)
        {
            this._baseForce = 135;
            this._basePVMax = 2916;
            this.PV = this._basePVMax;

        }
    }
}