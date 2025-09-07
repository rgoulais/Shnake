using Raylib_cs;
using Shnake.Map;
using Shnake.Services;

namespace Shnake.Objects;

public class AbstractSolidObject(TileMap tileMap, Position position, Texture2D texture)
    : BaseObject(tileMap, position, texture)
{
    public override void Update(float deltaTime)
    {
        if (Position != TileMap.Player.Position)
            return;
        AudioManager.Instance.PlaySound(SoundEffect.UiKeypadError);
        GameController.Instance.CurrentLife = -1;
    }
}