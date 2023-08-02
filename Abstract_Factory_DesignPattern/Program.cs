// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

DataBase msSQL = new DataBase();
msSQL.Connection = new();
msSQL.Connection.ConnectionString = "...";
msSQL.Command = new();

var result = msSQL.Connection.Connect();
if (result && msSQL.Connection.ConnectionState == ConnectionState.Open )
{
   msSQL.Command.Execute("Select * from ...");
}
msSQL.Connection.Disconnect();

DataBase oracle = new DataBase();
oracle.Connection = new();
oracle.Connection.ConnectionString = "...";
oracle.Command = new();



//Creator creator = new Creator();
//creator.RunComputerFactory(new ToshibaFactory());

class Computer
{
    public Computer(ICpu cpu , IRam ram, IGpu gpu)
    {
        Cpu = cpu;
        Ram = ram;
        Gpu = gpu;
    }
    public ICpu Cpu { get; set; }
    public IRam Ram { get; set; }
    public IGpu Gpu { get; set; }
}

#region Abstract Products

interface ICpu
{
}

interface IRam
{
}
interface IGpu
{
}
#endregion

#region Concrete Products
class Cpu : ICpu
{
    public Cpu(string text)
    {
        Console.WriteLine(text);
    }
}

class Ram : IRam
{
    public Ram(string text)
    {
        Console.WriteLine(text);
    }
}

class Gpu : IGpu
{
    public Gpu(string text)
    {
        Console.WriteLine(text);
    }
}
#endregion

#region Abstract Factory
interface IComputerFactory
{
    ICpu CreateCpu();
    IRam CreateRam();
    IGpu CreateGpu();
}

#endregion

#region Concrete Factories

class AsusFactory : IComputerFactory
{
    public ICpu CreateCpu()
    {
        return new Cpu("Asus cpu oluşturuldu");
    }

    public IRam CreateRam()
    {
        return new Ram("Asus ram oluşturuldu");
    }

    public IGpu CreateGpu()
    {
        return new Gpu("Asus gpu oluşturuldu");
    }
}

class ToshibaFactory : IComputerFactory
{
    public ICpu CreateCpu()
    {
        return new Cpu("Toshiba cpu oluşturuldu");
    }

    public IRam CreateRam()
    {
        return new Ram("Toshiba ram oluşturuldu");
    }

    public IGpu CreateGpu()
    {
        return new Gpu("Toshiba gpu oluşturuldu");
    }
}
#endregion

#region Creator

//class Creator
//{
//    private ICpu _cpu;
//    private IRam _ram;
//    private IGpu _gpu;
//    public Computer RunComputerFactory(IComputerFactory computerFactory)
//    {
//        _ram = computerFactory.CreateRam();
//        _gpu = computerFactory.CreateGpu();
//        _cpu = computerFactory.CreateCpu();
//        Computer computer = new(_cpu,_ram,_gpu);
//        return computer; 
//    }
//}

#endregion



#region Örnek Çalışma

enum DataBaseType
{
    Oracle,MsSql,MySql
}
class DataBase
{
    public DataBase(DataBaseType type,IConnection connection, ICommand command)
    {
        DataBaseType = type;
        Connection = connection;
        Command = command;
    }
    public DataBase()
    {
        
    }
    public DataBaseType DataBaseType { get; set; }
    public IConnection Connection { get; set; }
    public ICommand Command { get; set; }
}

enum ConnectionState
{
    Open,Close
}

#region Abstract Products

interface IConnection
{
    bool Connect();
    bool Disconnect();
    public string ConnectionString { get; set; }
    public ConnectionState ConnectionState { get; set; }
}

interface ICommand
{
    void Execute(string query);
}
#endregion

#region Concrete Products

class Connection : IConnection
{
    string _connectionString;
    public Connection(string connectionString)
    {
        _connectionString = connectionString;
    }
    public Connection()
    {
        
    }
    public string ConnectionString { get => _connectionString; set => _connectionString = value; }

    public ConnectionState ConnectionState { get; set; }
    public bool Connect()
    {
        ConnectionState = ConnectionState.Open;
        return true;
    }
    public bool Disconnect()
    {
        ConnectionState = ConnectionState.Close;
        return true;
    }
}

class Command :ICommand
{
    public void Execute(string query)
    {

    }
}
#endregion

#region Abstract Factory

interface IDataBaseFactory
{
    IConnection CreateConnection();
    ICommand CreateCommand();
}

#endregion

#region Concrete Factory

class MsSqlDatabaseFactory : IDataBaseFactory
{
    public IConnection CreateConnection()
    {
        Connection connection = new Connection();
        connection.ConnectionString = "mssql connection string";
        return connection;
    }

    public ICommand CreateCommand()
    {
        Command command = new Command();
        return command;
    }
}
class OracleDatabaseFactory : IDataBaseFactory
{
    public IConnection CreateConnection()
    {
        Connection connection = new Connection();
        connection.ConnectionString = "Oracle connection string";
        return connection;
    }

    public ICommand CreateCommand()
    {
        Command command = new Command();
        return command;
    }
}

#endregion

#region Creator

class Creator
{
    private IConnection _connection;
    private ICommand _command;
    public DataBase Create(IDataBaseFactory factory)
    {
        _connection = factory.CreateConnection();
        _command = factory.CreateCommand();
        return new DataBase(DataBaseType.MsSql, _connection, _command);
    }
}


#endregion

#endregion