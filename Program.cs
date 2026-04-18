Lulu lulu = new Lulu();
Ashe ashe = new Ashe();

lulu.resourceBar.AfficherResourceBar();

Map map = new Map();
Shop shop = new Shop();


lulu.X = 3;
lulu.Y = 3;

ashe.X = 4;
ashe.Y = 4;
//test pour voir si la map fonctionne bien 
map.PlaceChampion(lulu,lulu.X,lulu.Y);
map.PlaceChampion(ashe ,ashe.X,ashe.Y);
map.display();

Console.Write(GameManager.nbElfe);

shop.displayShop();


try 
{
    // On tente l'achat
    shop.acheterChampion(map.Banc, 1,map);
}
catch (GameFundsException ex)
{
    // Si ça échoue pour l'argent, on affiche juste le message sans crasher
    Console.WriteLine($"Achat annulé : {ex.Message}");
}
catch (GameRuleException ex)
{
    // Si ça échoue pour le banc plein
    Console.WriteLine($"Achat annulé : {ex.Message}");
}
map.Banc.displayBanc();
Console.WriteLine(ashe.Speed);

Console.WriteLine("coucou");

Lulu l1 = new Lulu(); 
Lulu l2 = new Lulu(); 
Lulu l3 = new Lulu();

// 2. Tu les AJOUTES au banc (sinon la fusion ne verra rien)
map.Banc.ListeChampionBanc.Add(l1);
map.Banc.ListeChampionBanc.Add(l2);
map.Banc.ListeChampionBanc.Add(l3);

// 3. Tu lances la fusion manuellement sur l'une d'entre elles
Fusion.fusionnerChampion(l3, map.ListeChampion, map.Banc.ListeChampionBanc, map, map.Banc);
Console.WriteLine($"{l2.Nv}");
Console.WriteLine($"{l1.Nv}");
Console.WriteLine($"{l3.Nv}");



Console.WriteLine("\n--- TEST DE FUSION MANUELLE ---");
// 1. On vide le banc pour partir sur une base propre
map.Banc.ListeChampionBanc.Clear();

// 2. On crée nos 3 cobayes
Lulu test1 = new Lulu(); 
Lulu test2 = new Lulu(); 
Lulu test3 = new Lulu();

map.Banc.ListeChampionBanc.Add(test1);
map.Banc.ListeChampionBanc.Add(test2);
map.Banc.ListeChampionBanc.Add(test3);

// 3. On déclenche
Fusion.fusionnerChampion(test3, map.ListeChampion, map.Banc.ListeChampionBanc, map, map.Banc);

// 4. On vérifie QUI est resté
Console.WriteLine($"Nombre de champions sur le banc après fusion : {map.Banc.ListeChampionBanc.Count}");
if(map.Banc.ListeChampionBanc.Count > 0)
{
    Console.WriteLine($"Niveau du survivant : {map.Banc.ListeChampionBanc[0].Nv}");
    Console.WriteLine($"Nom du survivant : {map.Banc.ListeChampionBanc[0].Nom}");
    Console.WriteLine($"{map.Banc.ListeChampionBanc[0].PV}");
    Console.WriteLine($"{map.Banc.ListeChampionBanc[0].Force}");

    
}