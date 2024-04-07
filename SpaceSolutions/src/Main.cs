// See https://aka.ms/new-console-template for more information
using SpaceSolutions.src.csvHandler;

Console.WriteLine("Hello, World!");

Console.WriteLine("Language/Sprache");
Console.WriteLine("english - for english");
Console.WriteLine("deutsch - fur deutsch");
string? input = Console.ReadLine();
switch (input)
{
    case "english":
        break;
    case "deutsch":
        break;
    default:
        input = "english"; // for testing purposes
        break;

}

Console.WriteLine("Enter csv folder path");
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
