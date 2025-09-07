using Raylib_cs;
using Shnake.Map;

namespace Shnake.Objects;

public abstract class AnimatedObject(int frameCount, TileMap tileMap, Position position, Texture2D texture)
    : BaseObject(tileMap, position, texture)
{
    protected int CurrentFrame;
    private readonly float _frameDuration = 0.2f;
    private float _lastFrameTime;

    public override void Update(float deltaTime)
    {
        _lastFrameTime += deltaTime;
        if (_lastFrameTime < _frameDuration)
            return;
        _lastFrameTime -= _frameDuration;
        CurrentFrame++;
        if (CurrentFrame >= frameCount)
            CurrentFrame = 0;
    }
    
}