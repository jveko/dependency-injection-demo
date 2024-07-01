using ComplexDependencyInjection.Repositories;

namespace ComplexDependencyInjection.Services;

public interface IServiceA
{
    Guid GetGuid();
    Guid GetGuidRepsitoryA();
    Guid GetGuidRepsitoryB();
    Guid GetGuidRepsitoryC();
}
public class ServiceA : IServiceA
{
    private readonly Guid guid = Guid.NewGuid();
    private readonly IRepositoryA _repositoryA;
    private readonly IRepositoryB _repositoryB;
    private readonly IRepositoryC _repositoryC;
    public ServiceA(IRepositoryA repositoryA, IRepositoryB repositoryB, IRepositoryC repositoryC)
    {
        _repositoryA = repositoryA;
        _repositoryB = repositoryB;
        _repositoryC = repositoryC;
    }

    public Guid GetGuid()
    {
        return guid;
    }
    public Guid GetGuidRepsitoryA()
    {
        return _repositoryA.GetGuid();
    }

    public Guid GetGuidRepsitoryB()
    {
        return _repositoryB.GetGuid();
    }

    public Guid GetGuidRepsitoryC()
    {
        return _repositoryC.GetGuid();
    }
}
