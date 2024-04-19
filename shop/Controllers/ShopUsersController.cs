using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using shop.Data;
using shop.Entities;
using shop.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace shop.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("ShopOrigins")]
    [ApiController]
    public class ShopUsersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly UserDetailsService _userDetailsService;
        private readonly JwtHandler _jwtHandler;

        public ShopUsersController(DataContext context, IConfiguration configuration, UserDetailsService userDetailsService, JwtHandler jwtHandler)
        {
            _context = context;
            _configuration = configuration;
            _userDetailsService = userDetailsService;
            _jwtHandler = jwtHandler;
        }

        [HttpGet("user-details")]
        [Authorize] // Protect the endpoint
        public IActionResult GetUserDetails()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get the authenticated user's ID as a string


            if (!int.TryParse(userIdString, out int userId)) // Try to parse the string to an int
            {
                return BadRequest("Invalid user ID");
            }

            var userDetails = _userDetailsService.GetUserDetailsById(userId);

            if (userDetails == null)
            {
                return NotFound();
            }

            return Ok(userDetails);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(UserSignupRequestDto registrationDto)
        {
            // Create a new GiftShopUser with UserType set to Registered (1)
            var user = new ShopUser
            {
                FirstName = registrationDto.FirstName,
                LastName = registrationDto.LastName,
                Email = registrationDto.Email,
                Password = registrationDto.Password,
                UserType = UserType.Registered,
            };

            _context.ShopUsers.Add(user);
            _context.SaveChanges();

            var token = _jwtHandler.GenerateToken(user);

            // Return the token along with a success message
            return Ok(new { Success = true, Message = "Registration successful", Token = token });
        }




        [HttpPost]
        [Route("login")]
        public IActionResult Login(UserLoginRequestDto request)
        {
            // Validate user credentials (replace with your logic)
            ShopUser user = _context.ShopUsers.SingleOrDefault(u => u.Email == request.Email);

            if (user == null || user.Password != request.Password)
            {
                return Unauthorized(new { Success = false, Message = "Invalid credentials" });
            }

            var token = _jwtHandler.GenerateToken(user);

            // Return token as part of the response
            return Ok(new { Success = true, Token = token });
        }

    }
}
