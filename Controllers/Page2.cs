using Microsoft.AspNetCore.Mvc;

namespace dotnetwebapi.Controllers;

[ApiController]
public class Page2 : ControllerBase
{
    [HttpGet]
    [Route("/{id}")]
    public string GetId([FromRoute] int id)
    {
        return $"ID is {id} ";
    }
    
    [HttpGet]
    [Route("/readQuery")]
    public string GetQuery([FromQuery] string someValue)
    {
        return $"ID is {someValue}";
    }
    
    [HttpGet]
    [Route("/readHeader")]
    public string Get([FromHeader] string someValue)
    {
        
        Console.WriteLine($"Received header value: {someValue}");
        return $"check the http request headers for: {someValue}";
    }
}