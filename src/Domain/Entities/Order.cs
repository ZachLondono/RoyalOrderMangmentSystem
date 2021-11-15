using RoyalOrderManager.Domain.Common;
using RoyalOrderManager.Domain.Enum;
using RoyalOrderManager.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalOrderManager.Domain.Entities;

public class Order : IAuditableEntity, IHasDomainEvent {

    public int OrderId { get; set; }

    public string? PO { get; set; }


    private Status _status;
    public Status OrderStatus {
        get => _status;
        set {

            _status = value;
            switch (_status) {
                case Status.Completed:
                    DomainEvents.Add(new OrderCompletedEvent(this));
                    break;
                case Status.Shipped:
                    DomainEvents.Add(new OrderShippedEvent(this));
                    break;
            }

        }
    }

    public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

}
