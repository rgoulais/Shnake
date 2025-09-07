namespace Shnake.Helpers;

// Utilisée pour lancer des actions à intervalles réguliers
public class IntervalAction(Action action, float interval)
{
    private float _currentTime;

    public void Update(float deltaTime)
    {
        _currentTime += deltaTime;
        if (_currentTime < interval)
            return;
        _currentTime = 0f;
        action();
    }
}