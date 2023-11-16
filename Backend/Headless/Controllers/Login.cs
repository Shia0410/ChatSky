using Headless.Models;
using Headless.Services.PayloadValidation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace Headless.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Login : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] UserPayload payload)
        {
            string response = "Error has occured";

            if(payload == null)
            {
                return BadRequest("Payload is ded");
            }
            else
            {
                ValidatePayload vp = new(payload);
                if ((vp.RunChecks()))
                {
                    response = "Success bcrypt needs to run now.";
                }

            }
            return Ok(response);
        }
    }
}