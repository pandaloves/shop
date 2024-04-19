using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using shop.Data;
using shop.Entities;
using shop.Models;
using shop.models;
using System.Net;
using System.Reflection.Emit;
using System.ComponentModel.DataAnnotations;

namespace shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly DataContext _context;

        public PaymentsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("create-payment")]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentDto paymentDto)
        {
            if (paymentDto == null)
            {
                return BadRequest("Invalid payment data.");
            }

            // Create a Payment entity based on the paymentDto
            var payment = new Payment
            {
                FirstName = paymentDto.FirstName,
                LastName = paymentDto.LastName,
                Email = paymentDto.Email,
                Address = paymentDto.Address,
                City = paymentDto.City,
                ZipCode = paymentDto.ZipCode,
                CardNumber = paymentDto.CardNumber,
                NameOnCard = paymentDto.NameOnCard,
                ExpirationDate = paymentDto.ExpirationDate,
                CVV = paymentDto.CVV,
                OrderId = paymentDto.OrderId

        };

                // Add the payment to the database
                _context.Payments.Add(payment);
                await _context.SaveChangesAsync();

                // Return the newly created payment as a response
                return CreatedAtAction(nameof(CreatePayment), new { paymentId = payment.PaymentId }, payment);
            
        }
    }
}
