using RoyalOrderManager.Domain.Common;
using ValueOf;

namespace RoyalOrderManager.Domain.ValueObjects {
    public class Address : ValueOf<(string line1, string line2, string city, string state, string PostalCode), Address> {

    }
}
