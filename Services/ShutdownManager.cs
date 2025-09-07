namespace Shnake.Services;

public static class ShutdownManager
{
    private static readonly Dictionary<Type, IService> Services = new();

    public static void RegisterService<T>(T service) where T : IService
    {
        Services.Add(typeof(T), service);
    }

    public static void UnloadAll()
    {
        foreach (var service in Services.Values)
        {
            service.Unload();
        }
    }
}