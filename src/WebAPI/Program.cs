using WebAPI.Models;
using MediatR;
using AutoMapper;
using RoyalOrderManager.Application;
using RoyalOrderManager.Infrastructure;
using RoyalOrderManager.Application.OrderItems.Commands.CreateOrder;
using RoyalOrderManager.Domain.Entities;
using RoyalOrderManager.Application.OrderItems.Commands.UpdateOrder;
using RoyalOrderManager.Domain.Enum;
using RoyalOrderManager.Application.OrderItems.Queries;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(null);
builder.Services.AddLogging();

var config = new MapperConfiguration(cfg => {
    cfg.CreateMap<Order, OrderDTO>();
});

var mapper = config.CreateMapper();
builder.Services.AddSingleton<IMapper>(mapper);

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();


app.MapPost("/orders", async (OrderDTO newOrder, ISender _sender) => {

    int id = await _sender.Send(new CreateOrderCommand {
        OrderPO = newOrder.PO
    });

    return Results.Ok($"Created order - id:{id}");

});

app.MapPut("/orders/{id}", async (int id, string newstatus, ISender _sender) => {

    await _sender.Send(new UpdateOrderStatusCommand {
        Id = id,
        OrderStatus = newstatus
    });

    return Results.NoContent();

});

app.MapGet("/orders", async (ISender _sender, IMapper mapper) => {

    IList<Order> orders = await _sender.Send(new GetAllOrdersQuery());

    IList<OrderDTO> orderDTOs = (IList<OrderDTO>) mapper.Map(orders, typeof(IList<Order>), typeof(IList<OrderDTO>));

    if (orderDTOs.Count == 0)
        return Results.NoContent();
    else
        return Results.Ok(orderDTOs);
});

app.Run();
