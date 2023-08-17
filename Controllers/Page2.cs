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
    public string GetHead([FromHeader] string someValue)
    {
        
        Console.WriteLine($"Received header value: {someValue}");
        return $"check the http request headers for: {someValue}";
    }
    
    [HttpGet]
    [Route("/setHeaderManuallyUsingContext")]
    public object SetHeader()
    {
        HttpContext.Response.Headers["RandomHeaderName"] = "RandomValue";
        return null;
    }
    
    [HttpGet]
    [Route("/readHeader2")]
    public object ReadHeader([FromHeader] string headerName)
    {
        return HttpContext.Request.Headers[headerName][0];
    }

    [HttpGet]
    [Route("/returnJSON")]
    public object GetJson()
    {
        return new
        {
            property1 = "tissemand",
            property2 = "flereTissemænd"
        };
    }

    [HttpGet]
    [Route("/returnError")]
    public object GetError()
    {
        HttpContext.Response.StatusCode = 419;

        return null;
    }
}