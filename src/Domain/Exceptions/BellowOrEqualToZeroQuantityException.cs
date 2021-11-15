namespace RoyalOrderManager.Domain.Exceptions;

public class BellowOrEqualToZeroQuantityException : Exception {
    public BellowOrEqualToZeroQuantityException(double value)
        : base($"Quantity cannot be bellow 0. Current value: {value}") { }
}






