namespace RoyalOrderManager.Domain.Common;

/// <summary>
/// An event which happens in a Domain Entity, which will create a notification in the Application layer by MediatR
/// </summary>
public abstract class DomainEvent {

    public DateTimeOffset DateOccured { get; private set; } = DateTime.UtcNow;
    public bool IsPublished { get; set; }


    protected DomainEvent() {
        DateOccured = DateTimeOffset.UtcNow;
    }

}
