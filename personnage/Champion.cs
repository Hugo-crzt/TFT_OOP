public abstract class Champion
{
    public string Nom{get; set;}
    public int Force{get; set;}
    protected int _PV;
    public int Nv{get; set;}
    public int Defense;
    public int ChampionsCost{get; set;}
    public int Portée{get; set;}
    public int Degat{get; set;}
    public int X{get; set;} //gerer les coordonnées du joueur
    public int Y{get; set;}
    public ResourceBar resourceBar {get;set;}


    public Origin Origine{get;set;}
    public int PV
    {
        get {return _PV ;}
        set
        {
            if(value < 0)
            {
                _PV = 0 ; 
                Console.WriteLine("le personnage est ko");
            }
            else
            {
                _PV = value;
            }
        }
    }

    public Champion(string nom, int force, int pv, int defense,int cost,Origin origine,int portée)
    {
        this.Nom = nom;
        this.Force = force;
        this.PV = pv;
        this.Nv = 1;
        this.Defense= defense;
        this.ChampionsCost = cost;
        this.Portée = portée;
        this.Origine = origine;
    }
    public bool EstMort
    {
        get{
            if (this._PV <= 0){
                return true;
            } 
            else
            {
                return false;
            }
        }
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
    public virtual void CompetencesClass(Champion cible)
    {
    }


}