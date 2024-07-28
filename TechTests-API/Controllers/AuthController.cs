using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TechTests_API.Data;
using TechTests_API.DTOs;
using TechTests_API.Services;

namespace TechTests_API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private TechTestsDbContext DbContext { get; set; }
        private AuthService AuthService { get; set; }
        public AuthController(TechTestsDbContext dbContext, AuthService authService)
        {
            this.DbContext = dbContext;
            this.AuthService = authService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(LoginDTO loginDTO)
        {
            string messageTitle = "Login";
            try
            {
                if (this.HttpContext.User.Identity.IsAuthenticated)
                {
                    Message message = Message.CreateFailed(messageTitle, "User is already authorized!");
                    return BadRequest(message);
                } 
                else
                {
                    ClaimsPrincipal claimsPrincipal = this.AuthService.Login(this.DbContext, loginDTO);
                    await this.HttpContext.SignInAsync(claimsPrincipal);

                    Message message = Message.CreateSuccessful(messageTitle, "User successfully authorized!");

                    return Ok(message);
                }
            }
            catch
            {
                Message message = Message.CreateFailed(messageTitle, "User authorization failed!");

                return Unauthorized(message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            string messageTitle = "Logout";
            try
            {
                await this.HttpContext.SignOutAsync();

                Message message = Message.CreateSuccessful(messageTitle, "User deauthorized successfully!");
                return Ok(message);
            }
            catch
            {
                Message message = Message.CreateFailed(messageTitle, "Deauthorization failed!");
                return BadRequest(message);
            }
        }

        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> RegistrationAsync(LoginDTO loginDTO)
        {
            string messageTitle = "Registration";
            try
            {
                ClaimsPrincipal claimsPrincipal = this.AuthService.Registration(this.DbContext, loginDTO);
                await this.HttpContext.SignInAsync(claimsPrincipal);

                Message message = Message.CreateSuccessful(messageTitle, "User registered successfully!");
                return Ok(message);
            }
            catch
            {
                Message message = Message.CreateFailed(messageTitle, "User with this login already exists!");
                return BadRequest(message);
            }
        }

        [HttpGet]
        [Route("isAuthenticated")]
        public IActionResult IsAuthenticated()
        {
            return Ok(new { isAuthenticated = this.HttpContext.User.Identity.IsAuthenticated });
        }

        [HttpGet]
        [Route("isAvailableLogin")]
        public IActionResult IsAvailableLogin(string login)
        {
            try
            {
                return Ok(this.AuthService.IsAvailableLogin(this.DbContext, login));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
