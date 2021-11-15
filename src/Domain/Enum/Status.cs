namespace RoyalOrderManager.Domain.Enum;

public enum Status {
    Unknown = 0,
    Pending = 1,        // The order is awaiting confirmation from the customer
    InProgress = 2,     // The shop has begun working on the order
    Completed = 3,      // The shop has finished working on the order
    Shipped = 4         // The order has been picked up by the shipper
}
