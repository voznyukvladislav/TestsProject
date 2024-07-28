using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TechTests_API.Data;
using TechTests_API.DTOs;
using TechTests_API.Models;

namespace TechTests_API.Services
{
    public class AuthService
    {
        private string GetPasswordHash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x16"));
                }

                return sb.ToString();
            }
        }

        public bool IsAvailableLogin(TechTestsDbContext dbContext, string login)
        {
            if (string.IsNullOrEmpty(login)) return false;

            User? user = dbContext.Users.FirstOrDefault(u => u.Login == login);

            if (user is null) return true;
            else return false;
        }

        public ClaimsPrincipal Login(TechTestsDbContext dbContext, LoginDTO loginDTO)
        {
            string passwordHash = this.GetPasswordHash(loginDTO.Password);
            User? user = dbContext.Users
                .FirstOrDefault(u => u.Login == loginDTO.Login && u.PasswordHash == passwordHash);

            if (user is null)
            {
                throw new ArgumentException();
            }

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.NameIdentifier, $"{user.Id}")
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            return claimsPrincipal;
        }

        public ClaimsPrincipal Registration(TechTestsDbContext dbContext, LoginDTO loginDTO)
        {
            User? user = dbContext.Users.FirstOrDefault(u => u.Login == loginDTO.Login);

            if (user is not null) throw new ArgumentException();

            user = new User();
            user.Login = loginDTO.Login;
            user.PasswordHash = this.GetPasswordHash(loginDTO.Password);

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.NameIdentifier, $"{user.Id}")
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            return claimsPrincipal;
        }
    }
}
