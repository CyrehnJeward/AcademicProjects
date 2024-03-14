using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject
{
    internal class wpmAccuracy
    {
        public static double grossWPMs = 0;
        public static double amountofBacks = 0;
        public static double accuracy = 0;
        public static double j = 0;
        public static void wordPMAccuracy(double x, double y, double z)
        {
            double allEntires = (Convert.ToDouble(x) - Convert.ToDouble(y)) / 5;
            double totalminute = Convert.ToDouble(z) / 60;
            double gWPM = allEntires / totalminute;

            grossWPMs = Math.Round(gWPM);

            amountofBacks = x - y;
            accuracy = (100 - ((x - amountofBacks) / x * 100));
            j = Math.Truncate(accuracy * 100) / 100;
        }
    }
}
