using shop.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Order
{
    [Key]
    public int OrderId { get; set; }
    public decimal TotalAmount { get; set; }

    public int UserId { get; set; } // Foreign key to ShopUser
    public ShopUser User { get; set; } // An Order belongs to one ShopUser
    public ICollection<OrderItem> OrderItems { get; set; }

    public Payment Payment { get; set; }

}

public class OrderItem
{
    public int OrderItemId { get; set; }

    // Reference to Product
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int OrderId { get; set; }

    [JsonIgnore]
    public Order Order { get; set; }

    public int ProductQuantity { get; set; }
}

