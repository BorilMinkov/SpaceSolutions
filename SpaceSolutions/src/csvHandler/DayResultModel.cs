using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSolutions.src.csvHandler
{
    internal class DayResultModel
    {
        [Name("Spaceport")]
        public string Spaceport { get; set;}

        [Name("Best Date")]
        public string Day { get; set;}
    }
}
