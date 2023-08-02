// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
ArabaDirector diretor = new();
Araba mercedes = diretor.Build(BuilderCreator.Create(BuilderType.Opel));
mercedes.ToString();

#region Interface ile builder pattern

//class Araba
//{
//    public string Marka { get; set; }
//    public string Model { get; set; }
//    public double Km { get; set; }
//    public bool Vites { get; set; }
//    public override string ToString()
//    {
//        Console.WriteLine($"{Marka} marka araba {Model} modelinde {Km} kilometrede {Vites} vites olarak üretilmiştir");
//        return base.ToString();
//    }
//}

//interface IArabaBuilder
//{
//    Araba Araba { get;}
//    IArabaBuilder SetMarka();
//    IArabaBuilder SetModel();
//    IArabaBuilder SetKm();
//    IArabaBuilder SetVites();
//}



//#region Concrete Builder
//class OpelBuilder : IArabaBuilder

//{
//    public Araba Araba { get; }
//    public OpelBuilder()
//    {
//        Araba = new Araba();
//    }
//    public IArabaBuilder SetMarka()
//    {
//        Araba.Marka = "Opel";
//        return this;
//    }
//    public IArabaBuilder SetModel()
//    {
//        Araba.Model = "....";
//        return this;
//    }
//    public IArabaBuilder SetKm()
//    {
//        Araba.Km = 120;
//        return this;
//    }
//    public IArabaBuilder SetVites()
//    {
//        Araba.Vites = true;
//        return this;
//    }
//}

//class MercedesBuilder: IArabaBuilder
//{
//    public Araba Araba { get;}

//    public MercedesBuilder()
//    {
//        Araba = new Araba();
//    }
//    public IArabaBuilder SetMarka()
//    {
//        Araba.Marka = "Mercedes";
//        return this;
//    }
//    public IArabaBuilder SetModel()
//    {
//        Araba.Model = "E200";
//        return this;
//    }
//    public IArabaBuilder SetKm()
//    {
//        Araba.Km = 500;
//        return this;
//    }
//    public IArabaBuilder SetVites()
//    {
//        Araba.Vites = true;
//        return this;
//    }
//}

//#region Director

//class ArabaDiretor
//{
//    public Araba Build(IArabaBuilder builder)
//    {
//        builder.SetKm().SetVites().SetMarka().SetModel();
//        return builder.Araba;
//    }
//}
//#endregion

#endregion

#region Abstract class ile builder pattern

class Araba
{
    public string Marka { get; set; }
    public string Model { get; set; }   
    public double Km { get; set; }
    public bool Vites { get; set; }
    public override string ToString()
    {
        Console.WriteLine($"{Marka} marka araba {Model} modelinde {Km} kilometrede {Vites} vites olarak üretilmiştir");
        return base.ToString();
    }
}

abstract class AbstractArabaBuilder
{
    public Araba Araba { get; }

    public AbstractArabaBuilder()
    {
        Araba = new Araba();
    }
    public abstract AbstractArabaBuilder SetMarka();
    public abstract AbstractArabaBuilder SetModel();
    public abstract AbstractArabaBuilder SetKm();
    public abstract AbstractArabaBuilder SetVites();
}
#region Concrete Builder
class OpelBuilder : AbstractArabaBuilder

{
    public override AbstractArabaBuilder SetMarka()
    {
        Araba.Marka = "Opel";
        return this;
    }

    public override AbstractArabaBuilder SetModel()
    {
        Araba.Model = "Opel";
        return this;
    }

    public override AbstractArabaBuilder SetKm()
    {
        Araba.Km = 150;
        return this;
    }

    public override AbstractArabaBuilder SetVites()
    {
        Araba.Vites = true;
        return this;
    }

}
class MercedesBuilder : AbstractArabaBuilder
{
    
    public override AbstractArabaBuilder SetMarka()
    {
        Araba.Marka = "Mercedes";
        return this;
    }

    public override AbstractArabaBuilder SetModel()
    {
        Araba.Model = "E200";
        return this;
    }

    public override AbstractArabaBuilder SetKm()
    {
        Araba.Km = 160;
        return this;
    }

    public override AbstractArabaBuilder SetVites()
    {
        Araba.Vites = true;
        return this;
    }
}
 
#endregion

#region Director

class ArabaDirector
{
    public Araba Build(AbstractArabaBuilder builder)
    {
        builder.SetKm().SetMarka().SetModel().SetVites();
        return builder.Araba;
    }
}

#region Creator

class BuilderCreator
{
    public static AbstractArabaBuilder Create(BuilderType type)
    {
        return type switch
        {
            BuilderType.Opel => new OpelBuilder(),
            BuilderType.Mercedes => new MercedesBuilder(),
        };
    }
}

#endregion

enum BuilderType
{
    Opel,Mercedes
}

#endregion
#endregion






