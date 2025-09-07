using Shnake.Helpers;

namespace Shnake.Map;

public class Position(int row, int col)
{
    public readonly int Row = row;
    public readonly int Col = col;

    public Position Move(KeyboardHelper.Direction direction)
    {
        
        if (direction == KeyboardHelper.Direction.Top)
            return new Position(Row - 1, Col);
        if (direction == KeyboardHelper.Direction.Bottom)
            return new Position(Row + 1, Col);
        if (direction == KeyboardHelper.Direction.Left)
            return new Position(Row, Col - 1);
        if (direction == KeyboardHelper.Direction.Right)
            return new Position(Row, Col + 1);
        return this;
    }
    
    public static bool operator ==(Position a, Position b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(Position a, Position b)
    {
        return !a.Equals(b);
    }
    public override bool Equals(object? obj)
    {
        return obj is Position position &&
               Row == position.Row &&
               Col == position.Col;
    }

    private bool Equals(Position other)
    {
        return Row == other.Row && Col == other.Col;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Row, Col);
    }
}