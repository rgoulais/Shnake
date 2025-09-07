using System.Numerics;
using Raylib_cs;
using Shnake.Helpers;
using Shnake.Map;
using Shnake.Services;

namespace Shnake.Objects;

public class Player : AnimatedObject
{
    private KeyboardHelper.Direction _direction = KeyboardHelper.Direction.Right;
    private readonly Dog _dog;
    private float _lastMoveTime;
    public Player(TileMap tileMap, Position position) : base(6, tileMap, position, SpriteManager.Instance.GetTexture(Sprite.Personnage))
    {
        _dog = new Dog(tileMap, position.Move(KeyboardHelper.Direction.Left));
        tileMap.Objects.Add(_dog);
    }

    public override void Update(float deltaTime)
    {
        base.Update(deltaTime);
        if (KeyboardHelper.GetDirection() != KeyboardHelper.Direction.None )
        {
            _direction = KeyboardHelper.GetDirection();
        }
        _lastMoveTime += deltaTime;
        if (_lastMoveTime > GameController.Instance.CurrentSpeed)
        {
            var oldPosition = Position;
            Position = oldPosition.Move(_direction);
            _dog.Move(oldPosition, _direction);
            _lastMoveTime = 0;
            GameController.Instance.IncreaseScore(1);
        }
    }

    public override void Draw(Vector2 position)
    {
        int x = 48 * 6 * (int)_direction + 48 * CurrentFrame;
        Rectangle rect = new Rectangle(x, 2*96, 48, 96);
        Rectangle rect2 = new Rectangle(position.X + 8, position.Y - 16, 32, 64);
        var origin = new Vector2(0, 0);
        Raylib.DrawTexturePro(Texture, rect, rect2, origin, 0, Color.White);
        Raylib.DrawText("Score: " + GameController.Instance.CurrentScore, 10, 10, 20, Color.White);
        Raylib.DrawText("Poches à crottes: " + GameController.Instance.CurrentLife, 10, 30, 20, Color.White);
    }
}