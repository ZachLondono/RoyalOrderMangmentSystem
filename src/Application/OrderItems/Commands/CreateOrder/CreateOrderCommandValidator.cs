using FluentValidation;
using System.Linq;
using RoyalOrderManager.Application.Common.Interfaces;

namespace RoyalOrderManager.Application.OrderItems.Commands.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand> {

    private readonly IApplicationDataAccess _dbAccess;

    public CreateOrderCommandValidator(IApplicationDataAccess dbAccess) {
        _dbAccess = dbAccess;

        RuleFor(o => o.OrderPO)
            .NotNull().WithMessage("Order PO is required")
            .NotEmpty().WithMessage("Order PO is required")
            .MaximumLength(50).WithMessage("Order PO must not exceed 50 characters")
            .MustAsync(BeUniquePO).WithMessage("The specified PO already exists");

    }

    public async Task<bool> BeUniquePO(string PO, CancellationToken cancellation) {

        var orders = await _dbAccess.GetOrdersAsync(cancellation);

        return orders.All(o => o.PO != PO);

    }


}
