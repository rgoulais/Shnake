using Shnake.Map;
using Shnake.Services;

namespace Shnake.Objects;

public class Soda(TileMap tileMap, Position position) : BaseObject(tileMap, position,
    SpriteManager.Instance.GetTexture(Sprite.Bottle3))
{
    public override void Update(float deltaTime)
    {
        if (Position == TileMap.Player.Position)
        {
            AudioManager.Instance.PlaySound(SoundEffect.UiButtonClick1);
            GameController.Instance.CurrentSpeed *= 0.9f;
            TileMap.Objects.Remove(this);
        }
        
    }
}