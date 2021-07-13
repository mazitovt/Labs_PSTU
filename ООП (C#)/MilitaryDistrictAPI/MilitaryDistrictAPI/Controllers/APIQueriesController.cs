using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using MilitaryDistrictAPI.Models.scaffolded;



namespace MilitaryDistrictAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIQueriesController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        private readonly MilitaryDistrict2Context _context;

        public APIQueriesController(IConfiguration configuration, MilitaryDistrict2Context context)
        {
            Configuration = configuration;
            _context = context;
        }

        [HttpPost]
        public ActionResult Post([FromBody] JsonDocument document)
        {
            var procedureName = document.RootElement.GetProperty("procedureName").GetString();

            var args = document.RootElement.GetProperty("args").EnumerateArray();
            
            var stringArgs = args.Select(item => item.GetString()).ToArray();

            return new ContentResult
            {
                Content = Newtonsoft.Json.JsonConvert.SerializeObject(
                    new {
                        note = "пояснительная записка", 
                        table = _context.ExecuteQuery(procedureName, stringArgs)
                    }),
                ContentType = "application/json"
            };
        }

        // GET api/<APIQueriesController>/5
        [HttpGet]
        public string Get()
        {
            return "value1";
        }
    }
}
