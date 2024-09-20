using Microsoft.AspNetCore.Mvc;
using shop.Data;
using Microsoft.AspNetCore.Cors;
using shop.Models;
using Microsoft.EntityFrameworkCore;
using shop.models;

namespace shop.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("ShopOrigins")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DataContext _context;

        public OrdersController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("create-order")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDto orderDto)
        {
            if (orderDto == null || orderDto.OrderItems == null || orderDto.OrderItems.Count == 0)
            {
                return BadRequest("Invalid order data.");
            }

            // Create an Order entity based on the orderDto
            var order = new Order
            {
                UserId = orderDto.UserId,
                TotalAmount = orderDto.TotalAmount, // Set the TotalAmount property
                OrderItems = orderDto.OrderItems.Select(oi => new OrderItem
                {
                    ProductId = oi.ProductId,
                    ProductQuantity = oi.ProductQuantity
                }).ToList()
            };

            // Add the order to the database
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // Return the newly created order as a response
            return CreatedAtAction(nameof(CreateOrder), new { orderId = order.OrderId }, order);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<Order>>> GetOrders(int userId)
        {
            // Retrieve the order and its associated order items from the database
            var order = await _context.Orders.Where(x => x.UserId == userId)
                .ToListAsync();

            if (order == null)
            {
                return NotFound(); // Order not found
            }

            // Create an OrderDetails object to combine order and order items information
            //var orderDetails = new OrderDetails
            //{
            //    OrderId = order.OrderId,
            //    TotalAmount = order.TotalAmount,
            //    UserId = order.UserId,
            //    OrderItems = order.OrderItems.Select(oi => new OrderItemDto
            //    {
            //        ProductId = oi.ProductId,
            //        ProductQuantity = oi.ProductQuantity,
            //        // Include additional properties from OrderItem as needed
            //    }).ToList()
            //};

            return Ok(order);
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<OrderDetails>> GetOrder(int orderId)
        {
            // Retrieve the order and its associated order items from the database
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .SingleOrDefaultAsync(o => o.OrderId == orderId);

            if (order == null)
            {
                return NotFound(); // Order not found
            }

            // Create an OrderDetails object to combine order and order items information
            var orderDetails = new OrderDetails
            {
                OrderId = order.OrderId,
                TotalAmount = order.TotalAmount,
                UserId = order.UserId,
                OrderItems = order.OrderItems.Select(oi => new OrderItemDto
                {
                    ProductId = oi.ProductId,
                    ProductQuantity = oi.ProductQuantity,
                    // Include additional properties from OrderItem as needed
                }).ToList()
            };

            return Ok(orderDetails);
        }

        [HttpDelete("delete-order/{userId}")]
        public async Task<IActionResult> DeleteOrder(int userId)
        {
            // Find the user's order
            var order = await _context.Orders
                .Include(c => c.OrderItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (order == null)
            {
                return NotFound("Order not found.");
            }

            // Remove the order and its associated order items
            _context.Orders.Remove(order);

            // Save changes to the database
            await _context.SaveChangesAsync();

            return Ok(new { Success = true, Message = "Order deleted successfully." });
        }
    }
}
