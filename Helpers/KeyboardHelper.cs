using Raylib_cs;

namespace Shnake.Helpers;

public static class KeyboardHelper
{
    public enum Direction
    {
        Right,
        Top,
        Left,
        Bottom,
        None
    }

    public static Direction GetDirection()
    {
        // AZERTY et QWERTY Friendly ...
        if (Raylib.IsKeyDown(KeyboardKey.W) || Raylib.IsKeyDown(KeyboardKey.Z) || Raylib.IsKeyDown(KeyboardKey.Up))
            return Direction.Top;
        if (Raylib.IsKeyDown(KeyboardKey.S)|| Raylib.IsKeyDown(KeyboardKey.Down))
            return Direction.Bottom;
        if (Raylib.IsKeyDown(KeyboardKey.A)|| Raylib.IsKeyDown(KeyboardKey.Q)|| Raylib.IsKeyDown(KeyboardKey.Left))
            return Direction.Left;
        if (Raylib.IsKeyDown(KeyboardKey.D)|| Raylib.IsKeyDown(KeyboardKey.Right))
            return Direction.Right;
        return Direction.None;
    }
    
    public static bool Action()
    {
        // KeyPressed pour éviter que les enchainements malheureux
        return Raylib.IsKeyPressed(KeyboardKey.Space) || Raylib.IsKeyPressed(KeyboardKey.Enter);
    }
}