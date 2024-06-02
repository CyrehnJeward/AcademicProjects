using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using _FileWriter;

namespace MidtermProject
{
    /// <summary>
    /// Interaction logic for resultWindow.xaml
    /// </summary>
    /// 
    public partial class resultWindow : Window
    {
        string dateTime = DateTime.Now.ToString();
        string WPM = MainWindow.grossWPM.ToString();
        string Accuracy = string.Format("{0:N2}%", MainWindow.x.ToString());
        string Character = MainWindow.amountofBacks.ToString();
        __fileWriter Rayter = new __fileWriter();

        public resultWindow()
        {
            InitializeComponent();
            lblWpm.Content = MainWindow.grossWPM.ToString();
            lblAccuracy.Content = string.Format("{0:N2}%", MainWindow.x.ToString());
            lblCompleteWords.Content = MainWindow.keyType.ToString();
            dateTime = DateTime.Now.ToString();

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
            this.Close();
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            this.Close();
            a.Show();
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            string print = "DATE & TIME = " + dateTime 
                + "\n\nWPM = " + WPM
                + "\n\nAccuracy = " + Accuracy
            + "\n\nCharacters = " + Character + "\n";

            Rayter.fileWriter(true, print);
        }

        private void btnChar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(MainWindow.inputUser,"Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
