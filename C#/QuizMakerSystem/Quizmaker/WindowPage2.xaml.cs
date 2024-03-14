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
    /// Interaction logic for WindowPage2.xaml
    /// </summary>
    public partial class WindowPage2 : Window
    {
        string quiztitle, QuizQuestion, quizAnswer;
        DataClassesDataContext DCCDDC = new DataClassesDataContext(Properties.Settings.Default.BT3MP1_TrialConnectionString);

        public WindowPage2()
        {
            InitializeComponent();
            disable();
            if (rdFirst.IsChecked == false || rdSecond.IsChecked == false || rdThird.IsChecked == false || rdFourth.IsChecked == false)
            {
                btnAddQuestion.IsEnabled = false;
                btnFinishQuizMaker.IsEnabled = false;
            }
            else
            {
                btnAddQuestion.IsEnabled = true;
                btnFinishQuizMaker.IsEnabled = true;
            }

        }

        private void rdFirst_Checked(object sender, RoutedEventArgs e)
        {
            if (rdFirst.IsChecked == false)
            {
                btnAddQuestion.IsEnabled = false;
                btnFinishQuizMaker.IsEnabled = false;
            }
            else
            {
                btnAddQuestion.IsEnabled = true;
                btnFinishQuizMaker.IsEnabled = true;
                rdFirst.Content = txtFirst.Text;
                string r_d = rdFirst.Content.ToString();
                radio(r_d);
            }
           
        }

        private void rdSecond_Checked(object sender, RoutedEventArgs e)
        {
            if (rdSecond.IsChecked == false)
            {
                btnAddQuestion.IsEnabled = false;
                btnFinishQuizMaker.IsEnabled = false;
            }
            else
            {
                btnAddQuestion.IsEnabled = true;
                btnFinishQuizMaker.IsEnabled = true;
                rdSecond.Content = txtSecond.Text;
                string r_d = rdSecond.Content.ToString();
                radio(r_d);
            }
           
        }

        private void rdThird_Checked(object sender, RoutedEventArgs e)
        {
            if (rdThird.IsChecked == false)
            {
                btnAddQuestion.IsEnabled = false;
                btnFinishQuizMaker.IsEnabled = false;
            }
            else
            {
                btnAddQuestion.IsEnabled = true;
                btnFinishQuizMaker.IsEnabled = true;
                rdThird.Content = txtThird.Text;
                string r_d = rdThird.Content.ToString();
                radio(r_d);
            }
         
        }

        private void rdFourth_Checked(object sender, RoutedEventArgs e)
        {
            if (rdFourth.IsChecked == false)
            {
                btnAddQuestion.IsEnabled = false;
                btnFinishQuizMaker.IsEnabled = false;
            }
            else
            {
                btnAddQuestion.IsEnabled = true;
                btnFinishQuizMaker.IsEnabled = true;
                rdFourth.Content = txtFourth.Text;
                string r_d = rdFourth.Content.ToString();
                radio(r_d);
            }
           
            
        }

        private void radio(string r_d)
        {
            quizAnswer = r_d;
        }

 

        #region //ABLE
        private void disable()
        {
            txtQuizQuestion.IsEnabled = false;
            txtFirst.IsEnabled = false;
            txtSecond.IsEnabled = false;
            txtThird.IsEnabled = false;
            txtFourth.IsEnabled = false;
            rdFirst.IsEnabled = false;
            rdSecond.IsEnabled = false;
            rdThird.IsEnabled = false;
            rdFourth.IsEnabled = false;
            btnAddQuestion.IsEnabled = false;
            btnFinishQuizMaker.IsEnabled = false;
        }

        private void enable()
        {
            txtQuizQuestion.IsEnabled = true;
            txtFirst.IsEnabled = true;
            txtSecond.IsEnabled = true;
            txtThird.IsEnabled = true;
            txtFourth.IsEnabled = true;
            rdFirst.IsEnabled = true;
            rdSecond.IsEnabled = true;
            rdThird.IsEnabled = true;
            rdFourth.IsEnabled = true;
            btnAddQuestion.IsEnabled = true;
            btnFinishQuizMaker.IsEnabled = true;
        }


        #endregion

        private void btnCreateQuiz_Click(object sender, RoutedEventArgs e)
        {
            if(txtQuizTitle.Text.Length > 0)
            {
                MessageBoxResult result = MessageBox.Show("Once created, you must finish making the quiz beacuse there is no edit functions. Is the quiz title correct?", "Quiz Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    quiztitle = txtQuizTitle.Text;
                    txtQuizTitle.IsEnabled = false;
                    enable();
                    DCCDDC.uspCreateQuiz(quiztitle.ToString(), true);
                    MessageBox.Show("Quiz Created! You will see Quiz number when quiz creation is finished!");
        

                }
                else
                    disable();
            }
            else
            {
                MessageBox.Show("Please enter the title of the question");
            }
            
        }

        private void btnAddQuestion_Click(object sender, RoutedEventArgs e)
        {
            string first, second, third, fourth, quizAnswers, quiztitle;
            first = txtFirst.Text;
            second = txtSecond.Text;
            third = txtThird.Text;
            fourth = txtFourth.Text;
            quizAnswers = quizAnswer;
            quiztitle = txtQuizTitle.Text;
            QuizQuestion = txtQuizQuestion.Text;

            //----------- dito ung insert to sql




            if (txtQuizTitle.Text.Length > 0 && txtQuizQuestion.Text.Length > 0 && txtFirst.Text.Length > 0 && txtSecond.Text.Length > 0 && txtThird.Text.Length > 0 && txtFourth.Text.Length > 0
                && rdFirst.IsChecked == true || rdSecond.IsChecked == true || rdThird.IsChecked == true || rdFourth.IsChecked == true)
            {
                MessageBoxResult result = MessageBox.Show("Question inserted into quiz!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                
                
                var ActiveQuiz = (from s in DCCDDC.viewQuizNums select s);
                string a = "";
                foreach (viewQuizNum x in ActiveQuiz)
                {
                    a = x.QuizID.ToString();
                 
                }

                

                DCCDDC.uspCreateQuestion(QuizQuestion, first, second, third, fourth, quizAnswers, null, Int32.Parse(a));

                if (result == MessageBoxResult.OK)
                {
                    #region
                    txtQuizQuestion.Clear();
                    txtFirst.Clear();
                    txtSecond.Clear();
                    txtThird.Clear();
                    txtFourth.Clear();
                    #endregion //CLEAR
                    rdFirst.IsChecked = false;
                    rdSecond.IsChecked = false;
                    rdThird.IsChecked = false;
                    rdFourth.IsChecked = false;
                }
            }
            else
            {
                MessageBox.Show("Please fill all the spaces!", "Information",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            
           


        }

        private void btnFinishQuizMaker_Click(object sender, RoutedEventArgs e)
        {

            WindowPage1 a = new WindowPage1();
            a.Show();
            this.Close();
        }

    }
}
