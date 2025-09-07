using Shnake.Map;
using Shnake.Services;

namespace Shnake.Objects;

public class Bags(TileMap tileMap, Position position) : BaseObject(tileMap, position,
    SpriteManager.Instance.GetTexture(Sprite.Trash1))
{
    public override void Update(float deltaTime)
    {
        if (Position == TileMap.Player.Position)
        {
            AudioManager.Instance.PlaySound(SoundEffect.UiKeypadConfirmed);
            GameController.Instance.CurrentLife += 1;
            TileMap.Objects.Remove(this);
        }
    }
}