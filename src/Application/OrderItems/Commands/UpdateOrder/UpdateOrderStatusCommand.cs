using MediatR;
using RoyalOrderManager.Domain.Entities;
using RoyalOrderManager.Domain.Enum;

namespace RoyalOrderManager.Application.OrderItems.Commands.UpdateOrder;

public class UpdateOrderStatusCommand : IRequest {

    public int Id { get; set; }

    public string OrderStatus { get; set; } = "";

}
