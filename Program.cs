using Raylib_cs;
using Shnake.Services;

namespace Shnake;

public static class Program
{
    public static void Main()
    {
        // Initialisation de la fenêtre
        Raylib.InitWindow(GameController.WindowWith, GameController.WindowHeight, "Shnake");

        // Définir le taux de rafraîchissement (facultatif)
        Raylib.SetTargetFPS(60);

        // Boucle principale du jeu
        while (!Raylib.WindowShouldClose())
        {
            var dt = Raylib.GetFrameTime();
            // Mise à jour (logique du jeu ici)
            SceneManager.Instance.Update(dt);
            AudioManager.Instance.Update();
            // Dessin
            Raylib.BeginDrawing();
            SceneManager.Instance.Draw();
            Raylib.EndDrawing();
        }
        ShutdownManager.UnloadAll();
        // Fermeture de la fenêtre
        Raylib.CloseWindow();
    }
}