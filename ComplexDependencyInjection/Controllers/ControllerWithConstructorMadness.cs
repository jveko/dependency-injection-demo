using ComplexDependencyInjection.Repositories;
using ComplexDependencyInjection.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ComplexDependencyInjection.Controllers;

[ApiController]
[Route("[controller]")]
public class ControllerWithConstructorMadness : ControllerBase
{
    private readonly ILogger<ControllerWithConstructorMadness> _logger;
    private readonly IServiceA _serviceA;
    private readonly IServiceB _serviceB;
    private readonly IServiceSingleton _serviceSingleton;
    public ControllerWithConstructorMadness(ILogger<ControllerWithConstructorMadness> logger, IServiceA serviceA, IServiceB serviceB, IServiceSingleton serviceSingleton)
    {
        _logger = logger;
        _serviceA = serviceA;
        _serviceB = serviceB;
        _serviceSingleton = serviceSingleton;
    }

    [HttpGet("WithDepedencyInjection",Name = "WithDepedencyInjection")]
    public IActionResult WithDepedencyInjection()
    {
        var guidServiceA = _serviceA.GetGuid();
        var guidRepositoryAFromServiceA = _serviceA.GetGuidRepsitoryA();
        var guidRepositoryBFromServiceA = _serviceA.GetGuidRepsitoryB();
        var guidRepositoryCFromServiceA = _serviceA.GetGuidRepsitoryC();
        var guidServiceB = _serviceB.GetGuid();
        var guidRepositoryAFromServiceB = _serviceB.GetGuidRepositoryA();
        var guidRepositoryBFromServiceB = _serviceB.GetGuidRepositoryB();
        var guidRepositoryCFromServiceB = _serviceB.GetGuidRepositoryC();
        var guidServiceSingleton = _serviceSingleton.GetGuid();
        return Ok(new
        {
            guidServiceA,
            guidRepositoryAFromServiceA,
            guidRepositoryBFromServiceA ,
            guidRepositoryCFromServiceA,
            guidServiceB,
            guidRepositoryAFromServiceB,
            guidRepositoryBFromServiceB,
            guidRepositoryCFromServiceB,
            guidServiceSingleton
        });
    }

    [HttpGet("WithoutDepedencyInjection", Name = "WithoutDepedencyInjection")]
    public IActionResult WithoutDepedencyInjection()
    {
        var repositoryA = new RepositoryA();
        var repositoryB = new RepositoryB();
        var repositoryC = new RepositoryC();
        var serviceA = new ServiceA(repositoryA, repositoryB, repositoryC);
        var serviceB = new ServiceB(repositoryA, repositoryB, repositoryC);
        var serviceSingleton = new ServiceSingleton();
        var guidServiceA = serviceA.GetGuid();
        var guidRepositoryAFromServiceA = serviceA.GetGuidRepsitoryA();
        var guidRepositoryBFromServiceA = serviceA.GetGuidRepsitoryB();
        var guidRepositoryCFromServiceA = _serviceA.GetGuidRepsitoryC();
        var guidServiceB = serviceB.GetGuid();
        var guidRepositoryAFromServiceB = serviceB.GetGuidRepositoryA();
        var guidRepositoryBFromServiceB = serviceB.GetGuidRepositoryB();
        var guidRepositoryCFromServiceB = _serviceB.GetGuidRepositoryC();
        var guidServiceSingleton = serviceSingleton.GetGuid();
        return Ok(new
        {
            guidServiceA,
            guidRepositoryAFromServiceA,
            guidRepositoryBFromServiceA,
            guidRepositoryCFromServiceA,
            guidServiceB,
            guidRepositoryAFromServiceB,
            guidRepositoryBFromServiceB,
            guidRepositoryCFromServiceB,
            guidServiceSingleton
        });
    }
}
