using Microsoft.AspNetCore.Mvc;
using Valideixon.Models;

namespace Valideixon.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost("/")]
        public IActionResult Post([FromBody] CreateUserModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            // ModelState.ClearValidationState(nameof(CreateUserModel));
            // if (!TryValidateModel(model, nameof(CreateUserModel)))
            //     return BadRequest(ModelState);

            return Ok();
        }
    }
}