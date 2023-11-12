using OldFactory.Contracts;
using System.Collections.Generic;
using System.ComponentModel;
namespace OldFactory.Factory;

public class ObjectFactory : IFactory
{
    IDictionary<Type, Type> _registery ;

    private IFactory _parent;

    public ObjectFactory(IFactory parent = null)
    {
        _registery = new Dictionary<Type, Type>();
        _parent = parent;
    }

    public ObjectFactory(IDictionary<Type, Type> registery, IFactory parent = null)
    {
        _registery = registery;
        _parent = parent;
    }

    public void Dispose()
    {
        //Do nothing
    }

    public T? GetInstance<T>()
    {
        if(_registery.ContainsKey(typeof(T)))
            return (T?) Activator.CreateInstance(_registery[typeof(T)]);
        else
            return _parent.GetInstance<T>();
    }

    public void Register(Type iface, Type instance)
    {

        _registery.Add(iface, instance);
    }
}
