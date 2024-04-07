// See https://aka.ms/new-console-template for more information
using SpaceSolutions.src.csvHandler;
using SpaceSolutions.src.dataHandler;

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
Dictionary<string, List<DayModel>> csvDataDict = new Dictionary<string, List<DayModel>>();

foreach (String file in files)
{
    String fileName = Path.GetFileName(file);
    List<DayModel> csvData = csvHandler.getCsvData(file);
    csvDataDict.Add(fileName, csvData);
}

dataHandler dataHandler = new dataHandler();

foreach (String key in csvDataDict.Keys)
{
    csvDataDict[key] = dataHandler.checkAndFilter(csvDataDict[key]);
    Console.WriteLine(key + " left " + csvDataDict[key].Count);
    dataHandler.calculateScore(csvDataDict[key]);
    csvDataDict[key] = dataHandler.getBest(csvDataDict[key]);
    Console.WriteLine(key + " left " + csvDataDict[key].Count);
}

foreach (String key in csvDataDict.Keys)
{
    foreach (DayModel day in csvDataDict[key])
    {
        Console.WriteLine($"day: {day.Day} {day.Temperature} {day.Wind} {day.Humidity} {day.Precipation} {day.Lightning} {day.Clouds}");
    }
}