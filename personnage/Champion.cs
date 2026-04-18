public abstract class Champion
{
    public string Nom{get; set;}
    public int Nv{get; set;}
    public int Defense;
    public int Speed;
    protected int _baseForce;
    protected int _baseDefense;
    protected int _basePVMax;
    public int ChampionsCost{get; set;}
    public int Portée{get; set;}
    public int Degat{get; set;}
    public int Esquive;
    public int X{get; set;} //gerer les coordonnées du joueur
    public int Y{get; set;}
    public ResourceBar? resourceBar {get;set;} //le ? est fait pour ignorer le fait qu'on puisse avoir une valeur nulle 


    public Origin Origine{get;set;}

    protected int _pvActuels;

    public int PV 
    {
        get => _pvActuels;
        set 
        {
            _pvActuels = value;
            if (_pvActuels > PVMax) _pvActuels = PVMax; // Empêche de soigner plus que le max
            if (_pvActuels < 0) _pvActuels = 0;
        }
    }

    public int PVMax 
    {
        get => _basePVMax;
        set => _basePVMax = value;
    }

    public Champion(string nom, int force, int pv, int defense,int cost,Origin origine,int portée)
    {
        this.Nom = nom;
        this._baseForce = force;
        this._basePVMax = pv;
        this.Nv = 1;
        this._baseDefense= defense;
        this.ChampionsCost = cost;
        this.Portée = portée;
        this.Origine = origine;
        this.Speed = 1;
        this.Esquive = 0;

        ResetStats();
    }
    public bool EstMort
    {
        get{
            if (this._pvActuels <= 0){
                return true;
            } 
            else
            {
                return false;
            }
        }
    }
    public int Force 
    {
        get => _baseForce; 
        set => _baseForce = value;
    }

    public virtual void Attaquer(Champion cible)
    {
        int dx = cible.X - this.X;
        int dy = cible.Y - this.Y;
        int distance = (dx * dx) + (dy * dy);
        int portee = this.Portée * this.Portée; //on met tout au carré pour eviter l'operation avec la racine(trop couteuse en calcul) 
        if (distance <= portee)
        {
            if(Nv ==1)
            {
                this.Degat = Force;
            }
            else if (Nv == 2)
            {
                this.Degat = 2*Force;

            }
            else if (Nv == 3)
            {
                this.Degat = 10*Force;
            }
            Console.WriteLine($"{this.Nom} attaque violemment {cible.Nom}et lui inflige {this.Degat} dégats" );
            cible.PV -= this.Degat;
        }
    }



    public virtual char GetSymbol()
    {
        return 'b';
    }

    public void ResetStats()
    {
        this.Force = _baseForce;
        this.Defense = _baseDefense;
        this.PV = _basePVMax;
        this.Speed = 1;
    }
    public Champion Clone()
    {
        // MemberwiseClone crée une copie superficielle de l'objet
        return (Champion)this.MemberwiseClone();
    }

    public virtual void UpgradeStats()
    {

    }


}