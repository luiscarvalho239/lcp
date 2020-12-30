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
    [Route("api/savegames")]
    [ApiController]
    [Authorize]
    public class SaveGamesController : ControllerBase
    {
        private readonly AllDBContext _context;

        public SaveGamesController(AllDBContext context)
        {
            _context = context;
        }

        // GET: api/SaveGames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaveGames>>> GetSaveGamesItems()
        {
            return await _context.SaveGamesItems.ToListAsync();
        }

        // GET: api/SaveGames/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SaveGames>> GetSaveGames(int id)
        {
            var saveGames = await _context.SaveGamesItems.FindAsync(id);

            if (saveGames == null)
            {
                return NotFound();
            }

            return saveGames;
        }

        // PUT: api/SaveGames/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaveGames(int id, SaveGames saveGames)
        {
            if (id != saveGames.Id)
            {
                return BadRequest();
            }

            _context.Entry(saveGames).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaveGamesExists(id))
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

        // POST: api/SaveGames
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SaveGames>> PostSaveGames(SaveGames saveGames)
        {
            _context.SaveGamesItems.Add(saveGames);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSaveGames), new { id = saveGames.Id }, saveGames);
        }

        [HttpPost("addAll")]
        public async Task<ActionResult<SaveGames>> PostAllSaveGames([FromBody] SaveGames[] sgameslist)
        {
            int sgameslistlen = (sgameslist.Length > 0) ? sgameslist.Length - 1 : 0;
            _context.SaveGamesItems.AddRange(sgameslist);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSaveGames), new { id = sgameslist[sgameslistlen].Id }, sgameslist);
        }

        // DELETE: api/SaveGames/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SaveGames>> DeleteSaveGames(int id)
        {
            var saveGames = await _context.SaveGamesItems.FindAsync(id);
            if (saveGames == null)
            {
                return NotFound();
            }

            _context.SaveGamesItems.Remove(saveGames);
            await _context.SaveChangesAsync();
            ResetAI();

            return saveGames;
        }

        // DELETE: api/SaveGames
        [HttpDelete]
        public async Task<ActionResult<IEnumerable<SaveGames>>> DeleteAllSaveGames()
        {
            var saveGames = await _context.SaveGamesItems.ToListAsync();

            if (saveGames == null)
            {
                return NotFound();
            }

            _context.SaveGamesItems.RemoveRange(saveGames);
            await _context.SaveChangesAsync();
            ResetAI();

            return saveGames;
        }

        private void ResetAI()
        {
          var entityType = _context.Model.FindEntityType(typeof(SaveGames));
          var tableName = entityType.GetTableName();
          var param = new SqlParameter("@tblname", tableName);
          var idlast = _context.SaveGamesItems.OrderByDescending(a => a.Id).FirstOrDefault();
          int rsid = (_context.SaveGamesItems.Count() > 0) ? idlast.Id : 0;

          _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT(@tblname, RESEED, "+rsid+")", param);
        }

        private bool SaveGamesExists(int id)
        {
            return _context.SaveGamesItems.Any(e => e.Id == id);
        }
    }
}
