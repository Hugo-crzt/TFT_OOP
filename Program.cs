Lulu lulu = new Lulu();
lulu.resourceBar.AfficherResourceBar();


Garen garen = new Garen();
garen.resourceBar.AfficherResourceBar();

Map map = new Map();


lulu.X = 3;
lulu.Y = 3;
//test pour voir si la map fonctionne bien 
map.PlaceChampion(lulu,lulu.X,lulu.Y);
map.display();

Console.Write(GameManager.nbNinja);