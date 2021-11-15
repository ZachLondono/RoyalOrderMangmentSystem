namespace RoyalOrderManager.Domain.Common;

public abstract class IAuditableEntity {

    public DateTime Created { get; set; }

    public DateTime? LastModified { get; set; }

}
