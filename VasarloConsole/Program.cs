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

Vasarlo v2 = new Vasarlo("vasarlo2@mail.hu", 0);
Vasarlo v3 = new Vasarlo("vasarlo3@mail.hu", 300);
Vasarlo v4 = new Vasarlo("vasarlo4@mail.hu", 400);
Vasarlo v5 = new Vasarlo("vasarlo5@mail.hu", 500);
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

Console.WriteLine("\n B) feladatrész 3. feladat");
Console.WriteLine("\n\t-1.");
foreach (Vasarlo v in repo.GetVasarloWithLowestBalance())
{
    Console.WriteLine(v);
}

Console.WriteLine("\n\t-2.");
foreach (Vasarlo v in repo.GetVasarloWithHighestBalance())
{
    Console.WriteLine(v);
}

Console.WriteLine("\n\t-3.");
Console.WriteLine("Átlagos pénz 1000-re kerekítve :" + repo.GetAvgBalanceRounded());

Console.WriteLine("\n\t-4.");
Random random = new Random();
int randomMin = random.Next((int)Math.Ceiling(repo.Vasarlok.Min(v => v.Balance)), (int)Math.Floor(repo.Vasarlok.Max(v => v.Balance)));
int randomMax = random.Next(randomMin, (int)Math.Floor(repo.Vasarlok.Max(v => v.Balance)));
foreach (Vasarlo v in repo.GetVasarlokWithBalanceBetween(randomMin, randomMax))
{
    if (v.Email != null)
    {
        Console.WriteLine(v);
    }
    else
    {
        Console.WriteLine("Nincs ilyen vásárló");
    }
}

Console.WriteLine("\n\t-5.");
Console.WriteLine("Összes összeg:" + repo.SumOfBalances());

Console.WriteLine("\n\t-6.");
Console.WriteLine("A keresett vásárló (vasarlo.valer@sokatveszek.hu): " + repo.GetVasarloByEmail("vasarlo.valer@sokatveszek.hu"));

Console.WriteLine("\n\t-7.");
foreach(KeyValuePair<string, double> kvp in repo.CategorizeVasarlok())
{
    Console.WriteLine(kvp.Key + " : " + kvp.Value);
}
