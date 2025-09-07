using Raylib_cs;

namespace Shnake.Services;

public class SpriteManager : IService
{
    public static SpriteManager Instance { get; } = new();

    private readonly Dictionary<Sprite, Texture2D> _textures = new();

    private SpriteManager()
    {
        ShutdownManager.RegisterService(this);
        foreach (var sprite in Enum.GetValues<Sprite>())
        {
            Texture2D texture = Raylib.LoadTexture(sprite.GetPath());
            _textures.Add(sprite, texture);
        }
    }

    public Texture2D GetTexture(Sprite sprite)
    {
        return _textures[sprite];
    }


    public void Unload()
    {
        foreach (var texture in _textures.Values)
        {
            Raylib.UnloadTexture(texture);
        }
    }
}