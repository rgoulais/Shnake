namespace Shnake.Scenes;

public abstract class AbstractScene
{
    public virtual void Load()
    {
    }

    public virtual void Unload()
    {
    }

    public abstract void Update(float deltaTime);

    public abstract void Draw();
}