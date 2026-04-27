
public interface IConsommable
{
    string Nom { get; } // Cette ligne permet au Program.cs de lire le nom
    void Consommer(Champion cible){}
}