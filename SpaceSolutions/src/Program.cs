// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic;
using SpaceSolutions.src.csvHandler;
using SpaceSolutions.src.dataHandler;
using SpaceSolutions.src.mailHandler;
using SpaceSolutions.src.utils;

//Can make pp loop infinitely/async/multithread if further needed
Console.WriteLine("Welcome to launch calculator");

string path = "";
while (path == "")
{
    Console.WriteLine("please enter path to csv files");
    path = Console.ReadLine();
}
string? senderEmail = "";
while (senderEmail == "")
{
    Console.WriteLine("please enter your outlook email");
    senderEmail = Console.ReadLine();
}
string? senderPassword = "";
while (senderPassword == "")
{
    Console.WriteLine($"Please enter your password to {senderEmail}");
    senderPassword = Console.ReadLine();
} 

string receiverEmail = "";
while (receiverEmail == "")
{
    Console.WriteLine("Please enter receiver email"); 
    receiverEmail = Console.ReadLine();
}

CsvHandler csvHandler = new CsvHandler();
String[] files;
try
{
    files = csvHandler.getCsvFiles(path);
} catch (DirectoryNotFoundException)
{
    Console.WriteLine($"could not get {path}");
    return;
}
Dictionary<string, List<DayModel>> csvDataDict = new Dictionary<string, List<DayModel>>();


foreach (String file in files)
{
    String fileName = Path.GetFileName(file).Split(".csv")[0];
    List<DayModel> csvData;
    try
    {
        csvData = csvHandler.getCsvData(file);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error getting data from csv files, maybe one of the is not following format");
        return;
    }
    csvDataDict.Add(fileName, csvData);
}

DataHandler dataHandler = new DataHandler();

foreach (String key in csvDataDict.Keys)
{
    csvDataDict[key] = dataHandler.checkAndFilter(csvDataDict[key]);
    dataHandler.calculateScore(csvDataDict[key]);
    csvDataDict[key] = dataHandler.getBest(csvDataDict[key]);
}

long bestOverallScore = long.MaxValue;
string[] bestOverallPair = new string[3];
foreach (String key in csvDataDict.Keys)
{
    //Coefficient equa
    int geoCoefficient = Coefficients.geoCoeff;
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

    long keyOverallScore = (long) (csvDataDict[key].First().getScore() + (geoCoefficient * 111 * distanceToEquator));

    if (keyOverallScore < bestOverallScore )
    {
        bestOverallScore = keyOverallScore;
        bestOverallPair = [key, keyOverallScore.ToString(), csvDataDict[key].First().Day.ToString()];
    }
}

string resultCsvPath = csvHandler.createResultsCsv(csvDataDict, path, ",");

MailHandler mailHandler = new MailHandler();
mailHandler.sendResultEmail(senderEmail, senderPassword, receiverEmail, $"Best location {bestOverallPair[0]} on {bestOverallPair[2]}.07", resultCsvPath);