using ComplexDependencyInjection.Repositories;

namespace ComplexDependencyInjection.Services;

public interface IServiceB
{
    Guid GetGuid();
    Guid GetGuidRepositoryA();
    Guid GetGuidRepositoryB();
    Guid GetGuidRepositoryC();
}
public class ServiceB : IServiceB
{
    private readonly Guid guid = Guid.NewGuid();
    private readonly IRepositoryA _repositoryA;
    private readonly IRepositoryB _repositoryB;
    private readonly IRepositoryC _repositoryC;
    public ServiceB(IRepositoryA repositoryA, IRepositoryB repositoryB, IRepositoryC repositoryC)
    {
        _repositoryA = repositoryA;
        _repositoryB = repositoryB;
        _repositoryC = repositoryC;
    }

    public Guid GetGuid()
    {
        return guid;
    }
    public Guid GetGuidRepositoryA()
    {
        return _repositoryA.GetGuid();
    }

    public Guid GetGuidRepositoryB()
    {
        return _repositoryB.GetGuid();
    }
    public Guid GetGuidRepositoryC() {
        return _repositoryC.GetGuid();
    }
}
