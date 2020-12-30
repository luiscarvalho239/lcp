using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyApiWeb.Models;
using BC = BCrypt.Net.BCrypt;

namespace MyApiWeb.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly AllDBContext _context;

        public UsersController(AllDBContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsersItems()
        {
            return await _context.UsersItems.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUsers(int id)
        {
            var users = await _context.UsersItems.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, Users users)
        {
            if (id != users.Id)
            {
                return BadRequest();
            }

            users.Password = BC.HashPassword(users.Password);
            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users users)
        {
            users.Password = BC.HashPassword(users.Password);
            users.Token = BuildToken(DateTime.UtcNow.AddDays(7));

            _context.UsersItems.Add(users);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsers), new { id = users.Id }, users);
        }

        [HttpPost("addAll")]
        public async Task<ActionResult<Users>> PostAllUsers([FromBody] Users[] userslist)
        {
            int ulen = (userslist.Length > 0) ? userslist.Length - 1 : 0;

            userslist[ulen].Password = BC.HashPassword(userslist[ulen].Password);
            userslist[ulen].Token = BuildToken(DateTime.UtcNow.AddDays(7));

            _context.UsersItems.AddRange(userslist);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsers), new { id = userslist[ulen].Id }, userslist);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> DeleteUsers(int id)
        {
            var users = await _context.UsersItems.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.UsersItems.Remove(users);
            await _context.SaveChangesAsync();
            ResetAI();

            return users;
        }

        // DELETE: api/Users
        [HttpDelete]
        public async Task<ActionResult<IEnumerable<Users>>> DeleteAllUsers()
        {
            var users = await _context.UsersItems.ToListAsync();

            if (users == null)
            {
                return NotFound();
            }

            _context.UsersItems.RemoveRange(users);
            await _context.SaveChangesAsync();
            ResetAI();

            return users;
        }

        private string BuildToken(DateTime dtexp)
        {
          var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtToken:SecretKey"]));
          var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

          var token = new JwtSecurityToken(_config["JwtToken:Issuer"],
            _config["JwtToken:Issuer"],
            expires: dtexp,
            signingCredentials: creds);

          return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private void ResetAI()
        {
          var entityType = _context.Model.FindEntityType(typeof(Users));
          var tableName = entityType.GetTableName();
          var param = new SqlParameter("@tblname", tableName);
          var idlast = _context.UsersItems.OrderByDescending(a => a.Id).FirstOrDefault();
          int rsid = (_context.UsersItems.Count() > 0) ? idlast.Id : 0;

          _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT(@tblname, RESEED, "+rsid+")", param);
        }

        private bool UsersExists(int id)
        {
            return _context.UsersItems.Any(e => e.Id == id);
        }
    }
}
