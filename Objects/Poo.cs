using System.Numerics;
using Raylib_cs;
using Shnake.Map;
using Shnake.Services;

namespace Shnake.Objects;

public class Poo(TileMap tileMap, Position position)
    : BaseObject(tileMap, position, SpriteManager.Instance.GetTexture(Sprite.Props4))
{
    private float _timeToLive = 10f;

    public override void Update(float deltaTime)
    {
        _timeToLive -= deltaTime;
        if (_timeToLive <= 0)
            TileMap.Objects.Remove(this);
        if (Position == TileMap.Player.Position)
        {
            AudioManager.Instance.PlaySound(SoundEffect.UiButtonClick2);

            GameController.Instance.CurrentLife -= 1;
            TileMap.Objects.Remove(this);
        }

    }

    public override void Draw(Vector2 position)
    {
        Rectangle rect = new Rectangle(0, 0, 48, 48);
        Raylib.DrawTextureRec(Texture, rect, position, Color.DarkBrown);
    }
}