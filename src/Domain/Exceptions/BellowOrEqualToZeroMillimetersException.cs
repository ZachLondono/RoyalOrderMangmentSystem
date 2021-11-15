namespace RoyalOrderManager.Domain.Exceptions;

public class BellowOrEqualToZeroMillimetersException : Exception {
    public BellowOrEqualToZeroMillimetersException(double value)
        : base($"Millimeters cannot be bellow 0. Current value: {value}")
    { }
}
