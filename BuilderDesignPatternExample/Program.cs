// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//Araba mercedes = new();
//mercedes.Km = 0;
//mercedes.Model = "cls";
//mercedes.Marka = "Mercedes";
//mercedes.Vites = true;



ArabaDirector director = new ArabaDirector();
Araba mercedes =director.Build(BuilderCreator.Create(BuilderType.Mercedes));
mercedes.ToString();
Araba fiat = director.Build(BuilderCreator.Create(BuilderType.Fiat));
fiat.ToString();
Araba ford = director.Build(BuilderCreator.Create(BuilderType.Ford));
ford.ToString();



class Araba
{
    public string Marka { get; set; }
    public string Model { get; set; }
    public double Km { get; set; }
    public bool Vites { get; set; }
    public override string ToString()
    {
        Console.WriteLine($"{Marka},{Model},{Km},{Vites}");
        return base.ToString();
    }
}



#region Abstract Builder
abstract class IArabaBuilder
{
    public Araba Araba { get; }

    public IArabaBuilder()
    {
        Araba = new Araba();
    }
    public abstract IArabaBuilder SetMarka();
    public abstract IArabaBuilder SetModel();
    public abstract IArabaBuilder SetKm();
    public abstract IArabaBuilder SetVites();
}

#endregion

#region Concrete Builder

class MercedesBuilder : IArabaBuilder
{
    public override IArabaBuilder SetMarka()
    { 
        Araba.Marka = "Mercedes";
        return this;
    }

    public override IArabaBuilder SetModel()
    {
        Araba.Model = "gla";
        return this;
    }

    public override IArabaBuilder SetKm()
    {
        Araba.Km = 0;
        return this;
    }

    public override IArabaBuilder SetVites()
    {
        Araba.Vites = true;
        return this;
    }
}
class FiatBuilder : IArabaBuilder
{
    public override IArabaBuilder SetMarka()
    {
        Araba.Marka = "Fiat";
        return this;
    }

    public override IArabaBuilder SetModel()
    {
        Araba.Model = "doblo";
        return this;
    }

    public override IArabaBuilder SetKm()
    {
        Araba.Km = 0;
        return this;
    }

    public override IArabaBuilder SetVites()
    {
        Araba.Vites = true;
        return this;
    }
}
class FordBuilder : IArabaBuilder
{
    public override IArabaBuilder SetMarka()
    {
        Araba.Marka = "Ford";
        return this;
    }

    public override IArabaBuilder SetModel()
    {
        Araba.Model = "Mustang";
        return this;
    }

    public override IArabaBuilder SetKm()
    {
        Araba.Km = 0;
        return this;
    }

    public override IArabaBuilder SetVites()
    {
        Araba.Vites = true;
        return this;
    }
}

#endregion


#region Factory Method

interface IBuilderFactory
{
    IArabaBuilder CreateAraba();
}

class MercedesBuilderFactory : IBuilderFactory
{
    public IArabaBuilder CreateAraba()
    {
        return new MercedesBuilder();
    }
}
class FiatBuilderFactory : IBuilderFactory
{
    public IArabaBuilder CreateAraba()
    {
        return new FiatBuilder();
    }
}
class FordBuilderFactory : IBuilderFactory
{
    public IArabaBuilder CreateAraba()
    {
        return new FordBuilder();
    }
}

public enum BuilderType
{
    Mercedes, Ford, Fiat
}


class BuilderCreator
{

    public static IArabaBuilder Create(BuilderType builderType)
    {
        IBuilderFactory builderFactory = builderType switch
        {
            BuilderType.Fiat => new FiatBuilderFactory(),
            BuilderType.Ford => new FordBuilderFactory(),
            BuilderType.Mercedes => new MercedesBuilderFactory()
        };
        return builderFactory.CreateAraba();
    }
}

#endregion




class ArabaDirector
{
    public Araba Build(IArabaBuilder arabaBuilder)
    {
        arabaBuilder.SetMarka().SetKm().SetVites().SetModel();
        return arabaBuilder.Araba;
    }
}