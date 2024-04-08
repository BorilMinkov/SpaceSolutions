using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpaceSolutions.src.csvHandler
{
    /// <summary>
    /// Class that handles finding, reading and writing csv files.
    /// </summary>
    public class CsvHandler
    {
        /// <summary>
        /// Creates an array of strings, contianing the path to every .csv file in the path folderPath
        /// </summary>
        /// <param name="folderPath"> the path to the folder containing the csv files </param>
        /// <returns>an array containing the paths to the csv files</returns>
        public string[] getCsvFiles(String folderPath)
        {
            string[] files = Directory.GetFiles(folderPath, "*.csv");
            return files;
        }

        /// <summary>
        /// Creates a list of days from a csv file
        /// </summary>
        /// <param name="filePath"> the path to the folder containing the csv files </param>
        /// <returns> List of dayModels, i.e. a list of days</returns>
        public List<DayModel> getCsvData(String filePath)
        {
            String delimiter = ",";
            List<DayModel> dayList = new List<DayModel>();
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                using (CsvReader csvReader = new CsvReader(streamReader, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = delimiter }))
                {
                    {
                        IEnumerable<DayModel> dayRecords = csvReader.GetRecords<DayModel>();
                        foreach (DayModel day in dayRecords)
                        {
                            dayList.Add(day);
                        }
                    }
                }
                return dayList;

            }
        }
        /// <summary>
        /// creates a csv file,in the given path, containing the best days for every location
        /// </summary>
        /// <param name="csvDictionary"> a dictionary composed of keys- the names of the location
        /// and lists of DayModels mapped to those keys, representing the days for that location</param>
        /// <param name="path"> the path where the file should be created </param>
        /// <param name="delimiter"> delimiter for the csv file </param>
        public void createResultsCsv(Dictionary<string, List<DayModel>> csvDictionary, string path, string delimiter)
        {
            using (TextWriter textWriter = new StreamWriter(path + "/LaunchAnalysisReport.csv", false, System.Text.Encoding.UTF8))
            {
                using CsvWriter csvWriter = new CsvWriter(textWriter, CultureInfo.InvariantCulture);
                List<DayResultModel> dayResultModels = new List<DayResultModel>();
                foreach (string key in csvDictionary.Keys)
                {
                    DayResultModel dayResultModel = new DayResultModel();
                    dayResultModel.Spaceport = key;
                    dayResultModel.Day = $"{csvDictionary[key].First().Day}.07";
                    dayResultModels.Add(dayResultModel);
                }
                csvWriter.WriteRecords(dayResultModels);
            }
        }
    }
}
