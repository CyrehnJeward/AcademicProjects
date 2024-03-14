using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MidtermProject
{
    internal class FileManipulator
    {
        //STREAMREADER
        public static List<string> Lines = new List<string>(); // all the text from the file, raw
        public static StreamReader sr;
        public static string line = ""; // reading the easy moide textfile
        public static string[] array = new string[] { };
        public static string line2 = "";
        //STREAMREADER

        public static void fileReader(string filePath)
        {
            try
            {
                using (sr = new StreamReader(filePath))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        line2 = new string((line.Where(c => char.IsWhiteSpace(c) || char.IsLetter(c)).ToArray())).ToLower();
                        Lines.Add(line2);

                    }
                }
            }
            catch (Exception e)
            {
                Lines = new List<string>();
            }
        }
    }
}
