# EnvNetTp3
TP3 webApp
Dans le cadre la cour de environnement.net nous avions réalisé un TP en C# qui consistait à reprendre un projet d'un site de vente en ligne de livres entre particuliers une ébauche de projet nous était proposé et récupéré sur guide nous devions examiner ce qui a été fait et compléter. Pour ma part je n'avais jamais travaillé en C# mais nous avions eu la cour plutôt bien fait et les explications sur internet ne manquent pas. L’objectif était d'utiliser le framework entity framework de Microsoft pour réaliser le modèle de la base de données générer cette base c'est la première fois que j'utilisais un ORM. Cela m'a pris beaucoup de temps j'ai dû lire toute la documentation Microsoft sur le sujet et du site réservé à entity framework. Je n'ai pas de mal à vous l'expliquer puisque j'avais noté tout ce que j'avais fait bien commenter mon code et le résultat était plutôt fonctionnel. 
Voici l'énoncé en quelques mots :
Gestion d'une connexion utilisateur
Un vendeur vend ses livres
Un acheteur peut parcourir une liste de livres et faire un recherche selon les critères suivants : nom| nombre de pages| prix| vendeur détenant actuellement les livres.

Créer avec MVC5 les éléments du CRUD pour les entités book rôle et user
Créer avec MVC5 les vues permettant de :
-	Sélectionner un utilisateur
-	Chercher des livres appartenant au « vendeur » par des critères :
      - Le nom contient une valeur
      - Nombre de pages égal ou inférieur et ou supérieur à une valeur le prix est inférieur supérieur ou entre une valeur
        - La vue de recherche de livre doit utiliser les cards(balises)
        - une balise carte pour représenter l'ensemble des informations des livres
