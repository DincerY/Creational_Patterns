// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var msSql = DataBase.GetInstance("Mss");
msSql.ConnectionString("denemeMssql");
var oracle = DataBase.GetInstance("oracle");
oracle.ConnectionString("denemeOracle");
var mongoDb = DataBase.GetInstance("mongo");

var msSql2 = DataBase.GetInstance("Mss");
var oracle2 = DataBase.GetInstance("oracle");
var mongoDb2 = DataBase.GetInstance("mongo");

var gmail = MailService.GetInstance("gmail");
gmail.MailType = "gmail";
gmail.GetMailType();
var hotMail = MailService.GetInstance("hotMail");
hotMail.MailType = "hotMail";
hotMail.GetMailType();

var denemehotmail = MailService.GetInstance("hotMail");
denemehotmail.GetMailType();



class DataBase
{
    private DataBase()
    {
        Console.WriteLine($"{nameof(DataBase)} nesnesi üretildi");
    }

    static Dictionary<string, DataBase> _dataBases = new Dictionary<string, DataBase>();

    public static DataBase GetInstance(string key)
    {
        if (!_dataBases.ContainsKey(key))
        {
            _dataBases[key] = new DataBase();
        }
        return _dataBases[key];
    }

    public void ConnectionString(string connectionString)
    {
        Console.WriteLine($"{connectionString}'e bağlanıldı");
    }
}


#region Example

//uygulamada bir tane mail service kullanmıcaz fakat birden fazla sınırlı sayıda mail service kullanıcaz multiton d.p
class MailService
{
    public string MailType { get; set; }
    private MailService()
    {

    }
    static Dictionary<string,MailService> _mailServices = new Dictionary<string,MailService>();
    public static MailService GetInstance(string key)
    {
        if (!_mailServices.ContainsKey(key))
        {
            _mailServices[key] = new MailService();
        }
        return _mailServices[key];
    }

    public void GetMailType()
    {
        Console.WriteLine($"{MailType} ile gönderildi");
    }
}

#endregion