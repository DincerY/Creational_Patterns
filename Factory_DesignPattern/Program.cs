 // See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

BankCreator bankCreator = new BankCreator();
bankCreator.Create(new GarantiBank());
 //burada pattern ı bu şekilde uygulamak tam bir ahmaklık cünkü create metoduna değer girerken terkaradan newleme yapıyoruz ve her create işinde tekrar tekrar aynı maliyeti ödicez bunu yerinde direk normla bir şekilde üretip ondan sonra referansa atasaydık ya neden uğraştık bu kadar :DDDDDD. Ondan dolayı creator nesnesi nesne uretme maliyetini karşılamalı ve sorumluluğu oraya yüklemeliyiz

 interface IBank
 {
 }
 class GarantiBank : IBank 
 {
     public GarantiBank()
     {
         Console.WriteLine($"{nameof(GarantiBank)} nesnesi üretildi");
     }
 }
 class HalkBank : IBank
 {

 }
 class CredentialVakifBank : IBank
 {

 }
 class VakifBank : IBank
 {

 }

 class BankCreator
 {
     public IBank Create(IBank _bank)
     {
         return _bank;
     }
 }

