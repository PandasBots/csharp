using ComposicaoExercicio.Entities.Enums;
using ComposicaoExercicio.Entities;
using System.Globalization;
using System;
using System.Xml.Linq;

// 1. Variáveis do Worker e Departament
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Enter Deparments Name: ");
string detpName = Console.ReadLine();
Console.WriteLine("Enter Workers Data: ");
Console.Write("Name ");
string name = Console.ReadLine();
Console.Write("Level: (Junior/MidLevel/Senior): ");
// Converte a string para WorkerLevel
WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
Console.Write("BaseSalary ");
double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

// 2. Instanciar os objetos do dept e worker.
// Departamento com nome
Department dept = new Department(detpName);
// Worker com nome, level, basesalary e dept.
Worker worker = new Worker(name, level, baseSalary, dept);

// 3. Perguntar quantos contratos irá ter
Console.Write("How many contracts: ");
int n = int.Parse(Console.ReadLine());

for(int i = 1; i <= n; i++)
{
    Console.WriteLine($"Enter #{i} contract data: ");
    Console.Write("Date (DD/MM/YYYY): ");
    DateTime date = Convert.ToDateTime(Console.ReadLine(), System.Globalization.CultureInfo.GetCultureInfo("en-GB").DateTimeFormat);
    Console.Write("Value per Hour: ");
    double valeuPerHour= double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
    Console.Write("Duration (hours): ");
    int hours = int.Parse(Console.ReadLine());

    // Instanciar contrato
    HourContract contract = new HourContract(date, valeuPerHour, hours);
    // Adicionar o contrato a lista de contratos do trabalhador
    worker.AddContract(contract);
}

Console.WriteLine("Enter Month/Year to calculate Income (MM/YYYY): ");
string monthAndYear = Console.ReadLine();
int month = int.Parse(monthAndYear.Split("/")[0]);
int year = int.Parse(monthAndYear.Split("/")[1]);
Console.WriteLine($"Month: {month}, Year {year}: income: {worker.Income(month, year)}");


Console.WriteLine($"Name: {worker.Name}");
Console.WriteLine($"Department: {worker.Department.Name}");
Console.WriteLine($"Income for: {monthAndYear}: {worker.Income(year, month)}");



















