using Microsoft.AspNetCore.Mvc;
using WebTreeViewBack.Model;

namespace WebTreeViewBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JsonRetriever : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string jsonFileName)
        {
            try
            {
                string json = System.IO.File.ReadAllText($"./Files/{jsonFileName}");
                return Ok(Newtonsoft.Json.JsonConvert.DeserializeObject<List<Item>>(json));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}