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
    String fileName = Path.GetFileName(file).Split(".csv")[0];
    List<DayModel> csvData = csvHandler.getCsvData(file);
    csvDataDict.Add(fileName, csvData);
}

dataHandler dataHandler = new dataHandler();

foreach (String key in csvDataDict.Keys)
{
    csvDataDict[key] = dataHandler.checkAndFilter(csvDataDict[key]);
    //Console.WriteLine(key + " left " + csvDataDict[key].Count);
    dataHandler.calculateScore(csvDataDict[key]);
    csvDataDict[key] = dataHandler.getBest(csvDataDict[key]);
    //Console.WriteLine(key + " left " + csvDataDict[key].Count);
}

long bestGeoScore = long.MaxValue;
string[] bestGeoPair = new string[2];
foreach (String key in csvDataDict.Keys)
{
    int geoCoefficient = 1;
    double distanceToEquator = 100;
    //Use Google Maps Api rather than hard coding
    if (key.ToLower().Contains("kourou"))
    {
        distanceToEquator = 5.1597;
    } else if (key.ToLower().Contains("kodiak"))
    {
        distanceToEquator = 57.790001;
    } else if (key.ToLower().Contains("tanegashima"))
    {
        distanceToEquator = 30.4000;
    } else if (key.ToLower().Contains("mahia"))
    {
        distanceToEquator = 39.05;
    } else if (key.ToLower().Contains("cape canaveral"))
    {
        distanceToEquator = 28.396837;
    }

    long keyGeoScore = (long) (csvDataDict[key].First().getScore() + (geoCoefficient * 111 * distanceToEquator));

    if (keyGeoScore < bestGeoScore )
    {
        bestGeoScore = keyGeoScore;
        bestGeoPair = [key, keyGeoScore.ToString()];
    }
}
    
Console.WriteLine(bestGeoPair[0] + " " + bestGeoPair[1]);
csvHandler.createResultsCsv(csvDataDict, path, ",");