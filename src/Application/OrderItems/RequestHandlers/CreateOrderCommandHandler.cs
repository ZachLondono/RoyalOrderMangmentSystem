using MediatR;
using RoyalOrderManager.Application.Common.Interfaces;
using RoyalOrderManager.Application.OrderItems.Commands;
using RoyalOrderManager.Application.OrderItems.Commands.CreateOrder;
using RoyalOrderManager.Domain.Entities;
using RoyalOrderManager.Domain.Enum;
using RoyalOrderManager.Domain.Events;

namespace RoyalOrderManager.Application.OrderItems.RequestHandlers;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int> {

    private readonly IApplicationDataAccess _dbAccess;

    public CreateOrderCommandHandler(IApplicationDataAccess dbAccess) {
        _dbAccess = dbAccess;
    }

    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken) {

        var entity = await _dbAccess.InsertOrderAsync(Status.Pending, request.OrderPO ?? "", cancellationToken);

        entity.DomainEvents.Add(new OrderCreatedEvent(entity));

        return entity.OrderId;

    }

}
