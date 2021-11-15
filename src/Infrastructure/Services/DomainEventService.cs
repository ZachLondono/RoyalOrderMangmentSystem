using RoyalOrderManager.Application.Common.Interfaces;
using RoyalOrderManager.Domain.Common;

using MediatR;

using Microsoft.Extensions.Logging;
using RoyalOrderManager.Application.Common.Models;

namespace RoyalOrderManager.Infrastructure.Services;

internal class DomainEventService : IDomainEventService {

    public readonly ILogger<DomainEventService> _logger;
    public readonly IPublisher _publisher;

    public DomainEventService(ILogger<DomainEventService> logger, IPublisher publisher) {
        _logger = logger;
        _publisher = publisher;
    }

    public async Task Publish(DomainEvent domainEvent) {
        _logger.LogInformation("Publishing domain event. Event - {event}", domainEvent.GetType().Name);
        await _publisher.Publish(GetNotificationCorrespondingToDomainEvent(domainEvent));
    }

    private INotification GetNotificationCorrespondingToDomainEvent(DomainEvent domainEvent) {
        return (INotification)Activator.CreateInstance(
            typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType()), domainEvent)!;
    }

}
