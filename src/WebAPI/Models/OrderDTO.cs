using RoyalOrderManager.Domain.Enum;

namespace WebAPI.Models;

public class OrderDTO {

    public int Id { get; set; }

    public string PO { get; set; } = "";

    public string OrderStatus { get; set; } = "";

    public DateTime Created { get; set; } = DateTime.Now;

    public DateTime? LastUpdated { get; set; }

}
