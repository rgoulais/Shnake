using System.Numerics;
using Raylib_cs;
using Shnake.Map;

namespace Shnake.Objects;

public abstract class BaseObject(TileMap tileMap, Position position, Texture2D texture)
{
    protected TileMap TileMap { get; private set; } = tileMap;
    public Position Position { get; protected set; } = position;
    protected Texture2D Texture { get; set; } = texture;

    public abstract void Update(float deltaTime);
    public virtual void Draw(Vector2 position)
    {
        Rectangle rect = new Rectangle(0, 0, 48, 48);
        Raylib.DrawTextureRec(Texture, rect, position, Color.White);
    }
}