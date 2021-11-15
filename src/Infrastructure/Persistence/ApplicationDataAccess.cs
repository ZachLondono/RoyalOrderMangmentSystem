using RoyalOrderManager.Application.Common.Interfaces;
using RoyalOrderManager.Domain.Common;
using RoyalOrderManager.Domain.Entities;
using RoyalOrderManager.Domain.Enum;
using RoyalOrderManager.Domain.Events;

namespace RoyalOrderManager.Infrastructure.Persistence;

internal class ApplicationDataAccess : IApplicationDataAccess {

    private int _id = 0;
    private int NextId { get => ++_id; }

    private readonly IDomainEventService _domainEventService;

    public ApplicationDataAccess(IDomainEventService domainEventService) {
        _domainEventService = domainEventService;
    }

    public Task<IList<Order>> GetOrdersAsync(CancellationToken cancellationToken) {

        IList<Order> list = new List<Order> {
            new Order {
                OrderId = 1,
                OrderStatus = Status.Pending,
                PO = "00000"
            }
        };

        return Task.FromResult(list);

    }

    public async Task<Order> InsertOrderAsync(Status status, string PO, CancellationToken cancellationToken) {

        var entity = new Order {
            OrderId = NextId,
            OrderStatus = status,
            PO = PO,
            Created = DateTime.Now
        };

        entity.DomainEvents.Add(new OrderCreatedEvent(entity));

        await DispatchEvents(entity.DomainEvents.ToArray());

        return entity;
    }

    public async Task<Order> UpdateOrderAsync(int id, Order order, CancellationToken cancellationToken) {

        if (order == null || order.OrderId != id) 
            throw new ArgumentException("Invalid order model");

        var events = order.DomainEvents
                        .Where(e => !e.IsPublished)
                        .ToArray();

        order.LastModified = DateTime.Now;

        await DispatchEvents(events);

        return order;

    }

    private async Task DispatchEvents(DomainEvent[] events) {
        foreach (var domainEvent in events) {
            domainEvent.IsPublished = true;
            await _domainEventService.Publish(domainEvent);
        }
    }

}
