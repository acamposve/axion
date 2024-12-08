using MediatR;

namespace AxionApi.Domain.Events;

public interface IDomainEvent : INotification
{
    /// <summary>
    /// Gets the event identifier.
    /// </summary>
    Guid EventId { get; }

    /// <summary>
    /// Gets the UTC date and time the event occurred on.
    /// </summary>
    DateTime OccurredOnUtc { get; }
}
