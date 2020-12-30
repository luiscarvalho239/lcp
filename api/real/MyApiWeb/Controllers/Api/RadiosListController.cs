using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyApiWeb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApiWeb.Controllers.Api
{
  [Route("api/radios")]
  [ApiController]
  public class RadiosListController : ControllerBase
  {
    private readonly AllDBContext _context;

    public RadiosListController(AllDBContext context)
    {
      _context = context;
    }

    // GET: api/RadiosList
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RadiosList>>> GetRadiosListItems()
    {
      return await _context.RadiosListItems.ToListAsync();
    }

    // GET: api/RadiosList/5
    [HttpGet("{id}")]
    public async Task<ActionResult<RadiosList>> GetRadiosList(int id)
    {
      var games = await _context.RadiosListItems.FindAsync(id);

      if (games == null)
      {
        return NotFound();
      }

      return games;
    }

    // PUT: api/RadiosList/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRadiosList(int id, RadiosList games)
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
        if (!RadiosListExists(id))
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

    // POST: api/RadiosList
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public async Task<ActionResult<RadiosList>> PostRadiosList(RadiosList games)
    {
      _context.RadiosListItems.Add(games);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetRadiosList), new { id = games.Id }, games);
    }

    [HttpPost("addAll")]
    public async Task<ActionResult<RadiosList>> PostAllRadiosList([FromBody] RadiosList[] gameslist)
    {
      int gameslistlen = (gameslist.Length > 0) ? gameslist.Length - 1 : 0;
      _context.RadiosListItems.AddRange(gameslist);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetRadiosList), new { id = gameslist[gameslistlen].Id }, gameslist);
    }

    // DELETE: api/RadiosList/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<RadiosList>> DeleteRadiosList(int id)
    {
      var games = await _context.RadiosListItems.FindAsync(id);
      if (games == null)
      {
        return NotFound();
      }

      _context.RadiosListItems.Remove(games);
      await _context.SaveChangesAsync();
      ResetAI();

      return games;
    }

    // DELETE: api/RadiosList
    [HttpDelete]
    public async Task<ActionResult<IEnumerable<RadiosList>>> DeleteAllRadiosList()
    {
      var games = await _context.RadiosListItems.ToListAsync();

      if (games == null)
      {
        return NotFound();
      }

      _context.RadiosListItems.RemoveRange(games);
      await _context.SaveChangesAsync();
      ResetAI();

      return games;
    }

    private void ResetAI()
    {
      var entityType = _context.Model.FindEntityType(typeof(RadiosList));
      var tableName = entityType.GetTableName();
      var param = new SqlParameter("@tblname", tableName);
      var idlast = _context.RadiosListItems.OrderByDescending(a => a.Id).FirstOrDefault();
      int rsid = (_context.RadiosListItems.Count() > 0) ? idlast.Id : 0;

      _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT(@tblname, RESEED, " + rsid + ")", param);
    }

    private bool RadiosListExists(int id)
    {
      return _context.RadiosListItems.Any(e => e.Id == id);
    }
  }
}
