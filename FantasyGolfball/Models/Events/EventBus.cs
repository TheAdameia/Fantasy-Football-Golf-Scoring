namespace FantasyGolfball.Models.Events;


public interface IEventBus
{
    void Subscribe<T>(Func<T, Task> handler);
    Task Publish<T>(T eventData);
}

public class EventBus : IEventBus
{
    private readonly Dictionary<Type, List<Delegate>> _handlers = new();

    public void Subscribe<T>(Func<T, Task> handler)
    {
        if (!_handlers.ContainsKey(typeof(T)))
        {
            _handlers[typeof(T)] = new List<Delegate>();
        }
        _handlers[typeof(T)].Add(handler);

        Console.WriteLine($"EventBus: Subscribed to event of type {typeof(T).Name}");
    }

    public async Task Publish<T>(T eventData)
    {
        if (_handlers.TryGetValue(typeof(T), out var handlers))
        {
            foreach (var handler in handlers)
            {
                if (handler is Func<T, Task> asyncHandler)
                {
                    await asyncHandler(eventData);
                }
            }
        }
    }
}