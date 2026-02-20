using Game__Tournament_API.Data;
using Game__Tournament_API.Dtos;
using Game__Tournament_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Game__Tournament_API.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthService(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<AuthResponseDTO?> RegisterAsync(RegisterDTO dto)
    {
        // Kolla om email redan finns
        var exists = await _context.Users.AnyAsync(u => u.Email == dto.Email);
        if (exists) return null;

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            Password = dto.Password  // OBS: I verkligheten - hasha lösenord!
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new AuthResponseDTO
        {
            Token = GenerateToken(user),
            Name = user.Name,
            Email = user.Email
        };
    }

    public async Task<AuthResponseDTO?> LoginAsync(LoginDTO dto)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == dto.Email && u.Password == dto.Password);

        if (user == null) return null;

        return new AuthResponseDTO
        {
            Token = GenerateToken(user),
            Name = user.Name,
            Email = user.Email
        };
    }

    private string GenerateToken(User user)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}