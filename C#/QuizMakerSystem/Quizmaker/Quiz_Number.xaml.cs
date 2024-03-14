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
using System.Windows.Shapes;

namespace Finals_Machine_Problem
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Quiz_Number : Window
    {
        DataClassesDataContext DCCDDC = new DataClassesDataContext(Properties.Settings.Default.BT3MP1_TrialConnectionString1);
        public Quiz_Number()
        {
            InitializeComponent();
            btnEnter.IsEnabled = false;
            //problem is that once the textbox is clear by backspace, the enter button is not set to disable
            // THe requirement is that enter button will set to enable once the textbox read only integer

        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (txtQuizNumber.Text.Length > 0)
            {
                var users = DCCDDC.uspLoginQuiz(Int32.Parse(txtQuizNumber.Text));
                foreach (uspLoginQuizResult ulr in users)
                {
                    if (ulr.QuizID == Int32.Parse(txtQuizNumber.Text))
                    {
                        GlobalCode.nQuizNum = txtQuizNumber.Text;
                    }
                    else
                    {
                        MessageBox.Show(".");
                    }

                }
            }
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtQuizNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtQuizNumber.Text.Length > 0)
            {
                if (txtQuizNumber.Text.All(char.IsDigit))
                {
                    btnEnter.IsEnabled = true;
                }
            }
            else
            {
                btnEnter.IsEnabled = false;
            }
            
            

        }
    }
}
