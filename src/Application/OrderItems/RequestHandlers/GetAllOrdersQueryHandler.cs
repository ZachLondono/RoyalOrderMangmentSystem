using MediatR;
using RoyalOrderManager.Application.Common.Interfaces;
using RoyalOrderManager.Application.OrderItems.Queries;
using RoyalOrderManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalOrderManager.Application.OrderItems.RequestHandlers;

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IList<Order>> {

    private readonly IApplicationDataAccess _dbAcces;

    public GetAllOrdersQueryHandler(IApplicationDataAccess dbAcces) {
        _dbAcces = dbAcces;
    }

    public async Task<IList<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken) {
        return await _dbAcces.GetOrdersAsync(cancellationToken);
    }

}
