# Shnake

Shnake est un petit jeu d’arcade inspiré de Snake.

## Objectifs du projet
- Implémenter le jeu en C# / Raylib_cs.
- Définir les conditions de victoire ou de défaite du jeu
  - La victoire est symbolisée par le score maximal conservée d'une partie à l'autre
    dans la même session de jeu.
  - La défaite est déclenchée par la collision avec un buisson ou une crotte de chien.
- Mettre en oeuvre une architecture orientée objet
- Découper le jeu en plusieurs scènes

## Fonctionnalités
- Boucle de jeu classique (initialisation, update avec delta time, draw).
- Gestion centralisée de l’état de la partie (score, meilleure performance, difficulté, vitesse, vies).
- Système de scènes (menu, jeu, écran fin de partie).
- Gestion audio séparée.
- Nettoyage des ressources et arrêt propre des services à la fermeture.
- Mise en oeuvre de power-ups (Poches à crottes qui permettent de passer
  sur ses propres traces, Soda qui augmente la vitesse du joueur).

## Choix de conception et architecture

### Organisation du code
- Un gestionnaire de scènes orchestre la navigation.
- Un gestionnaire d'assets permet de charger les ressources.
- Les services sont exposés via des singletons.
- Un gestionnaire de fermeture (shutdown) centralise la libération des ressources en fin d’exécution.

### Grille et rendu
- Le jeu utilise une grille (taille de cellule constante) pour la logique et le rendu.
- Des offsets prédéfinis aident à aligner le monde logique avec la fenêtre.
- Le joueur est au centre de l'écran en permanence.

## Prérequis
- .NET SDK 9.0
- Raylib_cs (runtimes natifs fournis par le paquet Raylib ou installés selon votre OS)
- Un OS supporté par Raylib (Windows, Linux, macOS)

## Compilation et exécution
- Depuis la ligne de commande:
    - dotnet restore
    - dotnet build -c Release
    - dotnet run
- Assurez-vous que les dépendances natives de Raylib sont disponibles pour votre plateforme (le paquet NuGet s’en charge généralement).

## Contrôles
- Contrôles clavier “classiques” (flèches/ZQSD/WASD) et Space / Enter.

## TODO List
- Persistance du High Score (fichier local ou stockage multiplateforme).
- Système de configuration (résolution, contrôles, audio).
- Effets visuels et sonores additionnels.
- Ajout d'objets supplémentaires.
- Écrans: pause, options, crédits.
- Tests unitaires ...
