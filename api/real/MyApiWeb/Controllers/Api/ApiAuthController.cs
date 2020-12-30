using BC = BCrypt.Net.BCrypt;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApiWeb.Models;
using MyApiWeb.Functions;
using Microsoft.Extensions.Configuration;

namespace MyApiWeb.Controllers
{
  [Route("api/[controller]")]
  public class ApiAuthController : ControllerBase
  {
    private readonly IConfiguration _config;
    private readonly AllDBContext _context;

    public ApiAuthController(IConfiguration config, AllDBContext context)
    {
      _config = config;
      _context = context;
    }

    [HttpGet("getAuthUsers")]
    public IActionResult GetAuthUsersList()
    {
      return Ok(_context.UsersItems.ToList());
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult CreateToken([FromBody] UsersAuth login)
    {
      if (login == null) return Unauthorized();

      DateTime dt = DateTime.UtcNow.AddDays(7);
      bool validUser = Authenticate(login);
      string tokenString = string.Empty;
      var getUser = _context.UsersItems.SingleOrDefault(x => x.Username == login.Username);

      if (validUser)
      {
        tokenString = MyFunctions.BuildToken(_config, login.Username, dt);
      }
      else
      {
        return Unauthorized();
      }

      return Ok(
        new {
          id = getUser.Id,
          username = getUser.Username,
          email = getUser.Email,
          role = getUser.Role,
          firstName = getUser.FirstName,
          lastName = getUser.LastName,
          image = getUser.Image,
          token = tokenString,
          expiration = dt
        }
      );
    }

    private bool Authenticate(UsersAuth login)
    {
      var isUser = _context.UsersItems.SingleOrDefault(x => x.Username == login.Username);

      if (isUser == null || !BC.Verify(login.Password, isUser.Password))
      {
        return false;
      }
      else
      {
        return true;
      }
    }
  }
}
