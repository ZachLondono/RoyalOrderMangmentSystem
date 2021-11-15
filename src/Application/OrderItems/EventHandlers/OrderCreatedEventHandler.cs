using MediatR;
using Microsoft.Extensions.Logging;
using RoyalOrderManager.Application.Common.Models;
using RoyalOrderManager.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalOrderManager.Application.OrderItems.EventHandlers;

public class OrderCreatedEventHandler : INotificationHandler<DomainEventNotification<OrderCreatedEvent>> {

    private readonly ILogger<OrderCreatedEventHandler> _logger;

    public OrderCreatedEventHandler(ILogger<OrderCreatedEventHandler> logger) {
        _logger = logger;
    }

    public Task Handle(DomainEventNotification<OrderCreatedEvent> notification, CancellationToken cancellationToken) {

        var domainEvent = notification.DomainEvent;

        _logger.LogInformation("Royal Order Manager Domain Event: {DomainEvent}", domainEvent.GetType().Name);

        return Task.CompletedTask;

    }

}
