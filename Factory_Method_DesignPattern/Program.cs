// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



#region Factory yöntemi
//Creator.Create(Creator.BankTypes.Garanti);


//interface IBank
//{

//}

//class GarantiBank : IBank
//{
//    public GarantiBank()
//    {
//        Console.WriteLine($"{nameof(GarantiBank)} nesnesi oluşturuldu");
//    }
//}

//class TebBank : IBank
//{
//    public TebBank()
//    {
//        Console.WriteLine($"{nameof(TebBank)} nesnesi oluşturuldu");
//    }
//}

//class IsBank : IBank
//{
//    public IsBank()
//    {
//        Console.WriteLine($"{nameof(IsBank)} nesnesi oluşturuldu");
//    }
//}

//class Creator
//{
//    public enum BankTypes
//    {
//        Garanti, Teb, Is
//    }
//    public static IBank Create(BankTypes bankTypes)
//    {
//        IBank bank = null;
//        switch (bankTypes)
//        {
//            case BankTypes.Garanti:
//                bank = new GarantiBank();
//                break;
//            case BankTypes.Teb:
//                bank = new TebBank();
//                break;
//            case BankTypes.Is:
//                bank = new IsBank();
//                break;
//        }
//        return bank;
//    }
//}



#endregion

#region Factory Method Yöntemi

interface IBank
{

}

class GarantiBank : IBank
{
    public GarantiBank()
    {
        Console.WriteLine($"{nameof(GarantiBank)} nesnesi oluşturuldu");
    }
}

class TebBank : IBank
{
    public TebBank()
    {
        Console.WriteLine($"{nameof(TebBank)} nesnesi oluşturuldu");
    }
}

class IsBank : IBank
{
    public IsBank()
    {
        Console.WriteLine($"{nameof(IsBank)} nesnesi oluşturuldu");
    }
}

interface IBankFactory
{
    IBank Create();
}

class GarantiFactory : IBankFactory
{
    public IBank Create()
    {
        return new GarantiBank();
    }
}

class TebFactory : IBankFactory
{
    public IBank Create()
    {
        return new TebBank();
    }
}

class IsFactory : IBankFactory
{
    public IBank Create()
    {
        return new IsBank();
    }
}

class Creator
{
    public enum ProductType
    {
        Garanti,Teb,Is
    }
    public IBank Run(ProductType productType)
    {
        IBankFactory factory = productType switch
        {
            ProductType.Garanti => new GarantiFactory(),
            ProductType.Teb => new TebFactory(),
            ProductType.Is => new IsFactory(),
        };
        return factory.Create();
    }
}

#endregion