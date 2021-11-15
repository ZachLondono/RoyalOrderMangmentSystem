using RoyalOrderManager.Domain.Entities;
using RoyalOrderManager.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalOrderManager.Application.Common.Interfaces;

public interface IApplicationDataAccess {

    Task<IList<Order>> GetOrdersAsync(CancellationToken cancellationToken);

    Task<Order> InsertOrderAsync(Status status, string PO, CancellationToken cancellationToken);

    Task<Order> UpdateOrderAsync(int id, Order order, CancellationToken cancellationToken);

}
