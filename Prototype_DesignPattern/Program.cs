// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Person person = new("a","b",Department.A,100,100);
Person person1 = person.Clone();

interface IPersonCloneable
{
    Person Clone();
}

class Person : IPersonCloneable
{
    public Person(string name,string surname,Department department,int salary,int premium)
    {
        Name = name;
        Surname = surname;
        Department = department;
        Salary = salary;
        Premium = premium;
        Console.WriteLine("Person nesnesi oluşturuldu");
    }

    public string Name { get; set; }
    public string Surname { get; set; }
    public Department Department { get; set; }
    public int Salary { get; set; }
    public int Premium { get; set; }
    public Person Clone()
    {
        return (Person)base.MemberwiseClone();
    }
}

enum Department   
{
    A,B,C
} 

