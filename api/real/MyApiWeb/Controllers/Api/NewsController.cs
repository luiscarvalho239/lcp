using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyApiWeb.Models;

namespace MyApiWeb.Controllers
{
    [Route("api/news")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly AllDBContext _context;

        public NewsController(AllDBContext context)
        {
            _context = context;
        }

        // GET: api/News
        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> GetNewsItems()
        {
            return await _context.NewsItems.ToListAsync();
        }

        // GET: api/News/5
        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetNews(int id)
        {
            var news = await _context.NewsItems.FindAsync(id);

            if (news == null)
            {
                return NotFound();
            }

            return news;
        }

        // PUT: api/News/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNews(int id, News news)
        {
            if (id != news.Id)
            {
                return BadRequest();
            }

            _context.Entry(news).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsExists(id))
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

        // POST: api/News
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<News>> PostNews(News news)
        {
            _context.NewsItems.Add(news);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNews), new { id = news.Id }, news);
        }

        [HttpPost("addAll")]
        public async Task<ActionResult<News>> PostAllNews([FromBody] News[] newslist)
        {
            int newslistlen = (newslist.Length > 0) ? newslist.Length - 1 : 0;
            _context.NewsItems.AddRange(newslist);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNews), new { id = newslist[newslistlen].Id }, newslist);
        }

        // DELETE: api/News/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<News>> DeleteNews(int id)
        {
            var news = await _context.NewsItems.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }

            _context.NewsItems.Remove(news);
            await _context.SaveChangesAsync();
            ResetAI();

            return news;
        }

        // DELETE: api/News
        [HttpDelete]
        public async Task<ActionResult<IEnumerable<News>>> DeleteAllNews()
        {
            var news = await _context.NewsItems.ToListAsync();

            if (news == null)
            {
                return NotFound();
            }

            _context.NewsItems.RemoveRange(news);
            await _context.SaveChangesAsync();
            ResetAI();

            return news;
        }

        private void ResetAI()
        {
          var entityType = _context.Model.FindEntityType(typeof(News));
          var tableName = entityType.GetTableName();
          var param = new SqlParameter("@tblname", tableName);
          var idlast = _context.NewsItems.OrderByDescending(a => a.Id).FirstOrDefault();
          int rsid = (_context.NewsItems.Count() > 0) ? idlast.Id : 0;

          _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT(@tblname, RESEED, "+rsid+")", param);
        }

        private bool NewsExists(int id)
        {
            return _context.NewsItems.Any(e => e.Id == id);
        }
    }
}
