using RoyalOrderManager.Domain.Common;
using RoyalOrderManager.Domain.Entities;

namespace RoyalOrderManager.Domain.Events;

/// <summary>
/// This event occurrs when an Order's status is updated to Shipped
/// </summary>
public class OrderShippedEvent : DomainEvent {

    public Order Order { get; set; }

    public OrderShippedEvent(Order order) {
        Order = order;
    }

}
