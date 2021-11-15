using RoyalOrderManager.Domain.Exceptions;
using ValueOf;

namespace RoyalOrderManager.Domain.ValueObjects;

public class Quantity : ValueOf<int, Quantity>{

    protected override void Validate() {
        if (Value <= 0)
            throw new BellowOrEqualToZeroQuantityException(Value);
    }

    public static Quantity operator *(Quantity left, Quantity right) {
        return Quantity.From(left.Value * right.Value);
    }

    public static Quantity operator /(Quantity left, Quantity right) {
        return Quantity.From(left.Value / right.Value);
    }

    public static Quantity operator -(Quantity left, Quantity right) {
        return Quantity.From(left.Value - right.Value);
    }

    public static Quantity operator +(Quantity left, Quantity right) {
        return Quantity.From(left.Value + right.Value);
    }

    public static explicit operator Quantity(int qty) {
        return Quantity.From(qty);
    }

}
