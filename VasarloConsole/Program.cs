using System.Linq.Expressions;
using VasarloConsole.Models;
using VasarloConsole.Repos;

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

if(valer.CanBuy(45000))
{
    Console.WriteLine(valer.Name + " meg tudja venni a 45000 Ft-s monitort");
}
else
{
    Console.WriteLine(valer.Name + " nem tudja megvenni a 45000 Ft-s monitort");
}

Console.WriteLine("\n 3. feladat");
try
{
    valer.SpendMoney(-1000);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
try
{
    valer.SpendMoney(200000);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
try
{
    valer.SpendMoney(5000);
    Console.WriteLine($"{valer.Name} új keretösszege: {valer.Balance} Ft");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("\n 4. feladat");

Vasarlo v2 = new Vasarlo("vasarlo2mail", 0);
Vasarlo v3 = new Vasarlo("vasarlo3mail", 300);
Vasarlo v4 = new Vasarlo("vasarlo4mail", 400);
Vasarlo v5 = new Vasarlo("vasarlo5mail", 500);
Console.WriteLine(v2);
Console.WriteLine(v3);
Console.WriteLine(v4);
Console.WriteLine(v5);


Console.WriteLine("\n B) feladatérsz 1-2. feladat");
VasarloRepo repo = new VasarloRepo();
repo.AddVasarlo(valer);
repo.AddVasarlo(v2);
repo.AddVasarlo(v3);
repo.AddVasarlo(v4);
repo.AddVasarlo(v5);

Console.WriteLine($"A tárolt vásárlók száma: {repo.Vasarlok.Count} db");

foreach (Vasarlo v in repo.Vasarlok)
{
    Console.WriteLine(v);
}

try
{
    repo.RemoveVasarlo("vasarlo3mail");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
Console.WriteLine($"A tárolt vásárlók száma 1 törlés után: {repo.Vasarlok.Count} db");