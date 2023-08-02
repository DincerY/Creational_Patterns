// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Person person = new Person("Dincer", "Yigit", Department.A, 10, 10); 
Person person2 = new Person("Gamze", "Yigit", Department.A, 10, 10);

Person person3 = person.Clone();
person3.Name = "Naz";

Console.WriteLine();

#region Abstract Prototype

interface IPersonCloneable
{
    Person Clone();
}

#endregion 

#region Concrete Prototype

class Person : IPersonCloneable
{
    public Person(string name, string surname, Department department,int salary,int premium)
    {
        Name = name;
        Surname = surname;
        Department = department;
        Salary = salary;
        Premium = premium;
    }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Department Department { get; set; }
    public int Salary { get; set; }
    public int Premium { get; set; }
    public Person Clone()
    {
       object Object = base.MemberwiseClone();
       return (Person)Object;
    }
}

#endregion

enum Department
{
    A,B, C
}

