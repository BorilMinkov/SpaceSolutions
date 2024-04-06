using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSolutions.src.csvHandler
{
    public class CsvHandler
    {
        /*
        string folderPath;
        string senderEmail;
        string senderPassord;
        string receiverEmail;
        */

        public string[] getCsvFiles(String folderPath)
        {
            string[] files = Directory.GetFiles(folderPath, "*.csv");
            return files;
        }

    }
}
