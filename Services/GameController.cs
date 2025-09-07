namespace Shnake.Services;

public class GameController : IService
{
    public static GameController Instance { get; } = new();

    private const int DifficultyMax = 6;
    public const int CellSize = 48;
    public const int WindowWith = 1600;
    public const int WindowHeight = 800;
    public const int OffsetX = WindowWith / 2 / CellSize;
    public const int OffsetY = WindowHeight / 2 / CellSize;
    public int Difficulty { get; private set; } = 1;
    public int CurrentScore { get; private set; }
    public int CurrentLife { get; set; }
    public float CurrentSpeed { get; set; } = 1f;
    public int HighScore { get; private set; }

    private GameController()
    {
        ShutdownManager.RegisterService(this);
    }

    public void InitLevel()
    {
        CurrentScore = 0;
        CurrentSpeed = 1f / Difficulty;
        CurrentLife = 0;
    }

    public void Unload()
    {
    }

    public void DecreaseDifficulty()
    {
        Difficulty = int.Max(Difficulty - 1, 1);
    }

    public void IncreaseDifficulty()
    {
        Difficulty = int.Min(Difficulty + 1, DifficultyMax);
    }

    public bool IsGameOver()
    {
        return CurrentLife < 0;
    }

    public void IncreaseScore(int i)
    {
        CurrentScore += i;
        if (CurrentScore > HighScore)
            HighScore = CurrentScore;
    }
}