using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions;

public static class IdentityServiceextention
{
    public static IServiceCollection IdentityServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
     .AddJwtBearer(options =>
     {
        var token=config["TokenKey"] ?? throw new Exception("Tokenkey not found");
        options.TokenValidationParameters= new TokenValidationParameters
        {
            ValidateIssuerSigningKey=true,
            IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token)),
            ValidateIssuer=false,
            ValidateAudience=false
        };
     });
     return services;
    }
}
