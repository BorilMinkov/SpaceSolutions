using SpaceSolutions.src.csvHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSolutions.src.dataHandler
{
    internal class DataHandler
    {
        /// <summary>
        /// Checks whether the parameters of each day is within the given limits
        /// </summary>
        /// <param name="listOfDays"> a list containing day objects </param>
        /// <returns> the same list as input, however pruned </returns>
        public List<DayModel> checkAndFilter(List<DayModel> listOfDays)
        {
            for (int i = listOfDays.Count - 1; i <= 0; i--)
            {
                try
                {
                    DayModel day = listOfDays[i];
                    if (day.Lightning.ToLower() == "yes" || day.Precipation > 0 || day.Humidity > 55 || day.Wind > 11 || day.Temperature < 1
                        || day.Temperature > 32 || day.Clouds.ToLower() == "cumulus" || day.Clouds.ToLower() == "nimbus")
                    {
                        listOfDays.Remove(day);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error filtering through csv entries: " + ex.ToString());
                    continue;
                }
            }
            return listOfDays;
        }

        /// <summary>
        /// Calculates a score per day based on wind speed and humidity
        /// </summary>
        /// <param name="listOfDays">  a list containing day objects </param>
        /// <returns></returns>
        public List<DayModel> calculateScore (List<DayModel> listOfDays)
        {
            foreach (DayModel day in listOfDays)
            {
                try
                {
                    day.setScore(day.Wind, day.Humidity);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error calculating score: " + ex.ToString());
                    continue;
                }
            }
            return listOfDays;
        }

        /// <summary>
        /// Returns a list of day objects, where only the best days are present
        /// </summary>
        /// <param name="listOfDays">  a list containing day objects </param>
        /// <returns> list of the best days for launch for the given location </returns>
        public List<DayModel> getBest(List<DayModel> listOfDays)
        {
            int best = int.MaxValue;
            // We do two passes, first pass finds the minimal value, second pass makes sure only days containing it are left
            for (int i = 0; i < 2; i++)
            {
                for (int j = listOfDays.Count - 1; j >= 0; j--)
                {
                    DayModel day = listOfDays[j];
                    if (day.getScore() <= best)
                    {
                        best = day.getScore();
                    }
                    else
                    {
                        listOfDays.Remove(day);
                    }
                }
            }
            return listOfDays;
        }
        
    }
}
