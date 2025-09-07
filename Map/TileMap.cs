using System.Numerics;
using Raylib_cs;
using Shnake.Objects;
using Shnake.Services;

namespace Shnake.Map;

public class TileMap
{
    public List<BaseObject> Objects { get; } = new();
    public readonly Player Player;
    private readonly int _rows;
    private readonly int _columns;

    public TileMap(int rows, int columns)
    {
        Player = new Player(this, new Position(rows / 2, columns / 2));
        Objects.Add(Player);
        _rows = rows;
        _columns = columns;
        for (int i = 0; i < _rows; i++)
        {
            Objects.Add(new Wall(this, new Position(i, 0)));
            Objects.Add(new Wall(this, new Position(i, _columns - 1)));
        }

        for (int i = 0; i < _columns; i++)
        {
            Objects.Add(new Wall(this, new Position(0, i)));
            Objects.Add(new Wall(this, new Position(_rows - 1, i)));
        }
    }

    public void Update(float deltaTime)
    {
        for (int i = Objects.Count - 1; i >= 0; i--)
        {
            var obj = Objects[i];
            obj.Update(deltaTime);
        }
    }

    public void Draw()
    {
        foreach (var baseObject in Objects)
        {
            var position = GetWorldPosition(baseObject.Position);
            if (IsInBounds(position))
                baseObject.Draw(position);
        }
    }

    private Vector2 GetWorldPosition(Position position)
    {
        int x = (position.Col - Player.Position.Col + GameController.OffsetX) * GameController.CellSize;
        int y = (position.Row - Player.Position.Row + GameController.OffsetY) * GameController.CellSize;
        return new Vector2(x, y);
    }

    private static bool IsInBounds(Vector2 position)
    {
        return position.X is >= 0 and <= 1600 && position.Y is >= 0 and <= 800;
    }

    private Position GetRandomPosition()
    {
        return new Position(Raylib.GetRandomValue(1, _rows - 2), Raylib.GetRandomValue(1, _columns - 2));
    }

    public void AddSoda()
    {
        var pos = GetRandomPosition();
        foreach (var baseObject in Objects)
        {
            if (baseObject.Position == pos)
                return;
        }

        Objects.Add(new Soda(this, pos));
    }

    public void AddBags()
    {
        var pos = GetRandomPosition();
        foreach (var baseObject in Objects)
        {
            if (baseObject.Position == pos)
                return;
        }

        Objects.Add(new Bags(this, pos));
    }
}