using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject
{
    internal class FileCreator
    {
        public static void fileWriter(bool appendFlag, string message)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Text|*.txt|All|*.*"
            };

            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, message);
            }
        }
    }
}
