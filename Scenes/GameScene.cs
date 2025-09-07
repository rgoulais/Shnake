using Raylib_cs;
using Shnake.Helpers;
using Shnake.Map;
using Shnake.Services;

namespace Shnake.Scenes;

public class GameScene : AbstractScene
{
    private readonly List<IntervalAction> _intervalActions = [];
    private readonly TileMap _tileMap = new(40, 30);

    public override void Load()
    {
        AudioManager.Instance.PlayMusic(Musique.MusicChickenParty);
        GameController.Instance.InitLevel();
        _intervalActions.Add(new IntervalAction(_tileMap.AddBags, 10));
        _intervalActions.Add(new IntervalAction(_tileMap.AddSoda, 5));
    }

    public override void Update(float dt)
    {
        foreach (var obj in _intervalActions)
            obj.Update(dt);
        _tileMap.Update(dt);
        foreach (var intervalAction in _intervalActions)
            intervalAction.Update(dt);
        if (GameController.Instance.IsGameOver())
            SceneManager.Instance.Load<GameOverScene>();
    }

    public override void Draw()
    {
        Raylib.ClearBackground(Color.DarkGreen);
        _tileMap.Draw();
    }
}