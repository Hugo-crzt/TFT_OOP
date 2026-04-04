public abstract class Champion
{
    public string Nom{get; set;}
    public int Force{get; set;}
    protected int _PV;

    public int Nv{get; set;}


    public int ChampionsCost{get; set;}

    public int portée{get; set;}

    public int degat{get; set;}

    public int X{get; set;} //gerer les coordonnées du joueur
    public int Y{get; set;}

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

    public Champion(string nom, int force, int pv)
    {
        this.Nom = nom;
        this.Force = force;
        this.PV = pv;
        this.Nv = 1;
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
        int portee = this.portée * this.portée; //on met tout au carré pour eviter l'operation avec la racine 
        if (distance <= portee)
        {
            int degat;
            if(Nv ==1)
            {
                this.degat = Force;
            }
            else if (Nv == 2)
            {
                this.degat = 2*Force;

            }
            else if (Nv == 3)
            {
                this.degat = 10*Force;
            }
            Console.WriteLine($"{this.Nom} attaque violemment {cible.Nom}et lui inflige {this.degat} dégats" );
            cible.PV -= this.degat;
        }
    }



}