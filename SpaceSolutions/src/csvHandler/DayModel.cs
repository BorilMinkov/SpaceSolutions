using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSolutions.src.csvHandler
{
    public class DayModel
    {

        [Name("Day/Parameter")]
        public int Day { get; set; }

        [Name("Temperature (C)")]
        public int Temperature { get; set; }

        [Name("Wind (m/s)")]
        public int Wind { get; set; }

        [Name("Humidity (%)")]
        public int Humidity { get; set;}

        [Name("Precipitation (%)")]
        public int Precipation { get; set; }

        [Name("Lightning")]
        public string Lightning { get; set; }

        [Name("Clouds") ]
        public string Clouds { get; set; }
    }
}
