using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using skolu_nepobiram.Database.Models;
using skolu_nepobiram.Models;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace skolu_nepobiram.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _um;

        public AuthController(UserManager<ApplicationUser> um)
        {
            this._um = um;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserModel user)
        {
            var res = await this._um.FindByNameAsync(user.UserName);
            if (res == null) return new BadRequestResult();

            var login = await this._um.CheckPasswordAsync(res, user.Password);

            if (login)
                return new ObjectResult(new
                {
                    token = this.m_generateToken(user.UserName),
                    username = res.UserName
                });

            return new BadRequestObjectResult("Invalid password!");
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserModel user)
        {
            var res = await this._um.CreateAsync(new ApplicationUser() {UserName = user.UserName, Email = user.Email},
                user.Password);
            if (res.Succeeded)
            {
                return new ObjectResult(new
                {
                    token = this.m_generateToken(user.UserName),
                    username = user.UserName
                });
            }

            return new BadRequestResult();
        }

        private string m_generateToken(string username)
        {
            var securityKey =
                new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes("Xn2r5u8x/A?D(G+K"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, username)
            };

            var token = new JwtSecurityToken("false", "false", claims, expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}