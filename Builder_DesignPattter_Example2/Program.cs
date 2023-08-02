// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Yemek yemek = new Yemek();
yemek.YemekTipi = YemekTipi.Etli;
yemek.TuzOranı = 3;
yemek.YemekAdi = "Etli pilav";

Yemek etliPilav = Director.Build(new EtliPilav());



class Yemek
{
    public string YemekAdi { get; set; }
    public YemekTipi YemekTipi { get; set; }
    public int TuzOranı { get; set; }
}

enum YemekTipi
{
    Sulu,Etli,Sebzeli
}

//Abstract Builder

abstract class YemekBuilder
{
    public Yemek Yemek { get; set; }

    public YemekBuilder()
    {
        Yemek = new Yemek();
    }
    public abstract YemekBuilder SetYemekAdi();
    public abstract YemekBuilder SetTuzOranı();
    public abstract YemekBuilder SetYemekTipi();
}

//Concrete Builder
class EtliPilav : YemekBuilder
{
    public override YemekBuilder SetYemekAdi()
    {
        Yemek.YemekAdi = "Etli pilav";
        return this;
    }

    public override YemekBuilder SetTuzOranı()
    {
        Yemek.TuzOranı = 10;
        return this;
    }

    public override YemekBuilder SetYemekTipi()
    {
        Yemek.YemekTipi = YemekTipi.Etli;
        return this;
    }
}

//Director
class Director
{
    public static Yemek Build(YemekBuilder builder)
    {
        return builder.SetYemekAdi().SetTuzOranı().SetYemekTipi().Yemek;
        //return builder.Yemek;

    }
}