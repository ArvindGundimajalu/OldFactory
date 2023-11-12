using OldFactory.Contracts;
using OldFactory.Factory;

IFactory objectFactory = new ObjectFactory();

objectFactory.Register(typeof(ITest), typeof(Test));

var testObject = objectFactory.GetInstance<ITest>();

testObject?.TestMethod();

objectFactory = new ObjectFactory(new Dictionary<Type,Type>() {
    {typeof(ITest), typeof(Test)}
});

testObject = objectFactory.GetInstance<ITest>();

testObject?.TestMethod();

using(var tempObjectFactory = new ObjectFactory(objectFactory))
{
    tempObjectFactory.Register(typeof(ITest), typeof(Test2));

    testObject = tempObjectFactory.GetInstance<ITest>();

    testObject?.TestMethod();
}