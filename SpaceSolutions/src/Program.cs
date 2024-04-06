// See https://aka.ms/new-console-template for more information
using SpaceSolutions.src.csvHandler;

Console.WriteLine("Hello, World!");
Console.WriteLine("Choose Language/ Sprache");
string? input = Console.ReadLine();

Console.WriteLine("enter path");
string path = Console.ReadLine();
CsvHandler csvHandler = new CsvHandler();
String[] files = csvHandler.getCsvFiles(path);
Console.WriteLine($"Found:");
foreach (String file in files)
{
    Console.WriteLine(file);
}