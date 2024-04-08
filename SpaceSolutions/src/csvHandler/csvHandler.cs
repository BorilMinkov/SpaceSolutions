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
    public class CsvHandler
    {
        public string[] getCsvFiles(String folderPath)
        {
            string[] files = Directory.GetFiles(folderPath, "*.csv");
            return files;
        }

        public List<DayModel> getCsvData(String filePath)
        {
            String delimiter = ",";
            List<DayModel> dayList = new List<DayModel>();
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                using (CsvReader csvReader = new CsvReader(streamReader, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = delimiter }))
                {
                    //do something with csv
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

        public void createResultsCsv(Dictionary<string, List<DayModel>> csvDictionary, string path, string delimiter)
        {
            using (TextWriter textWriter = new StreamWriter(path+ "/LaunchAnalysisReport.csv", false, System.Text.Encoding.UTF8))
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
