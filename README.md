# ShipManagment
Simple type Gestion des navires : Projet test

Dans ce projet test, vous trouverez :
* Le tableau d'affichage des navires
* L'ajout, la modification et la suppression d'un navire
* L'authentification bearer avec token jwt transmis à chaque requête. Il faut un user/password pour s'authentifier pour la première connexion.

# Getting started
Pour faire fonctionner le projet il faut :
1- Créer la base de donnée SQL Server avec la commande : __dotnet ef database update --project ShipManagement.Infrastructure --startup-project ShipManagment.Api__
cette commande va créer la BD, l'initialiser avec des seedData prévues.

2- Lancer le projet API dans Visual Studio

3- faire __npm install__ dans le projet web (visual studio code)

4-  Lancer le projet web  avec : __npm start__

5. Tester le site avec ce user : __username :  Roland@gmail.com     Password : roTest123__

## Installation
 
* .Net core SDK installé sur votre ordinateur (pour ceux qui utilisent le CLI) ou visual 2022 à jour avec la version .net 7.
* dotnet ef installé globalement sur le poste développeur via cette commande : dotnet tool install --global dotnet-ef lire plus à ce sujet https://learn.microsoft.com/en-us/ef/core/get-started/overview/install

## Initialisation de la BD

commandes pour initialiser la base de données.

* Appliquer le script de migration : ___dotnet ef database update --project ShipManagement.Infrastructure --startup-project ShipManagment.Api___
* La Base de donnée est créée automatiquement. Nom BD =ShipManagementDB

#### Générer un nouveau script base de donnée de migration (Nécessaire que si vous modifier le projet).

Au besoin si le modèle change, il faut recréer une migration : ___dotnet ef migrations add InitDB --project ShipManagement.Infrastructure --startup-project ShipManagment.Api___


# Authentification
Dans ce projet, j'utilise l'Authentification bearer avec un token jwt.
Les données de tests (Manager, et ship) sont dans le projet ShipManagement.Infrastructure dans la partie Configuration.

# Test de l'Api
J'ai intégré swagger pour faciliter les tests des endpoints.

Merci.
