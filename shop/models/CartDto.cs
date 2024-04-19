namespace shop.models
{
    public class CartDto
    {
        public int UserId { get; set; }
        public List<CartItemDto> CartItems { get; set; }
    }

    public class CartItemDto
    {
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
    }
}

