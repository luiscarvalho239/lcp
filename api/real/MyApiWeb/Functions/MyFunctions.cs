using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace MyApiWeb.Functions
{
  public class MyFunctions
  {
    public static string BuildToken(IConfiguration _config, string username, DateTime dtexp)
    {
      var claims = new[]
      {
          new Claim(JwtRegisteredClaimNames.UniqueName, username),
          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
      };

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtToken:SecretKey"]));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(_config["JwtToken:Issuer"],
        _config["JwtToken:Issuer"],
        claims: claims,
        expires: dtexp,
        signingCredentials: creds
      );

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}
