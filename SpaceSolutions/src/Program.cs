// See https://aka.ms/new-console-template for more information
using SpaceSolutions.src.csvHandler;

Console.WriteLine("Hello, World!");

Console.WriteLine("Choose Language/ Sprache");
string? input = Console.ReadLine();
if (input == "")
{
    input = "english";
}

Console.WriteLine("enter path");
string path = Console.ReadLine();
if (path == "")
{
    path = "C:\\Users\\steel\\Desktop\\WeatherStations";
}

CsvHandler csvHandler = new CsvHandler();
String[] files = csvHandler.getCsvFiles(path);
List<List<DayModel>> csvDataList = new List<List<DayModel>>();

foreach (String file in files)
{
    List<DayModel> csvData = csvHandler.getCsvData(file);
    csvDataList.Add(csvData);
}
