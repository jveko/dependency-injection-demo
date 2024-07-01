namespace ComplexDependencyInjection.Services;

public interface IServiceSingleton
{
    Guid GetGuid();

}
public class ServiceSingleton : IServiceSingleton
{
    private readonly Guid guid = Guid.NewGuid();

    public Guid GetGuid()
    {
        return guid;
    }
}
