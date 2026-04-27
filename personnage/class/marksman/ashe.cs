public class Ashe : MarksMan
{
    public Ashe() : base("Ashe", 30, 550, 20, 2, new Elfe(),4)
    {
        this.resourceBar = new ResourceBar(ResourceBar.ResourceType.Mana,20,80); 
        this.Esquive = 1;       
    }
    public override char GetSymbol()
    {
        return 'a';
    }

    public override void UpgradeStats()
    {
        if(this.Nv == 2)
        {
            this._baseForce = 60;
            this._basePVMax = 990;
            this.PV = this._basePVMax;

        }
        else if(this.Nv == 3)
        {
            this._baseForce = 90;
            this._basePVMax = 1782;
            this.PV = this._basePVMax;

        }
        else if(this.Nv == 4)
        {
            this._baseForce = 135;
            this._basePVMax = 3207;  
            this.PV = this._basePVMax;
          
        }
    }   

}