using SpaceSolutions.src.csvHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSolutions.src.dataHandler
{
    internal class dataHandler
    {
        
        public List<DayModel> checkAndFilter(List<DayModel> listOfDays)
        {
            for (int i = 0; i < listOfDays.Count; i++)
            {
                DayModel day = listOfDays[i];
                if (day.Lightning.ToLower() == "yes" || day.Precipation > 0 || day.Humidity > 55 || day.Wind > 11 || day.Temperature < 1
                    || day.Temperature > 32 || day.Clouds.ToLower() == "cumulus" || day.Clouds.ToLower() == "nimbus")
                {
                    listOfDays.Remove(day);
                    i--;
                }
            }
            return listOfDays;
        }
        
        public List<DayModel> calculateScore (List<DayModel> listOfDays)
        {
            foreach (DayModel day in listOfDays)
            {
                day.setScore( day.Wind, day.Humidity);
            }
            return listOfDays;
        }

        public List<DayModel> getBest(List<DayModel> listOfDays)
        {
            int best = int.MaxValue;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < listOfDays.Count; j++)
                {
                    DayModel day = listOfDays[j];
                    if (day.getScore() <= best)
                    {
                        best = day.getScore();
                    }
                    else
                    {
                        listOfDays.Remove(day);
                        j--;
                    }
                }
            }
            return listOfDays;
        }
        
    }
}
