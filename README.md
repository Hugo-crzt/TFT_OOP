** TFT Console Edition - C#
Bienvenue dans cette version simplifiée et optimisée de Teamfight Tactics, développée entièrement en C# pour le terminal. Gérez votre économie, placez vos unités et devenez le dernier survivant !

** Déroulement de la partie

*1. Initialisation

  Chaque joueur (vous et l'IA) débute avec 100 PV.
  
  Un champion aléatoire vous est attribué au départ.
  
  Vous devez le placer sur le terrain avant de lancer votre premier affrontement.
  
*2. Phase de Préparation & Boutique

  C'est le moment de bâtir votre stratégie. 5 champions sont proposés aléatoirement dans le shop :
  
  Achat : Utilisez votre or pour recruter des unités.
  
  Vente : Vous pouvez revendre vos champions (à condition d'en garder au moins un).
  
  Refresh : Si la sélection ne vous convient pas, vous pouvez rafraîchir la boutique.
  
  Statistiques : Appuyez sur la touche C pour analyser les forces, faiblesses et Origines de vos troupes.

*3. Phase de Combat

  Les combats sont automatiques. L'issue dépend de vos statistiques et de votre placement :
  
  Victoire : Vous infligez des dégâts à l'adversaire et gagnez un montant d'or important.
  
  Défaite : Vous gagnez un montant d'or réduit et perdez des PV selon le nombre d'unités ennemies encore en vie.

** Mécaniques Avancées

* Système de Fusion : Obtenez trois exemplaires du même champion et du même niveau pour qu'ils fusionnent automatiquement. Le champion résultant monte en niveau (Star Level) et voit ses statistiques boostées.

* Système de Butin (Loot) : À chaque victoire, vous avez une chance de gagner un objet. Équipez-le sur vos champions pour leur donner un avantage décisif.

* Synergies d'Origines : Regroupez des personnages de la même origine pour débloquer des bonus passifs cumulables.

* Conseils Tactiques
  Le Placement est la clé :
  
  Placez vos Tanks (Guard) en première ligne pour encaisser les dégâts.
  
  Protégez vos Snipers (Marksman) et Mages (Wizard) à l'arrière pour qu'ils puissent attaquer en toute sécurité.

* Installation et Lancement
Clonez le dépôt.

Ouvrez le projet dans Visual Studio ou VS Code.

Compilez et lancez le projet :

Bash
dotnet run
Suivez les instructions affichées dans le terminal.

Projet réalisé par Crouzet Hugo.
