using RoyalOrderManager.Domain.Common;
using RoyalOrderManager.Domain.Entities;

namespace RoyalOrderManager.Domain.Events;

/// <summary>
/// This event occurs when an Order is first inserted into the database
/// </summary>
public class OrderCreatedEvent : DomainEvent {

    public Order Order { get; set; }

    public OrderCreatedEvent(Order order) {
        Order = order;
    }

}