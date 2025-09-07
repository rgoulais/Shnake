using Shnake.Scenes;

namespace Shnake.Services;

public class SceneManager : IService
{
    public static SceneManager Instance { get; } = new();

    private AbstractScene? _currentScene;

    private SceneManager()
    {
        ShutdownManager.RegisterService(this);
        Load<MenuScene>();
    }

    public void Load<T>() where T : AbstractScene, new()
    {
        _currentScene?.Unload();
        _currentScene = new T();
        _currentScene.Load();
    }

    public void Draw()
    {
        _currentScene?.Draw();
    }

    public void Update(float deltaTime)
    {
        _currentScene?.Update(deltaTime);
    }

    public void Unload()
    {
        _currentScene?.Unload();
        _currentScene = null;
    }
}