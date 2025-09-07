using Raylib_cs;
using Shnake.Helpers;
using Shnake.Services;

namespace Shnake.Scenes;

public class GameOverScene : AbstractScene
{
    public override void Update(float deltaTime)
    {
        if (KeyboardHelper.Action())
            SceneManager.Instance.Load<MenuScene>();
    }

    public override void Draw()
    {
        Raylib.ClearBackground(Color.Red);
        Raylib.DrawText("Game Over", 670, 300, 30, Color.White);
    }
}