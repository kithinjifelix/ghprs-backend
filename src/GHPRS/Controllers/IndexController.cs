using Microsoft.AspNetCore.Mvc;

namespace GHPRS.Controllers
{
    [Route("api")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "API Running";
        }
    }
}
