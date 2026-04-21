using System.Diagnostics;

public abstract class Champion
{
    public string Nom{get; set;}
    public int Nv{get; set;}
    public float Defense;
    public int Speed;
    protected float _baseForce;
    protected float _baseDefense;
    protected float _basePVMax;
    public int ChampionsCost{get; set;}
    public int Portée{get; set;}

    public float Degat{get; set;}
    
    public int Esquive;
    public int X{get; set;} //gerer les coordonnées du joueur
    public int Y{get; set;}
    public ResourceBar? resourceBar {get;set;} //le ? est fait pour ignorer le fait qu'on puisse avoir une valeur nulle 


    public Origin Origine{get;set;}
    public event Action<Champion> OnMort;
    public event Action<Champion,Champion> OnAvancer;
    public event Action<Champion,Champion> OnEsquiver;
    public event Action<Champion,Champion> OnSpeed;
    public event Action<Champion,Champion,float> OnAttaquer;


    protected float _pvActuels;

    public float PV 
    {
        get => _pvActuels;
        set 
        {
            _pvActuels = value;
            if (_pvActuels > PVMax) _pvActuels = PVMax; // Empêche de soigner plus que le max
            if (_pvActuels < 0)
            {
                _pvActuels = 0; 
                OnMort?.Invoke(this); 
            } 
        }
    }

    public float PVMax 
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
    public float Force 
    {
        get => _baseForce; 
        set => _baseForce = value;
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

    public virtual void UpgradeStats(){}


    public void Attaquer(Champion cible)
    {
        int dx = cible.X - this.X;
        int dy = cible.Y - this.Y;
        int distanceCarree = (dx * dx) + (dy * dy);
        int porteeCarree = this.Portée * this.Portée;
        if(porteeCarree >= distanceCarree)
        {
            double reduction = 100.0 / (100.0 + cible.Defense);
            float degatsFinaux = (float)(this.Force * reduction);
            if (degatsFinaux <= 0) degatsFinaux = 1;
            if (cible.Esquive == 1 && cible.Esquive == MoteurAleatoire.Random10())
            {
                OnEsquiver?.Invoke(this,cible);
                return;
            }
            else if(cible.Esquive == 2 && cible.Esquive == MoteurAleatoire.Random5())
            {
                OnEsquiver?.Invoke(this,cible);
                return;
            }
            if(this.Speed == 2)
            {
                degatsFinaux = degatsFinaux * 2 ;
                OnSpeed?.Invoke(this,cible);
            }
            degatsFinaux = (int)Math.Max(1, degatsFinaux);
            OnAttaquer?.Invoke(this,cible,degatsFinaux);
            cible.PV -= degatsFinaux;
            
            

        }
        else 
        {

            // Déplacement horizontal
            if (this.X < cible.X) this.X++;
            else if (this.X > cible.X) this.X--;

            // Déplacement vertical
            if (this.Y < cible.Y) this.Y++;
            else if (this.Y > cible.Y) this.Y--;
            OnAvancer?.Invoke(this,cible);

        }
    }

    public Champion? TrouverCibleLaPlusProche(List<Champion> ennemis)
    {
        if (ennemis == null || ennemis.Count == 0) return null;

        Champion? cibleLaPlusProche = null;
        double distanceMin = double.MaxValue;

        foreach (var ennemi in ennemis)
        {
            if (ennemi.EstMort) continue; // On ignore les cadavres

            int dx = ennemi.X - this.X;
            int dy = ennemi.Y - this.Y;
            double distance = (dx * dx) + (dy * dy);

            if (distance < distanceMin)
            {
                distanceMin = distance;
                cibleLaPlusProche = ennemi;
            }
        }

        return cibleLaPlusProche;
    }


    //methode a mettre dans joueur dans le futur peut etre 

}