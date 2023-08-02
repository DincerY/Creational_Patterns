// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Singleton.GetInstance();
Singleton.GetInstance();
Singleton.GetInstance();
Singleton.GetInstance();
Singleton.GetInstance();
Singleton.GetInstance();
Singleton.GetInstance();
 

//class Singleton
//{
//    private Singleton()
//    {
//        Console.WriteLine($"{nameof(Singleton)} oluşturuldu");
//    }

//    public static Singleton _singleton;

//    public static Singleton GetInstance()
//    {
//        if (_singleton == null)
//        {
//            _singleton = new Singleton();
//        }
//        return _singleton;
//    }
//}



class Singleton
{
    private Singleton()
    {
        Console.WriteLine($"{nameof(Singleton)} oluşturuldu");
    }

    static Singleton()
    {
        _singleton = new Singleton();
    }


    public static Singleton _singleton;

    public static Singleton GetInstance()
    {
        return _singleton;
    }
}