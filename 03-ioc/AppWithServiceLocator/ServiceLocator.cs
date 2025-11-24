using System.Collections.Generic;

namespace AppWithServiceLocator;

internal static class ServiceLocator
{
    private static readonly Dictionary<Type, object> _services = [];

    public static void AddService<T>(T service)
        where T : notnull
    {
        _services[typeof(T)] = service;
    }

    public static T? GetService<T>()
    {
        return _services.TryGetValue(typeof(T), out var service) ? (T)service : default;
    }
}