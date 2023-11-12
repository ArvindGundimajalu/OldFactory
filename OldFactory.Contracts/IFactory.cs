namespace OldFactory.Contracts;

public interface IFactory : IDisposable
{
    public T? GetInstance<T>();

    public void Register(Type iface, Type instance);
}
