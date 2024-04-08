using CsvHelper.Configuration.Attributes;
using SpaceSolutions.src.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSolutions.src.csvHandler
{
    /// <summary>
    /// Class representing a day data entry
    /// </summary>
    public class DayModel
    {
        public int score;
        /// <summary>
        /// integer which assigns how important wind speed increments are. Check Coefficients.cs
        /// </summary>
        public int windCoefficient = Coefficients.windCoeff;
        /// <summary>
        /// integer which assigns how important humidity increments are. Check Coefficients.cs
        /// </summary>
        public int humidityCoefficient = Coefficients.humidityCoeff;

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

        /// <summary>
        /// method to calculate how good a day is for launch
        /// </summary>
        /// <param name="windSpeed"> integer representing the wind speed in meters per second </param>
        /// <param name="humidity"> integer representing the humidity in percentage </param>
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
