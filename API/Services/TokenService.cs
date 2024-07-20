using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using API.Entities;
using Microsoft.IdentityModel.Tokens;

namespace API;

public class TokenService(IConfiguration config) : ITokenServices
{
    public string CreateToken(AppUser user)
    {
        var tokenkey = config["TokenKey"] ?? throw new Exception("Cannot acess TokenKey from AppSettings");
        if (tokenkey.Length < 64) throw new Exception("Your tokenkey needs to be longer");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenkey));
        var claims =new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.UserName)
        };
        var creds= new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var tokendescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires=DateTime.UtcNow.AddDays(7),
            SigningCredentials=creds

        };  
        var tokenhandler =new JwtSecurityTokenHandler();
        var token= tokenhandler.CreateToken(tokendescriptor); 
        return tokenhandler.WriteToken(token);
    }
    
}
