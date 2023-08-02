// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var msSql = DataBase.GetInstance("msSql");
var oracle = DataBase.GetInstance("oracle");
var mongo = DataBase.GetInstance("mongo");
var msSql2 = DataBase.GetInstance("msSql");
var oracle2 = DataBase.GetInstance("oracle");
var mongo2 = DataBase.GetInstance("mongo");




class DataBase
{
    private DataBase()
    {
        Console.WriteLine($"{nameof(DataBase)} nesnesi oluşturuldu");
    }
    static Dictionary<string,DataBase> _dataBases = new();

    public static DataBase GetInstance(string key)
    {
        if (!_dataBases.ContainsKey(key))
        {
            _dataBases.Add(key,new DataBase());
        }
        return _dataBases[key];
    }

}