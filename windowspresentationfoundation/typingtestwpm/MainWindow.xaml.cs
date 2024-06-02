using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using _ColorBase;
using _FileReader;
using _FileWriter;

namespace MidtermProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Key[] Keys = { };
        public static string color { get; set; }
        public static Label[] Labels = { };
        DispatcherTimer timer1 = new DispatcherTimer();

        public static double grossWPM; //WPM
        public static double accuracy; //ACCURACY
        public static double x;
        public static string inputUser = "";

        int timeS = 60;
        public static int keyType = 0;
        int startTimer = 0; //TIMER 
        public static int backspace = 0; // FOR BACKSPACE
        public static double amountofBacks = 0;

        __KolorBase kulor = new __KolorBase();
        __fileReader reyder = new __fileReader();

        public MainWindow()
        {
            InitializeComponent();
            timer1.Interval = new TimeSpan(0, 0, 0, 1);
            timer1.Tick += Timer1_Tick;
            
            Labels = new Label[]
            {
                keyOne, keyTwo, keyThree, keyFour, keyFive, keySix, keySeven, keyEight, keyNine, keyZero, keyMinus, keyPlus, keyBackspace
                ,keyQ, keyW, keyE, keyR, keyT, keyY, keyU, keyI, keyO, keyP, keyLBracket, keyRBracket, keyBackSlash
                ,keyCaps, keyA, keyS, keyD, keyF, keyG, keyH, keyJ, keyK, keyL, keySemiColon, keyQuotation
                ,keyShift, keyZ, keyX, keyC, keyV, keyB, keyN, keyM, keyLessThan, keyGreaterThan, keyQuestion, keyRShift, keySpace
            };

            Keys = new Key[]
            {
                Key.D1, Key.D2, Key.D3, Key.D4, Key.D5, Key.D6, Key.D7, Key.D8, Key.D9, Key.D0, Key.OemMinus, Key.OemPlus, Key.Back, //0-12
                Key.Q, Key.W, Key.E, Key.R, Key.T, Key.Y, Key.U, Key.I, Key.O, Key.P, Key.OemOpenBrackets, Key.OemCloseBrackets, Key.OemPipe, //13-25
                Key.CapsLock, Key.A, Key.S, Key.D, Key.F, Key.G, Key.H, Key.J, Key.K, Key.L, Key.OemSemicolon, Key.OemQuotes, //26-37
                Key.LeftShift, Key.Z, Key.X, Key.C, Key.V, Key.B, Key.N, Key.M, Key.OemComma, Key.OemPeriod, Key.OemQuestion, Key.RightShift, Key.Space//38-50
            };

            
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            outputBox.IsReadOnly = true;
            lblTimer.Content = timeS.ToString();
            fileReaderManipulator();
            MessageBox.Show("--- The timer will start once you type something in the textbox\n --- Copy the words as fast as you can within a minute\n --- Click and type in the textbox to start\n --- Click the restart button twice to restart the game","OBJECTIVES",MessageBoxButton.OK,MessageBoxImage.Information);

        }

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            string CharInput = txtInput.Text.ToString();
            char LChari = ' ';
            if(CharInput == " ")
            {
                char LChar = CharInput[0];
                LChari = CharInput[CharInput.Length - 1];
                if (LChari == ' ')
                {
                    // //to prevent the last char backspace error
                    // If the input is space, the space bar will light up
                    keySpace.Background = _ColorBase.ColorB;
                }
            }
            
            if (LChari == ' ')
            {
                // //to prevent the last char backspace error
                // If the input is space, the space bar will light up
                keySpace.Background = _ColorBase.ColorB;
            }
            //The timer will activate
            timer1.IsEnabled = true;
            if (startTimer >= 60000)
            {
                wordPMAccuracy();
            }

        }

        public void fileReaderManipulator()
        {

            string x = @"D:\File Manager\Setup\School\IT3\EDP\MIDTERMS\Midtermproj2\EASYTEXT.txt";
            reyder.fileReader(x);
            foreach (var month in reyder.Lines)
            {
                outputBox.Text = month;
            }

        }
        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            timer1.IsEnabled = false;
            timer1.Interval = new TimeSpan(0, 0, 0, 1);
            timer1.Stop();

            Restart();
        }
        public void Restart()
        {
            txtInput.Text = "";
            lblTimer.Content = 60;
            timeS = 60;
            startTimer = 0;
            keyType = 0;
            backspace = 0;
        }
        #region //TIMEACURRACY

        private void Timer1_Tick(object sender, EventArgs e)
        {
            startTimer = startTimer + 1000;
            lblTimer.Content = Convert.ToString(Convert.ToInt32(lblTimer.Content) - 1);
            if (startTimer >= 60000)
            {
                wordPMAccuracy();
            }
        }

        public void wordPMAccuracy()
        {

            double allEntires  = (Convert.ToDouble(keyType) - Convert.ToDouble(backspace)) / 5;
            double totalminute = Convert.ToDouble(timeS) / 60;

            //Word Per Minute
            double gWPM = allEntires / totalminute;
            grossWPM = Math.Round(gWPM);

            //Accuracy
            amountofBacks = keyType - backspace;
            accuracy = (100 - ((keyType - amountofBacks) / keyType * 100));
            x = Math.Truncate(accuracy * 100) / 100;

            timer1.IsEnabled = false;
            resultWindow a = new resultWindow();
            this.Close();
            a.Show();
            inputUser = txtInput.Text.ToString();
        }

        #endregion
        #region //KeyUPDOWN
        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            for (int a = 0; a < Keys.Length; a++)
            {
                if (e.Key == Keys[a])
                {
                    color = a.ToString();
                    colorBase(color);
                    keyType += 1;
                }
            }
        }

        private void txtInput_KeyUp(object sender, KeyEventArgs e)
        {
            for (int a = 0; a < Keys.Length; a++)
            {
                if (e.Key == Keys[a])
                {
                    color = a.ToString();
                    colorBase2(color);
                    keyType += 1;
                }
            }
            if (e.Key == Key.Back)
            {
                backspace++;
            }
        }

        public void colorBase(string y)
        {
            int x = Int32.Parse(color);

            for (int b = 0; b < Labels.Length; b++)
            {
                if (x == b)
                {
                    Labels[b].Background = kulor.ColorB;
                }
                else if (Labels[12].Background == kulor.ColorB)
                {
                    Labels[12].Background = kulor.ColorBase2;
                }
            }
        }

        public void colorBase2(string y)
        {
            int x = Int32.Parse(color);

            for (int b = 0; b < Labels.Length; b++)
            {
                if (x == b)
                {
                    Labels[b].Background = kulor.ColorBase;

                    if (x == 26 || x == 38 || x == 49)
                    {
                        Labels[b].Background = kulor.ColorBase2;
                    }
                    else if (x == 50)
                    {
                        Labels[b].Background = kulor.ColorBase3;
                    }
                    else if (x == 12)
                    {
                        Labels[12].Background = kulor.ColorB;
                    }

                }

            }
        }
        #endregion //KeyUPDOWN

 
    }
}
