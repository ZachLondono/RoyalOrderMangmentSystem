using RoyalOrderManager.Domain.Common;

namespace RoyalOrderManager.Application.Common.Interfaces;

public interface IDomainEventService {
    Task Publish(DomainEvent domainEvent);
}
