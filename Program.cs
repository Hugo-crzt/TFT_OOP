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
    shop.acheterChampion(map.Banc, 1);
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