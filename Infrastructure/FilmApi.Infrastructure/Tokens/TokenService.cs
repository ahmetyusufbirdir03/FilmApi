using FilmApi.Application.Tokens;
using FilmApi.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FilmApi.Infrastructure.Tokens;

public class TokenService : ITokenService
{
    private readonly UserManager<User> userManager;
    private readonly TokenSettings tokenSettings;
    public TokenService(IOptions<TokenSettings> options, UserManager<User> userManager)
    {
        tokenSettings = options.Value;
        this.userManager = userManager;
    }
    public async Task<JwtSecurityToken> CreateToken(User user, IList<string> roles)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),  
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
        };

        foreach(var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(tokenSettings.Secret));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: tokenSettings.Issuer,
            audience: tokenSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(tokenSettings.TokenValidityInMinutes),
            signingCredentials: credentials
        );

        await userManager.AddClaimsAsync(user, claims);

        return token;
    }

    public string GenerateRefrewshToken()
    {
        var randomNumber = new byte[64];
        using var rng  = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
    {
        TokenValidationParameters tokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Secret)),
            ValidateLifetime = false,
        };

        JwtSecurityTokenHandler tokenHandler = new();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
        if(securityToken is not JwtSecurityToken jwtSecurityToken 
            || !jwtSecurityToken.Header.Alg.Equals(
                SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
                    throw new SecurityTokenException("Token not found!");
        
        return principal;
    }
}
