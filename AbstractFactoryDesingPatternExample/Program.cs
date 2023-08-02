// See https://aka.ms/new-console-template for more information

using System.Reflection.Metadata.Ecma335;
using static Creator;

Console.WriteLine("Hello, World!");

ComputerCreator creator = new();
Computer asusComputer = creator.CreateComputer(ComputerType.Asus);
Computer msiComputer = creator.CreateComputer(ComputerType.Msi);


Creator creatorDatabase  = new();
creatorDatabase.Create(Creator.FactoryType.Mssql);
creatorDatabase.CreateDeneme(new MssqlDataBase());



class Computer
{
    public ICpu Cpu { get; set; }
    public IGpu Gpu { get; set; }
    public IRam Ram { get; set; }

    public Computer(ICpu cpu,IGpu gpu,IRam ram)
    {
        Cpu = cpu;
        Gpu = gpu;
        Ram = ram;
    }

}

#region Abstract Products

interface ICpu
{
    
}

interface IGpu
{
    
}

interface IRam
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
class Gpu : IGpu
{
    public Gpu(string text)
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
#endregion

#region Abstract Factory

interface IComputerFactory
{
    ICpu CreateCpu();
    IGpu CreateGpu();
    IRam CreateRam();
}

#endregion

#region Concrete Factory

class AsusFactory : IComputerFactory
{
    public ICpu CreateCpu()
    {
        return new Cpu("Asus Cpu");
    }

    public IGpu CreateGpu()
    {
        return new Gpu("Asus Gpu");
    }

    public IRam CreateRam()
    {
        return new Ram("Asus Ram");
    }
}
class MsiFactory : IComputerFactory
{
    public ICpu CreateCpu()
    {
        return new Cpu("Msi Cpu");
    }

    public IGpu CreateGpu()
    {
        return new Gpu("Msi Gpu");
    }

    public IRam CreateRam()
    {
        return new Ram("Msi Ram");
    }
}

#endregion

#region Creator

enum ComputerType
{
    Asus,Msi
}

class ComputerCreator
{
    ICpu _cpu;
    IGpu _gpu;
    IRam _ram;

    public Computer CreateComputer(ComputerType computerType)
    {
        IComputerFactory factory = computerType switch
        {
            ComputerType.Asus => new AsusFactory(),
            ComputerType.Msi => new MsiFactory(),
        };


        _cpu = factory.CreateCpu();
        _gpu = factory.CreateGpu();
        _ram = factory.CreateRam();
        return new(_cpu, _gpu, _ram);  
    }
}

#endregion

//interface IFactoryFactory
//{
//    IComputerFactory CreateAsusComputerFactory();
//    IComputerFactory CreateMsiComputerFactory();

//}
//class FactoryFactory : IFactoryFactory
//{
//    public IComputerFactory CreateAsusComputerFactory()
//    {
//        return new AsusFactory();
//    }

//    public IComputerFactory CreateMsiComputerFactory()
//    {
//        return new MsiFactory();
//    }
//}

//class FactoryCreator
//{
//    public enum FactoryType
//    {
//        Asus,Msi
//    }
//    public void Creator(FactoryType factoryType)
//    {
//        IComputerFactory computerFactory = factoryType switch
//        {
//            FactoryType.Asus => new AsusFactory(),
//            FactoryType.Msi => new MsiFactory()
//        };
//    }
//}




class DataBase
{
    public DataBase(IConnection connection, ICommand command)
    {
        Command = command;
        Connection = connection;
    }
    public IConnection Connection { get; set; }
    public ICommand Command { get; set; }
}


#region Abstract Product

interface IConnection
{
    
}

interface ICommand
{
    
}

#endregion

#region Concrete Product

class Connection : IConnection
{
    public Connection(string text)
    {
        Console.WriteLine(text);
    }
}
class Command : ICommand
{
    public Command(string text)
    {
        Console.WriteLine(text);
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

class MssqlDataBase : IDataBaseFactory
{
    public IConnection CreateConnection()
    {
        return new Connection("mssql connection");
    }

    public ICommand CreateCommand()
    {
        return new Command("mssql command");
    }
}
class OracleDataBase : IDataBaseFactory
{
    public IConnection CreateConnection()
    {
        return new Connection("Oracle connection");
    }

    public ICommand CreateCommand()
    {
        return new Command("Oracle command");
    }
}
class PostgresDataBase : IDataBaseFactory
{
    public IConnection CreateConnection()
    {
        return new Connection("Postgres connection");
    }

    public ICommand CreateCommand()
    {
        return new Command("Postgres command");
    }
}

#endregion

#region Creator

class Creator
{ 
    ICommand _command;
    IConnection _connection;
    public enum FactoryType
    {
        Oracle,Postgres,Mssql
    }
    public DataBase Create(FactoryType factoryType)
    {
        IDataBaseFactory factory = factoryType switch
        {
            FactoryType.Mssql => new MssqlDataBase(),
            FactoryType.Oracle => new OracleDataBase(),
            FactoryType.Postgres => new PostgresDataBase(),
        };
        _command = factory.CreateCommand();
        _connection = factory.CreateConnection();
        return new DataBase(_connection,_command);
    }

    public DataBase CreateDeneme(IDataBaseFactory factory)
    {
        _command = factory.CreateCommand();
        _connection = factory.CreateConnection();
        return new DataBase(_connection, _command);
    }
}


#endregion