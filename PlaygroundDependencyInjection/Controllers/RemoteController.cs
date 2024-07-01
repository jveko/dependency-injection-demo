using Microsoft.AspNetCore.Mvc;

namespace PlaygroundDependencyInjection.Controllers;

public interface IBattery
{
   int Charge();
    int Charge2();
}

public class AlkalineBattery : IBattery
{
    public int Charge()
    {
        return 100;
    }

    public int Charge2()
    {
        return 200;
    }
}

public class LithiumBattery : IBattery
{
    public int Charge()
    {
        return 200;
    }

    public int Charge2()
    {
        return 400;
    }
}


[ApiController]
[Route("[controller]")]
public class RemoteController : ControllerBase
{
    private readonly LithiumBattery _battery;
    public RemoteController(LithiumBattery battery)
    {
        _battery = battery;
    }

    [HttpGet("Get")]
    public IActionResult Get()
    {
        return Ok(new
        {
            Charge = _battery.Charge()
        });
    }
}
