public class Leona : Guard
{
    public Leona():base("Leona",50,700,45,1,new Noble(),1)
    {
        this.resourceBar = new ResourceBar(ResourceBar.ResourceType.Mana,40,100);          
    }

    public override char GetSymbol()
    {
        return 'L';
    }

    public override void UpgradeStats()
    {
        if(this.Nv == 2)
        {
            this._baseForce = 75;
            this._basePVMax = 1260;
            this.PV = this._basePVMax;

        }
        else if(this.Nv == 3)
        {
            this._baseForce = 113;
            this._basePVMax = 2268;
            this.PV = this._basePVMax;

        }
        else if(this.Nv == 4)
        {
            this._baseForce = 170;
            this._basePVMax = 4082; 
            this.PV = this._basePVMax;
           
        }
    }
}