using MediatR;
using RoyalOrderManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalOrderManager.Application.OrderItems.Queries;

public class GetAllOrdersQuery : IRequest<IList<Order>> {
}
