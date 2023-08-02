// See https://aka.ms/new-console-template for more information
using System.Collections.Concurrent;
Console.WriteLine("Hello, World!");

ObjectPool<X> pools = new();
var x = pools.Get(() => new X());
pools.Return(x);

var x2 = pools.Get();


class ObjectPool<T> where T : class
{
     readonly ConcurrentBag<T> _instances;

     public ObjectPool()
     {
         _instances = new();
     }

     public T Get(Func<T>? objectGenerator = null)
     {
         return _instances.TryTake(out T instance) ? instance : objectGenerator();
     }

     public void Return(T instance)
     {
        _instances.Add(instance);
     }
}



class X
{
    public int Count { get; set; }

    public void Write()
    {
        Console.WriteLine(Count);
    }
    public X()
    {
        Console.WriteLine("X üretim maliyeti");
    }

    ~X()
    {
        Console.WriteLine("X imha maliyeti");
    }
}