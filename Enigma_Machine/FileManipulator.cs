using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP1Enigma
{
    class FileManipulator
    {
        public static List<string> lines = new List<string>(); // all the text from the file, raw
        public static List<string> columnNames = new List<string>(); // just the list of column headers
        public static StreamReader sr;
        public static Dictionary<int, int[]> Rings = new Dictionary<int, int[]>();

        public static string[] STemp = new string[] { };
        public static int[] ITemp = new int[] { };
        public static string line = "";

        // heLLO
        public static void fileReader(string filePath)
        {
            try
            {
                using (sr = new StreamReader(filePath))
                {

                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line); // The csv has been transfer to list lines
                        STemp = line.Split(','); // the value of each per column value
                        ITemp = Array.ConvertAll(STemp, Int32.Parse); // It convert into array number per column

                        if (ITemp.Length < 1)
                        {
                            break;
                        }
                        else
                        {
                            int[] ITemp2 = new int[ITemp.Length - 1];
                            for (int x = 1; x < ITemp.Length; x++)
                            {
                                ITemp2[x - 1] = ITemp[x]; //0[ x - 1 means it will start from second column] = 1, x++ means each value of column will be store at Itemp2
                            }
                                Rings.Add(ITemp[0], ITemp2); // per rings means per column the output 0[6], 
                                                             // number of rings dictionary = 0, ITemp is key per row = [6] Itemp2 value data = [5], 
                        }

                    }
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine("Error Message: Please close the file and try again");
                lines = new List<string>();
            }
        }

        public static string[] stringSplitter(string stringToSplit, char[] splitChars)
        {
            return stringToSplit.Split(splitChars);
        }

        public static void fileExtractColumnNames()
        {
            // this line will split the 2nd read line, which is the line of column names
            string[] temp = stringSplitter(lines[0], new char[] { ',' });
            foreach (string t in temp)
            {
                if (t.Length > 0) // checks if the column name is blank or not
                    columnNames.Add(t);
            }

        }

        public static int getColumnCount()
        {
            // this just returns the count of columns
            return columnNames.Count - 1;
        }

    }
}
