using Microsoft.Win32;
using System;
using System.Collections.Generic;
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


namespace MP1Enigma
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //int[] RCSValue = new int[3] { 0, 0, 0 };
        int[] rotorSelectionCount = new int[3]; //this is for the display of S,M,H -- rotorSelection
        int[] rotorSettingCount = new int[3]; //this is for the display of S , M, H -- rotorSettings
        int[] rotorSCselected = new int[3]; // this is for getting the value of selected selection
        int[] rotorSetCselected = new int[3]; // this is for getting the value of selected setting

        //Trial
        //Dictionary<int, int[]> Rings = new Dictionary<int, int[]>();
        int[] asciiArray = new int[4];
        //Trial
        private string rawOutput = "";

        public MainWindow()
        {
            InitializeComponent();
            outputText.Visibility = Visibility.Hidden;
            InvisibleButton(); //for invisible objects 
            //This message box will show before the main window appears / the program to start.
            //This acts as a tooltip upon starting the program
            MessageBox.Show("Please select a CSV file by clicking the select CSV File button to start the program.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        //CSV File selector
        //This filters out the files the user can select (.csv Files)
        private void btnCSVSelector_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Comma Separated Values (*.csv;)|*.csv;";
            
            //The chosen file path will display in the text box
            if (ofd.ShowDialog() == true)
            {
                tbDisplayPath.Text = ofd.FileName;
                FileManipulator.fileReader(tbDisplayPath.Text);
                VisibleRSButton();
                btnCSVSelector.IsEnabled = false;

                //This information Message Box will appear upon choosing the File containing the Rings
                MessageBox.Show("Please select your Rings in the left box named 'Ring Selection'." + "\nNOTE: All boxes should be a unique number.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                //Splits the 1st Row in the CSV File and count the number of available Rings
                FileManipulator.fileExtractColumnNames();

                //This Text Box will show how many Rings are present in the CSV File
                ringCount.Text = FileManipulator.getColumnCount().ToString();

            }
        }


        #region // this is for visible and invisible button

        //Mainly for the Visibility of the Add and Minus Buttons under the Ring Selection and Ring Settings
        //The user can only use the buttons when the inputs are correct
        //The buttons will become disabled whenever user input is incorrect
        //The default of the buttons are .IsEnabled = false;
        private void InvisibleButton()
        {
            rsPlus1.IsEnabled = false;
            rsPlus2.IsEnabled = false;
            rsPlus3.IsEnabled = false;

            rsMinus1.IsEnabled = false;
            rsMinus2.IsEnabled = false;
            rsMinus3.IsEnabled = false;

            rsBtn.IsEnabled = false;

            rst_Plus1.IsEnabled = false;
            rst_Plus2.IsEnabled = false;
            rst_Plus3.IsEnabled = false;

            rst_Minus1.IsEnabled = false;
            rst_Minus2.IsEnabled = false;
            rst_Minus3.IsEnabled = false;

            rst_Btn.IsEnabled = false;

            inputText.IsEnabled = false;

            tbDisplayPath.IsReadOnly = true;
            ringCount.IsReadOnly = true;
            outputText.IsReadOnly = true;
            rawText.IsReadOnly = true;
            encryptedText.IsReadOnly = true;
            //These are textboxes for the program which are visible

        }

        // Plus and Minus Buttons for the Ring Selection
        private void VisibleRSButton()
        {
            rsPlus1.IsEnabled = true;
            rsPlus2.IsEnabled = true;
            rsPlus3.IsEnabled = true;

            rsMinus1.IsEnabled = true;
            rsMinus2.IsEnabled = true;
            rsMinus3.IsEnabled = true;

            rsBtn.IsEnabled = false;
        }

        // Plus and Minus Buttons for the Ring Settings
        private void VisibleRSTButton()
        {
            rst_Plus1.IsEnabled = true;
            rst_Plus2.IsEnabled = true;
            rst_Plus3.IsEnabled = true;

            rst_Minus1.IsEnabled = true;
            rst_Minus2.IsEnabled = true;
            rst_Minus3.IsEnabled = true;


            rst_Btn.IsEnabled = true;
        }

        // Plus and Minus Buttons will return to its default false value when user select to reset
        private void inVisibleRSTButton()
        {
            rst_Plus1.IsEnabled = false;
            rst_Plus2.IsEnabled = false;
            rst_Plus3.IsEnabled = false;

            rst_Minus1.IsEnabled = false;
            rst_Minus2.IsEnabled = false;
            rst_Minus3.IsEnabled = false;


            rst_Btn.IsEnabled = false;
        }

        //This disables and enables the Confirm Button for the Ring Selection
        //If the user selects atleast 2 SAME Rings, the Confirm button will be disabled
        //Else if the user selects 3 different Rings, the Confirm button will be enabled
        //The user can continue to the next step which is the Ring Settings
        private void ringSelectionConfirm()
        {
            if (rsSecond.Content.ToString() == rsMinute.Content.ToString() || rsMinute.Content.ToString() == rsHour.Content.ToString() || rsHour.Content.ToString() == rsSecond.Content.ToString())
            {
                rsBtn.IsEnabled = false;
            }      
            else 
            {
                rsBtn.IsEnabled = true;
            }
        }



        #endregion // this is for visible and invisible button

        #region // button for Ring Selection
        // The max number of these buttons will depend on the number of the Rings inside the read CSV File
        private void rsPlus1_Click(object sender, RoutedEventArgs e)
        {
            if (rotorSelectionCount[2] < FileManipulator.getColumnCount())
            {
                rotorSelectionCount[2]++;
                rsHour.Content = rotorSelectionCount[2].ToString();
                if (rotorSelectionCount[2] == FileManipulator.getColumnCount())
                {
                    rotorSelectionCount[2] = 0;
                    rsHour.Content = rotorSelectionCount[2].ToString();
                }         
            }
            ringSelectionConfirm();
        }


        private void rsMinus1_Click(object sender, RoutedEventArgs e)
        {
            if (rotorSelectionCount[2] > 0)
            {
                rotorSelectionCount[2]--;
                rsHour.Content = rotorSelectionCount[2].ToString();
                if (rotorSelectionCount[2] < 0)
                {
                    rotorSelectionCount[2] = FileManipulator.getColumnCount();
                    rsHour.Content = rotorSelectionCount[2].ToString();
                }
            }
            else
            {
                rotorSelectionCount[2] = FileManipulator.getColumnCount() - 1;
                rsHour.Content = rotorSelectionCount[2].ToString();
            }
            ringSelectionConfirm();
        }

        private void rsPlus2_Click(object sender, RoutedEventArgs e)
        {
            if (rotorSelectionCount[1] < FileManipulator.getColumnCount())
            {
                rotorSelectionCount[1]++;
                rsMinute.Content = rotorSelectionCount[1].ToString();
                if (rotorSelectionCount[1] == FileManipulator.getColumnCount())
                {
                    rotorSelectionCount[1] = 0;
                    rsMinute.Content = rotorSelectionCount[1].ToString();
                }
            }
            ringSelectionConfirm();
        }

        private void rsMinus2_Click(object sender, RoutedEventArgs e)
        {
            if (rotorSelectionCount[1] > 0)
            {
                rotorSelectionCount[1]--;
                rsMinute.Content = rotorSelectionCount[1].ToString();
                if (rotorSelectionCount[1] < 0)
                {
                    rotorSelectionCount[1] = FileManipulator.getColumnCount();
                    rsMinute.Content = rotorSelectionCount[1].ToString();
                }
            }
            else
            {
                rotorSelectionCount[1] = FileManipulator.getColumnCount() - 1;
                rsMinute.Content = rotorSelectionCount[1].ToString();
            }
            ringSelectionConfirm();
        }

        private void rsPlus3_Click(object sender, RoutedEventArgs e)
        {
            if (rotorSelectionCount[0] < FileManipulator.getColumnCount())
            {
                rotorSelectionCount[0]++;
                rsSecond.Content = rotorSelectionCount[0].ToString();
                if (rotorSelectionCount[0] == FileManipulator.getColumnCount())
                {
                    rotorSelectionCount[0] = 0;
                    rsSecond.Content = rotorSelectionCount[0].ToString();
                }
            }
            ringSelectionConfirm();
        }

        private void rsMinus3_Click(object sender, RoutedEventArgs e)
        {
            if (rotorSelectionCount[0] > 0)
            {
                rotorSelectionCount[0]--;
                rsSecond.Content = rotorSelectionCount[0].ToString();
                if (rotorSettingCount[0] < 0)
                {
                    rotorSelectionCount[0] = FileManipulator.getColumnCount();
                    rsSecond.Content = rotorSelectionCount[0].ToString();
                }
            }
            else
            {
                rotorSelectionCount[0] = FileManipulator.getColumnCount() - 1;
                rsSecond.Content = rotorSelectionCount[0].ToString();
            }
            ringSelectionConfirm();
        }

        //-------- for confirm
        private void rsBtn_Click(object sender, RoutedEventArgs e)
        {
            switch (rsBtn.Content.ToString())
            {
                case "CONFIRM":
                    if (MessageBox.Show("Confirming this inserted input will lock the button of this box, Are you sure?", "Information", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                    {
                        rsBtn.Content = "RESET";
                        VisibleRSTButton();
                        rsPlus1.IsEnabled = false;
                        rsPlus2.IsEnabled = false;
                        rsPlus3.IsEnabled = false;
                        rsMinus1.IsEnabled = false;
                        rsMinus2.IsEnabled = false;
                        rsMinus3.IsEnabled = false;
                    }

                    break;

                case "RESET":
                    rsBtn.Content = "CONFIRM";
                    rsSecond.Content = 0;
                    rsMinute.Content = 0;
                    rsHour.Content = 0;

                    rsPlus1.IsEnabled = true;
                    rsPlus2.IsEnabled = true;
                    rsPlus3.IsEnabled = true;
                    rsMinus1.IsEnabled = true;
                    rsMinus2.IsEnabled = true;
                    rsMinus3.IsEnabled = true;

                    rsBtn.IsEnabled = false;

                    inVisibleRSTButton();
                    break;
            }
            
        }
        #endregion

        #region //button for Ring Offset

        //This sets the offset for the user
        //The offset of the Rings selected from the Ring Selection
        //will be set under the Ring Settings Box

        private void rst_Plus3_Click(object sender, RoutedEventArgs e)
        {
            if(rotorSettingCount[0] < 91)
            {
                rotorSettingCount[0]++;
                rst_Second.Content = rotorSettingCount[0].ToString();
                if (rotorSettingCount[0] == 91)
                {
                    rotorSettingCount[0] = 0;
                    rst_Second.Content = rotorSettingCount[0].ToString();
                }
            }

        }

        private void rst_Minus3_Click(object sender, RoutedEventArgs e)
        {
            if (rotorSettingCount[0] > 0)
            {
                rotorSettingCount[0]--;
                rst_Second.Content = rotorSettingCount[0].ToString();
                if (rotorSettingCount[0] < 0)
                {
                    rotorSettingCount[0] = 90;
                    rst_Second.Content = rotorSettingCount[0].ToString();
                }
            }
            else 
            {
                rotorSettingCount[0] = 90;
                rst_Second.Content = rotorSettingCount[0].ToString();
            }

        }

        private void rst_Plus2_Click(object sender, RoutedEventArgs e)
        {
            if (rotorSettingCount[1] < 91)
            {
                rotorSettingCount[1]++;
                rst_Minute.Content = rotorSettingCount[1].ToString();
                if (rotorSettingCount[1] == 91)
                {
                    rotorSettingCount[1] = 0;
                    rst_Minute.Content = rotorSettingCount[0].ToString();
                }
            }
  
        }

        private void rst_Minus2_Click(object sender, RoutedEventArgs e)
        {
            if (rotorSettingCount[1] > 0)
            {
                rotorSettingCount[1]--;
                rst_Minute.Content = rotorSettingCount[1].ToString();
                if (rotorSettingCount[1] < 0)
                {
                    rotorSettingCount[1] = 90;
                    rst_Minute.Content = rotorSettingCount[1].ToString();
                }
            }
            else
            {
                rotorSettingCount[1] = 90;
                rst_Minute.Content = rotorSettingCount[1].ToString();
            }
   
        }

        private void rst_Plus1_Click(object sender, RoutedEventArgs e)
        {
            if (rotorSettingCount[2] < 91)
            {
                rotorSettingCount[2]++;
                rst_Hour.Content = rotorSettingCount[2].ToString();
                if (rotorSettingCount[2] == 91)
                {
                    rotorSettingCount[2] = 0;
                    rst_Hour.Content = rotorSettingCount[2].ToString();
                }
            }

        }

        private void rst_Minus1_Click(object sender, RoutedEventArgs e)
        {
            if (rotorSettingCount[2] > 0)
            {
                rotorSettingCount[2]--;
                rst_Hour.Content = rotorSettingCount[2].ToString();
                if (rotorSettingCount[2] < 0)
                {
                    rotorSettingCount[2] = 90;
                    rst_Hour.Content = rotorSettingCount[2].ToString();
                }
            }
            else
            {
                rotorSettingCount[2] = 90;
                rst_Hour.Content = rotorSettingCount[2].ToString();
            }
   
        }

        private void rst_Btn_Click(object sender, RoutedEventArgs e)
        {
            switch (rst_Btn.Content.ToString())
            {
                case "SET":
                    if (MessageBox.Show("Confirming this inserted input will lock the button of this box, Are you sure?", "Information", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                    {
                        rst_Btn.Content = "RESET";
                        btnProceed.IsEnabled = true;
                        MessageBox.Show("If you wish to continue, Click the Proceed Button", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    break;

                case "RESET":
                    rst_Btn.Content = "SET";
                    rst_Second.Content = 0;
                    rst_Minute.Content = 0;
                    rst_Hour.Content = 0;
                    btnProceed.IsEnabled = false;
                    break;
            }
        }

        #endregion


        /* After the proceed button has been clicked,
         * the rotor selection and rotor settings button will be disabled
         * locking the program with the settings the user inputed
         */

        private void btnProceed_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Confirming this button will lock the ring selection and ring settings, Are you sure?", "Information", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                inputText.IsEnabled = true;


                rsPlus1.IsEnabled = false;
                rsPlus2.IsEnabled = false;
                rsPlus3.IsEnabled = false;

                rsMinus1.IsEnabled = false;
                rsMinus2.IsEnabled = false;
                rsMinus3.IsEnabled = false;

                rsBtn.IsEnabled = false;

                rst_Plus1.IsEnabled = false;
                rst_Plus2.IsEnabled = false;
                rst_Plus3.IsEnabled = false;

                rst_Minus1.IsEnabled = false;
                rst_Minus2.IsEnabled = false;
                rst_Minus3.IsEnabled = false;

                rst_Btn.IsEnabled = false;
                btnProceed.IsEnabled = false;
                MessageBox.Show("Enigma is now Activated!" + "\nNOTE: Enter the characters on the left text box that you wish to convert!", "information", MessageBoxButton.OK, MessageBoxImage.Information);

                //after proceed button, the selected Selection and setting will be extract and store in specific array
                rotorSCselected[0] = Int32.Parse(rsSecond.Content.ToString());
                rotorSCselected[1] = Int32.Parse(rsMinute.Content.ToString());
                rotorSCselected[2] = Int32.Parse(rsHour.Content.ToString());

                rotorSetCselected[0] = Int32.Parse(rst_Second.Content.ToString());
                rotorSetCselected[1] = Int32.Parse(rst_Minute.Content.ToString());
                rotorSetCselected[2] = Int32.Parse(rst_Hour.Content.ToString());

                /*the selected Setting is in the for loop because
                 * the initialization will keep generating until it reach the selected setting
                 * The statement will execute (rotate) each loop until the selected setting
                */

                for (int a = 0; a < rotorSetCselected[0]; a++)
                {
                    RotorRotation(rotorSCselected[0]);
                }
                for (int b = 0; b < rotorSetCselected[1]; b++)
                {
                    RotorRotation(rotorSCselected[1]);
                }
                for (int c = 0; c < rotorSetCselected[2]; c++)
                {
                    RotorRotation(rotorSCselected[2]);
                }

                MessageBox.Show("Rings Selected : " + "\n" +
                    "\n" +
                    "1st : " + rotorSCselected[0].ToString() + "\n" +
                    "2nd : " + rotorSCselected[1].ToString() + "\n" +
                    "3rd : " + rotorSCselected[2].ToString() + "\n" +
                    "\n" + "Rings Offset : " + "\n" +
                    "\n" +
                    "1st : " + rotorSetCselected[0].ToString() + "\n" +
                    "2nd : " + rotorSetCselected[1].ToString() + "\n" +
                    "3rd : " + rotorSetCselected[2].ToString(), "Information",MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        
        private void inputTextChange(object sender, TextChangedEventArgs e)
        {
            string inputChar = inputText.Text.ToString(); // extracting the value of inputtext and storing in string variable
            if (!string.IsNullOrEmpty(inputChar))
            {
                rawOutput += inputChar;
                char inputChar1 = inputChar[inputChar.Length - 1]; // converting into character, "string.length - 1" means getting the last one character, ascii letter will convert into letter
            int asciiConvert = inputChar1; // converting in Integer so that it can be used for selecting in the csv file since it only contains integers
            Encryption(asciiConvert); //calling the method encryption for convertion
            }
        }

        #region //Methods

        private void Encryption(int x)
        {
            asciiArray[0] = x;
            //asciiArray[1] = FileManipulator.Rings[asciiArray[0]][rotorSCselected[0]]; 
            //asciiArray[2] = FileManipulator.Rings[asciiArray[1]][rotorSCselected[1]];
            //asciiArray[3] = FileManipulator.Rings[asciiArray[2]][rotorSCselected[2]];

            // each loop will repeat the statement
            //The statement means that finding the same value of column 0 and 1 will be equal to the column 2
            for (int i = 0; i < 3; i++)
            {
                asciiArray[i + 1] = FileManipulator.Rings[asciiArray[i]][rotorSCselected[i]];  
            }

            //converting back to ascii characters
            char finalAscii = (char)asciiArray[3]; 
            outputText.Text = outputText.Text.ToString() + finalAscii.ToString();
            rawText.Text = inputText.Text.ToString();
            encryptedText.Text = outputText.Text.ToString();

            pressKey0.Content = ((char)asciiArray[0]).ToString();
            pressKey1.Content = ((char)asciiArray[1]).ToString();
            pressKey2.Content = ((char)asciiArray[2]).ToString();
            pressKey3.Content = ((char)asciiArray[3]).ToString();


            OffsetIncrement();
        }

        // This section of the source code is for the Rotor Movement

        /*This also displays the rotors movement in the labels of Ring Settings
         * Everytime a character is pressed, the rotors move
         * and we are given 90 characters in the csv file
         * 
         * this means that every rotor will be able to rotate 
         * a maximum number of 90 times before
         * the next rotor rotate ones
        */

        public void OffsetIncrement()
        {   

            if (rotorSetCselected[0] <= 90)
            {
                rotorSetCselected[0] += 1;
                rst_Second.Content = rotorSetCselected[0].ToString();
                RotorRotation(rotorSCselected[0]);

            }

            if(rotorSetCselected[0] > 90)
            {
                rotorSetCselected[0] = 0;

                rotorSetCselected[1] += 1;
                rst_Minute.Content = rotorSetCselected[1].ToString();
                RotorRotation(rotorSCselected[1]);
            }

            if(rotorSetCselected[1] > 90)
            {
                rotorSetCselected[1] = 0;

                rotorSetCselected[2] += 1;
                rst_Hour.Content = rotorSetCselected[2].ToString();
                RotorRotation(rotorSCselected[2]);
            }

            if(rotorSetCselected[2] > 90)
            {
                rotorSetCselected[0] = 0;
                rotorSetCselected[1] = 0;
                rotorSetCselected[2] = 0;
                rst_Second.Content = rotorSetCselected[0].ToString();
                rst_Minute.Content = rotorSetCselected[1].ToString();
                rst_Hour.Content = rotorSetCselected[2].ToString();
            }

        }

        // This serves as the incrementation of the Rings

        /*The top most character/number in the Rings/csv file
        * will be replaced by the number under it
        * then the top most character/number will be put to the bottom of the Ring/csv file
        */

        private void RotorRotation(int ring)
        {
            int FirstIndex = FileManipulator.Rings[FileManipulator.Rings.ElementAt(0).Key][ring];
           
            for (int x = 1; x < FileManipulator.Rings.Count; x++)
            {
                int NV = FileManipulator.Rings[FileManipulator.Rings.ElementAt(x).Key][ring];
                FileManipulator.Rings[FileManipulator.Rings.ElementAt(x - 1).Key][ring] = NV;
            }
            FileManipulator.Rings[FileManipulator.Rings.ElementAt(FileManipulator.Rings.Count - 1).Key][ring] = FirstIndex;
   
        }
        #endregion

        private void inputText_KeyDown(object sender, KeyEventArgs e)
        {
            inputText.Clear();
            inputText.TextChanged -= inputTextChange;
            inputText.TextChanged += inputTextChange;    
        }

        private void rawText_TextChanged(object sender, TextChangedEventArgs e)
        {
            rawText.Text = rawOutput;
        }
    }
}
