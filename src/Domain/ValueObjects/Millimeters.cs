using RoyalOrderManager.Domain.Common;
using RoyalOrderManager.Domain.Exceptions;
using ValueOf;

namespace RoyalOrderManager.Domain.ValueObjects {

    /// <summary>
    /// Represents a dimensional value in either inches or millimeters
    /// </summary>
    public class Millimeters : ValueOf<double, Millimeters> {

        public double AsFeet { get => Value * 25.4 * 12; }
        public double AsInches { get => Value * 25.4; }

        public double AsCentimeter { get => Value * 0.1; }

        protected override void Validate() {
            if (Value <= 0) 
                throw new BellowOrEqualToZeroMillimetersException(Value);
        }

        public static Millimeters FromInches(double inch) {
            return Millimeters.From(inch * 25.4);
        }

        public static Millimeters operator *(Millimeters left, Millimeters right) {
            return Millimeters.From(left.Value * right.Value);
        }
        
        public static Millimeters operator /(Millimeters left, Millimeters right) {
            return Millimeters.From(left.Value / right.Value);
        }

        public static Millimeters operator -(Millimeters left, Millimeters right) {
            return Millimeters.From(left.Value - right.Value);
        }

        public static Millimeters operator +(Millimeters left, Millimeters right) {
            return Millimeters.From(left.Value + right.Value);
        }

        public static explicit operator Millimeters(double millimeters) {
            return Millimeters.From(millimeters);
        }

    }
}
