using Raylib_cs;
using Shnake.Helpers;
using Shnake.Services;

namespace Shnake.Scenes;

public class MenuScene : AbstractScene
{
    
    private float _lastMoveTime;
    private const float MaxMoveTime = 0.3f;
    private const int XOffset = 600;
    private const int YOffset = 100;

    public override void Load()
    {
        AudioManager.Instance.PlayMusic(Musique.MusicMagicalForest);
    }

    public override void Update(float deltaTime)
    {
        _lastMoveTime += deltaTime;
        if (KeyboardHelper.Action())
        {
            SceneManager.Instance.Load<GameScene>();
        }
        else
        {
            switch (KeyboardHelper.GetDirection())
            {
                case KeyboardHelper.Direction.None:
                    _lastMoveTime = MaxMoveTime;
                    break;
                case KeyboardHelper.Direction.Top:
                    if (_lastMoveTime > MaxMoveTime)
                    {
                        GameController.Instance.DecreaseDifficulty();
                        _lastMoveTime = 0;
                    }                    break;
                case KeyboardHelper.Direction.Bottom:
                    if (_lastMoveTime > MaxMoveTime)
                    {
                        GameController.Instance.IncreaseDifficulty();
                        _lastMoveTime = 0;
                    }  
                    break;
            }
        }
    }

    public override void Draw()
    {
        Raylib.ClearBackground(Color.DarkGreen);
        DrawMenuElement("Niveau Les doigts dans le nez", 1);
        DrawMenuElement("Niveau Facile", 2);
        DrawMenuElement("Niveau Moyen", 3);
        DrawMenuElement("Niveau Difficile", 4);
        DrawMenuElement("Niveau Cauchemar", 5);
        DrawMenuElement("Niveau Enfer", 6);
        Raylib.DrawText("Musique et sons par ElvGames & Pegonthetrack", 50, 750, 20, Color.LightGray);
        Raylib.DrawText("Graphismes par Limezu https://limezu.itch.io", 1050, 750, 20, Color.LightGray);
        Raylib.DrawText("HighScore : " + GameController.Instance.HighScore, 1200, 50, 40, Color.Gold);
    }

    private void DrawMenuElement(string text, int difficulty)
    {
        if (difficulty == GameController.Instance.Difficulty)
        {
            Raylib.DrawText(">>>", XOffset - 50, YOffset + difficulty * 50, 24, Color.White);
            Raylib.DrawText(text, XOffset, YOffset + difficulty * 50, 24, Color.White);
            
        } else
        {
            Raylib.DrawText(text, XOffset, YOffset + difficulty * 50, 20, Color.LightGray);
        }
    }
}