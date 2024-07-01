namespace ComplexDependencyInjection.Repositories;

public interface IRepositoryA
{
    Guid GetGuid();
}
public class RepositoryA : IRepositoryA
{
    private readonly Guid guid = Guid.NewGuid();

    public Guid GetGuid()
    {
        return guid;
    }
}
