using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Blog.Extensions;
using Blog.Models;
using Microsoft.IdentityModel.Tokens;
namespace Blog.Services;
public class TokenService
{
    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler(); //<- controlador/gerador de token
        var key = Encoding.ASCII.GetBytes(Configuration.JwtKey); //<- Pegamos a nossa chave que criamos e convertermos para array de bytes (ele não pega string)
        var claims = user.getClaims();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(8), //<-- Expira o tempo do token apos x tempo. (UsandoUtcNow evita problemas de timezone).
            SigningCredentials = new SigningCredentials( //<- Dita como o token vai ser gerado e lido
                new SymmetricSecurityKey(key), //<- 1. pede a nossa chave (usando chave simétrica, que é única)
                SecurityAlgorithms.HmacSha256Signature //<- 2. Tipo de algoritmo de encriptação
            )
        }; //<- especificação do token
        var token = tokenHandler.CreateToken(tokenDescriptor); //<- criamos o nosso token baseado nas configurações do tokenDescriptor
        return tokenHandler.WriteToken(token); //<- retornamos o token que ira converter tudo em uma string
    }
}