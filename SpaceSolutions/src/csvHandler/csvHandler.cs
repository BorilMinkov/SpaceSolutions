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
    }
}
