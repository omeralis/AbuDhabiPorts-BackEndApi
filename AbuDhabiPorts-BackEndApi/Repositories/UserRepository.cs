using AbuDhabiPorts_BackEndApi.Context;
using AbuDhabiPorts_BackEndApi.Interfaces;
using AbuDhabiPorts_BackEndApi.Models;
using AbuDhabiPorts_BackEndApi.ViewModels.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AbuDhabiPorts_BackEndApi.Repositories;

public class UserRepository : IUserInterface
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _configuration;

    public UserRepository(ApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<string> Login(UserLoginViewModel loginModel)
    {
        var user = await _context.Users
                                    .SingleOrDefaultAsync(u => u.Username == loginModel.Username &&
                                                               u.Password == loginModel.Password);
        if (user == null)
            throw new Exception("Invalid Username/Password");

        return GenerateToken(user);
    }

    private string GenerateToken(User user)
    {
        var authClaims = new List<Claim>
        {
            new Claim("id", user.Id.ToString()),
            new Claim("fullName", user.FullName),
            new Claim("username", user.Username),
        };

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

        var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return token;
    }
}
