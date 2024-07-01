namespace ComplexDependencyInjection.Repositories;

public class RepositoryB : IRepositoryB
{
    private readonly Guid guid = Guid.NewGuid();

    public Guid GetGuid()
    {
        return guid;
    }
}

