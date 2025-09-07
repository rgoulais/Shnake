using System.Numerics;
using Raylib_cs;
using Shnake.Helpers;
using Shnake.Map;
using Shnake.Services;

namespace Shnake.Objects;

public class Dog(TileMap tileMap, Position position)
    : AnimatedObject(6, tileMap, position, SpriteManager.Instance.GetTexture(Sprite.Chien))
{
    private KeyboardHelper.Direction _direction = KeyboardHelper.Direction.Right;

    public override void Draw(Vector2 position)
    {
        int x = 96 * 6 * (int)_direction + 96 * CurrentFrame;
        Rectangle rect = new Rectangle(x, 390, 96, 96);
        Rectangle rect2 = new Rectangle(position.X, position.Y, 48, 48);
        var origin = new Vector2(0, 0);
        Raylib.DrawTexturePro(Texture, rect, rect2, origin, 0, Color.White);
    }

    public void Move(Position position, KeyboardHelper.Direction direction)
    {
        TileMap.Objects.Add(new Poo(TileMap, Position));
        Position = position;
        _direction = direction;
    }
    
}