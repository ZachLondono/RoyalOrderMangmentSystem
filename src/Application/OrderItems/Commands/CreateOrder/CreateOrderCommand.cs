using MediatR;

namespace RoyalOrderManager.Application.OrderItems.Commands.CreateOrder;

/// <summary>
/// Use this command to create a new order by passing in its properties. The command will return the orders new id.
/// </summary>
public class CreateOrderCommand : IRequest<int> {

    public string? OrderPO { get; set; }

}
