using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyApiWeb.Models;

namespace MyApiWeb.Controllers
{
    [Route("api/games")]
    [ApiController]
    [Authorize]
    public class GamesController : ControllerBase
    {
        private readonly AllDBContext _context;

        public GamesController(AllDBContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Games>>> GetGamesItems()
        {
            return await _context.GamesItems.ToListAsync();
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Games>> GetGames(int id)
        {
            var games = await _context.GamesItems.FindAsync(id);

            if (games == null)
            {
                return NotFound();
            }

            return games;
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGames(int id, Games games)
        {
            if (id != games.Id)
            {
                return BadRequest();
            }

            _context.Entry(games).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamesExists(id))
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

        // POST: api/Games
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Games>> PostGames(Games games)
        {
            _context.GamesItems.Add(games);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGames), new { id = games.Id }, games);
        }

        [HttpPost("addAll")]
        public async Task<ActionResult<Games>> PostAllGames([FromBody] Games[] gameslist)
        {
            int gameslistlen = (gameslist.Length > 0) ? gameslist.Length - 1 : 0;
            _context.GamesItems.AddRange(gameslist);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGames), new { id = gameslist[gameslistlen].Id }, gameslist);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Games>> DeleteGames(int id)
        {
            var games = await _context.GamesItems.FindAsync(id);
            if (games == null)
            {
                return NotFound();
            }

            _context.GamesItems.Remove(games);
            await _context.SaveChangesAsync();
            ResetAI();

            return games;
        }

        // DELETE: api/Games
        [HttpDelete]
        public async Task<ActionResult<IEnumerable<Games>>> DeleteAllGames()
        {
            var games = await _context.GamesItems.ToListAsync();

            if (games == null)
            {
                return NotFound();
            }

            _context.GamesItems.RemoveRange(games);
            await _context.SaveChangesAsync();
            ResetAI();

            return games;
        }

        private void ResetAI()
        {
          var entityType = _context.Model.FindEntityType(typeof(Games));
          var tableName = entityType.GetTableName();
          var param = new SqlParameter("@tblname", tableName);
          var idlast = _context.GamesItems.OrderByDescending(a => a.Id).FirstOrDefault();
          int rsid = (_context.GamesItems.Count() > 0) ? idlast.Id : 0;

          _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT(@tblname, RESEED, "+rsid+")", param);
        }

        private bool GamesExists(int id)
        {
            return _context.GamesItems.Any(e => e.Id == id);
        }
    }
}
