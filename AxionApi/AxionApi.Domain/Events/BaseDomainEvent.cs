namespace AxionApi.Domain.Events;

public abstract class BaseDomainEvent : IDomainEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseDomainEvent"/> class.
    /// </summary>
    protected internal BaseDomainEvent()
    {
        EventId = Guid.NewGuid();
        OccurredOnUtc = DateTime.UtcNow;
    }

    /// <inheritdoc />
    public Guid EventId { get; }

    /// <inheritdoc />
    public virtual DateTime OccurredOnUtc { get; }
}
