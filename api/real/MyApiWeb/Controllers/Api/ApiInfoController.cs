using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApiWeb.Models;
using Newtonsoft.Json;

namespace MyApiWeb.Controllers
{
  [Route("api")]
  [ApiController]
  [Authorize]
  // [Authorize(AuthenticationSchemes = "Bearer")]
  public class ApiInfoController : ControllerBase
  {
    private readonly AllDBContext _context;

    public ApiInfoController(AllDBContext context)
    {
      _context = context;
    }

    [HttpGet]
    public string Get()
    {
      Dictionary<string, Array> dict = new Dictionary<string, Array>()
      {
        { "games", _context.GamesItems.ToArray() },
        { "savegames", _context.SaveGamesItems.ToArray() },
        { "news", _context.NewsItems.ToArray() },
        { "videos", _context.VideosItems.ToArray() },
        { "radios", _context.RadiosListItems.ToArray() },
        { "users", _context.UsersItems.ToArray() }
      };
      return JsonConvert.SerializeObject(dict, Formatting.Indented);
    }

    [HttpGet("getFakeModelData")]
    public async Task<string> GetFakeModelData()
    {
      var dir = Directory.GetCurrentDirectory();
      var file_json = dir + @"\JSON\db.json";
      string json_content = "";

      using (StreamReader r = new StreamReader(file_json))
      {
         json_content = await r.ReadToEndAsync();
      }

      return json_content;
    }
  }
}
