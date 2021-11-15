
using FluentValidation;

namespace RoyalOrderManager.Application.OrderItems.Commands.UpdateOrder;

public class UpdateOrderStatusCommandValidator : AbstractValidator<UpdateOrderStatusCommand>{

    public UpdateOrderStatusCommandValidator() {

        RuleFor(r => r.OrderStatus)
            .NotNull().WithMessage("Status cannot be empty or null")
            .NotEmpty().WithMessage("Status cannot be empty or null")
            .Must(IsValidStatus).WithMessage("Invalid status");

    }

    public bool IsValidStatus(string status) {

        switch (status) {
            case "Pending":
            case "InProgress":
            case "Completed":
            case "Shipped":
                return true;
            default:
                return false;
        }

    }
}
