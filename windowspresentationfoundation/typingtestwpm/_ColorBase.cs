using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MidtermProject
{
    internal class _ColorBase
    {

        public static SolidColorBrush ColorB = new SolidColorBrush(Color.FromRgb(255, 231, 217));
        public static SolidColorBrush ColorBase = new SolidColorBrush(Color.FromRgb(180, 179, 199));
        public static SolidColorBrush ColorBase2 = new SolidColorBrush(Color.FromRgb(48, 53, 63));
        public static SolidColorBrush ColorBase3 = new SolidColorBrush(Color.FromRgb(244, 92, 140));


        public static void colorBase(string y)
        {
            int x = Int32.Parse(MainWindow.color);

            for (int b = 0; b < MainWindow.Labels.Length; b++)
            {
                if (x == b)
                {
                    MainWindow.Labels[b].Background = ColorB;
                }
                else if (MainWindow.Labels[12].Background == ColorB)
                {
                    MainWindow.Labels[12].Background = ColorBase2;
                }
            }
        }

        public  static void colorBase2(string y)
        {
            int x = Int32.Parse(MainWindow.color);

            for (int b = 0; b < MainWindow.Labels.Length; b++)
            {
                if (x == b)
                {
                    MainWindow.Labels[b].Background = ColorBase;

                    if (x == 26 || x == 38 || x == 49)
                    {
                        MainWindow.Labels[b].Background = ColorBase2;
                    }
                    else if (x == 50)
                    {
                        MainWindow.Labels[b].Background = ColorBase3;
                    }
                    else if (x == 12)
                    {
                        MainWindow.Labels[12].Background = ColorB;
                    }

                }

            }
        }

    }
}
