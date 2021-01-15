using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DateModifierExercise
{
    public class DateModifier
    {
        private string firstDate;
        private string secondDate;
        public DateModifier()
        {
            this.FirstDate = firstDate;
            this.SecondDate = secondDate;
        }
        public string FirstDate { get; set; }
        public string SecondDate { get; set; }

        public int GetDiffBetweenTwoDays(string firstDateAsSting, string secondDateAsSting)
        {
            //int[] firstDateSplit = firstDateAsSting.Split(" ").Select(int.Parse).ToArray();
            //int yearFirstDate = firstDateSplit[0];
            //int monthFirstDate = firstDateSplit[1];
            //int dayFirstDate = firstDateSplit[2];

            //int[] secondDateSplit = secondDateAsSting.Split(" ").Select(int.Parse).ToArray();
            //int yearSecondDate = secondDateSplit[0];
            //int monthSecondDate = secondDateSplit[1];
            //int daySecondDate = secondDateSplit[2];

            //DateTime first = new DateTime(yearFirstDate, monthFirstDate, dayFirstDate);
            //DateTime second = new DateTime(yearSecondDate, monthSecondDate, daySecondDate);

            DateTime first = DateTime.Parse(firstDateAsSting);
            DateTime second = DateTime.Parse(secondDateAsSting);

            int difference = (int)Math.Abs((first - second).TotalDays);

            return difference;
        }
    }
}
