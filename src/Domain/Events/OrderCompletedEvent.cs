using RoyalOrderManager.Domain.Common;
using RoyalOrderManager.Domain.Entities;

namespace RoyalOrderManager.Domain.Events;

/// <summary>
/// This event occurrs when an Order's status is changed to Complete
/// </summary>
public class OrderCompletedEvent : DomainEvent {

    public Order Order { get; set; }

    public OrderCompletedEvent(Order order) {
        Order = order;
    }

}
