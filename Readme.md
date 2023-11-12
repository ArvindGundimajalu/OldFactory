# OldFactory

Old Factory is a simple repository that helps to reduce dependency between classes.

At its core it holds on to a map between object types. Types can be registered with the factory using the Register method or by passing a Dictionary<type,type> object. 

```cs
using OldFactory.Contracts;
using OldFactory.Factory;

IFactory objectFactory = new ObjectFactory();

objectFactory.Register(typeof(ITest), typeof(Test));

var testObject = objectFactory.GetInstance<ITest>();

testObject?.TestMethod();

```

```cs
using OldFactory.Contracts;
using OldFactory.Factory;

IFactory objectFactory = new ObjectFactory(new Dictionary<Type,Type>() {
    {typeof(ITest), typeof(Test)}
});

testObject = objectFactory.GetInstance<ITest>();

testObject?.TestMethod();
```

# Registery Context 
The factory supports stacking object context. It implements the dispose method. Hence if certaing constructors are to be replaces that can be achived by wrapping the registration with a using block.

In the below example the Test2 implementation is swapped in temporarily inside the using block.

```cs
using OldFactory.Contracts;
using OldFactory.Factory;

IFactory objectFactory = new ObjectFactory();

objectFactory.Register(typeof(ITest), typeof(Test));

using(var tempObjectFactory = new ObjectFactory(objectFactory))
{
    tempObjectFactory.Register(typeof(ITest), typeof(Test2));

    testObject = tempObjectFactory.GetInstance<ITest>();

    testObject?.TestMethod();
}

```

This is useful while mocking classes in unit tests.