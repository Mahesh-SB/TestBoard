using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageBoardApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        [HttpGet("{filename}")]
        public async Task<IActionResult> GetImage(string filename)
        {
            string currentDir = Directory.GetCurrentDirectory();
            var path = Path.Combine(currentDir,"Images", filename);

            if (!System.IO.File.Exists(path)) return NotFound();

            var bytes = await System.IO.File.ReadAllBytesAsync(path);
            return File(bytes, "image/jpeg", enableRangeProcessing: true);
        }
    }
}
