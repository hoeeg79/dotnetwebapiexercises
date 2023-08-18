using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace dotnetwebapi.Controllers;

public interface IPage2
{
}

[ApiController]
public class Page2 : ControllerBase, IPage2
{
    public Page2(SingletonService ss, TransientService ts, ScopedService scs)
    {
        
    }
    
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

    [HttpPost]
    [Route("/FirstPost")]
    public object CustomPostEndpoint([FromBody] MyDto dto)
    {

        return dto;
    }
    
    [HttpGet]
    [Route("/GetWithDTO")]
    public object GetWithDTO([FromQuery] MyDto dto)
    {
        return dto;
    }

    [HttpGet]
    [Route("/ThrowException")]
    public object ThrowException()
    {
        return new BadRequestResult();
    }
}

public class MyDto
{
    [MinLength(4)]
    public string Property1 { get; set; }
    public int Property2 { get; set; }
}


public class TestClass
{
    private IPage2 _page2;

    [SetUp]
    public void Setup()
    {
      //  _page2 = new Page2();
    }

    [Test]
    public void Test1()
    {
        string test = Environment.GetEnvironmentVariable("MyVar");
        
        Console.WriteLine(test);
        
        Assert.AreEqual("Hello World!", test);
    }
}