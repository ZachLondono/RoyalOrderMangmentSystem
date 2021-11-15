using RoyalOrderManager.Domain.Common;
using MediatR;

namespace RoyalOrderManager.Application.Common.Models;

public class DomainEventNotification<TDomainEvent> : INotification where TDomainEvent : DomainEvent {

    public TDomainEvent DomainEvent { get; set; }

    public DomainEventNotification(TDomainEvent domainEvent) {
        DomainEvent = domainEvent;
    }

}
