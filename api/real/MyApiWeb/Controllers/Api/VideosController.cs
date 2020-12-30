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
    [Route("api/videos")]
    [ApiController]
    // [Authorize]
    public class VideosController : ControllerBase
    {
        private readonly AllDBContext _context;

        public VideosController(AllDBContext context)
        {
            _context = context;
        }

        // GET: api/Videos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Videos>>> GetVideosItems()
        {
            return await _context.VideosItems.ToListAsync();
        }

        // GET: api/Videos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Videos>> GetVideos(int id)
        {
            var videos = await _context.VideosItems.FindAsync(id);

            if (videos == null)
            {
                return NotFound();
            }

            return videos;
        }

        // PUT: api/Videos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideos(int id, Videos videos)
        {
            if (id != videos.Id)
            {
                return BadRequest();
            }

            _context.Entry(videos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideosExists(id))
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

        // POST: api/Videos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Videos>> PostVideos(Videos videos)
        {
            _context.VideosItems.Add(videos);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVideos), new { id = videos.Id }, videos);
        }

        [HttpPost("addAll")]
        public async Task<ActionResult<Videos>> PostAllVideos([FromBody] Videos[] videoslist)
        {
            int videoslistlen = (videoslist.Length > 0) ? videoslist.Length - 1 : 0;
            _context.VideosItems.AddRange(videoslist);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVideos), new { id = videoslist[videoslistlen].Id }, videoslist);
        }

        // DELETE: api/Videos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Videos>> DeleteVideos(int id)
        {
            var videos = await _context.VideosItems.FindAsync(id);
            if (videos == null)
            {
                return NotFound();
            }

            _context.VideosItems.Remove(videos);
            await _context.SaveChangesAsync();
            ResetAI();

            return videos;
        }

        // DELETE: api/Videos
        [HttpDelete]
        public async Task<ActionResult<IEnumerable<Videos>>> DeleteAllVideos()
        {
            var videos = await _context.VideosItems.ToListAsync();

            if (videos == null)
            {
                return NotFound();
            }

            _context.VideosItems.RemoveRange(videos);
            await _context.SaveChangesAsync();
            ResetAI();

            return videos;
        }

        private void ResetAI()
        {
          var entityType = _context.Model.FindEntityType(typeof(Videos));
          var tableName = entityType.GetTableName();
          var param = new SqlParameter("@tblname", tableName);
          var idlast = _context.VideosItems.OrderByDescending(a => a.Id).FirstOrDefault();
          int rsid = (_context.VideosItems.Count() > 0) ? idlast.Id : 0;

          _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT(@tblname, RESEED, "+rsid+")", param);
        }

        private bool VideosExists(int id)
        {
            return _context.VideosItems.Any(e => e.Id == id);
        }
    }
}
