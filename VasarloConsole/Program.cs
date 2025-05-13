using VasarloConsole.Models;

Console.WriteLine("\n 1. feladat");
try
{
    Vasarlo negativ = new Vasarlo("negativemail", -500);
}
catch (NegativeBalanceException ex)
{
    Console.WriteLine(ex.Message);
}

Vasarlo valer = new Vasarlo("Vásárló Valér", "vasarlo.valer@sokatveszek.hu", 20000);
Console.WriteLine(valer);

Console.WriteLine("\n 2. feladat");
valer.Increase(5000);
valer.Increase(10000);
Console.WriteLine(valer.Name +" összege ennyiszer lett növelve: "+valer.Increases);

Console.WriteLine("\n 3. feladat");
if(valer.CanBuy(45000))
{
    Console.WriteLine(valer.Name + " meg tudja venni a 45000 Ft-s monitort");
}
else
{
    Console.WriteLine(valer.Name + " nem tudja megvenni a 45000 Ft-s monitort");
}
