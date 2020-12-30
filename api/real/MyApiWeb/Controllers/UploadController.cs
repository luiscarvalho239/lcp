using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApiWeb.Controllers.Api
{
  [Route("api/upload")]
  [ApiController]
  // [Authorize]
  public class UploadController : Controller
  {
    public UploadController()
    {
    }

    [HttpPost("", Name = nameof(EnviaFicheiros)), DisableRequestSizeLimit]
    public async Task<string> EnviaFicheiros([FromForm] IFormFile file)
    {
      return await UploadFile(file, "files");
    }

    [HttpPost("images", Name = nameof(EnviaImagens)), DisableRequestSizeLimit]
    public async Task<string> EnviaImagens([FromForm] IFormFile file)
    {
      return await UploadFile(file, "images");
    }

    [HttpPost("videos", Name = nameof(EnviaVideos)), DisableRequestSizeLimit]
    public async Task<string> EnviaVideos([FromForm] IFormFile file)
    {
      return await UploadFile(file, "videos");
    }

    private async Task<string> UploadFile([FromForm] IFormFile file, string dir = "images")
    {
      var path = Path.Combine(Directory.GetCurrentDirectory(), @"Resources") + "\\" + dir + "\\";

      try
      {
        if (!Directory.Exists(path))
        {
          Directory.CreateDirectory(path);
        }

        if (!System.IO.File.Exists(path + file.FileName))
        {
          using (FileStream filestream = System.IO.File.Create(path + file.FileName))
          {
            await file.CopyToAsync(filestream);
            filestream.Flush();
            return @"https://localhost:5001/resources/" + dir + "/" + file.FileName;
          }
        }
        else
        {
          return "The file already exist!";
        }
      }
      catch (Exception ex)
      {
        return ex.ToString();
      }
    }
  }
}
