namespace GuessTheNumber.Kafka.Interfaces
{
    using System.Threading.Tasks;

    public interface IEventHandler<TKey, TValue>
        where TValue : IEvent
    {
        Task HandleAsync(TKey key, TValue @event);
    }
}