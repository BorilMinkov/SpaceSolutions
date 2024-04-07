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
        public int score;
        public int windCoefficient = 1;
        public int humidityCoefficient = 1;

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

        public void setScore(int windSpeed, int humidity)
        {
            this.score = windSpeed * windCoefficient + humidity * humidityCoefficient;
        }

        public int getScore()
        {
            return this.score;
        }
    }
}
