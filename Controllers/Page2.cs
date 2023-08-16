using Microsoft.AspNetCore.Mvc;

namespace dotnetwebapi.Controllers;

[ApiController]
public class Page2 : ControllerBase
{
    [HttpGet]
    [Route("/{id}")]
    public string Get([FromRoute] int id, [FromHeader] string someValue)

{
        return $"ID is {id} " + someValue;
    }
}