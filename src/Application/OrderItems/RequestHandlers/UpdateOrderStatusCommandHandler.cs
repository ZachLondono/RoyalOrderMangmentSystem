using MediatR;
using RoyalOrderManager.Application.Common.Exceptions;
using RoyalOrderManager.Application.Common.Interfaces;
using RoyalOrderManager.Application.OrderItems.Commands.UpdateOrder;
using RoyalOrderManager.Domain.Entities;
using RoyalOrderManager.Domain.Enum;

namespace RoyalOrderManager.Application.OrderItems.RequestHandlers;

internal class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand> {

    private readonly IApplicationDataAccess _dbAccess;

    public UpdateOrderStatusCommandHandler(IApplicationDataAccess dataAccess) {
        _dbAccess = dataAccess;
    }

    public async Task<Unit> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken) {

        var entities = await _dbAccess.GetOrdersAsync(cancellationToken);
        var entity =  entities.Where(o => o.OrderId == request.Id).FirstOrDefault();

        if (entity is null)
            throw new NotFoundException(nameof(Order), request.Id);

        entity.OrderStatus = request.OrderStatus switch {
            "Pending" => Status.Pending,
            "InProgress" => Status.InProgress,
            "Completed" => Status.Completed,
            "Shipped" => Status.Shipped,
            _ => Status.Unknown
        };
        
        await _dbAccess.UpdateOrderAsync(request.Id, entity, cancellationToken);

        return Unit.Value;

    }

}
