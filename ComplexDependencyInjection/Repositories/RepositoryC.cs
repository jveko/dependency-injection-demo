namespace ComplexDependencyInjection.Repositories;

public interface IRepositoryC
{
    Guid GetGuid();
}
public class RepositoryC : IRepositoryC
{
    private readonly Guid guid = Guid.NewGuid();

    public Guid GetGuid()
    {
        return guid;
    }
}
