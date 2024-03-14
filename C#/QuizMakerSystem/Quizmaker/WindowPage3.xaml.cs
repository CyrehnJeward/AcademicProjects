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
    /// Interaction logic for WindowPage3.xaml
    /// </summary>
    public partial class WindowPage3 : Window
    {
        DataClassesDataContext DCCDDC = new DataClassesDataContext(Properties.Settings.Default.BT3MP1_TrialConnectionString);
        Dictionary<int, string[]> dicQuestion = new Dictionary<int, string[]>();
        KeyValuePair<int, string[]> pair;




        public WindowPage3()
        {
            InitializeComponent();
           
            btnNextQuestion.IsEnabled = false;
            btnSubmit.IsEnabled = false;
        }

        private void btnStartQuiz_Click(object sender, RoutedEventArgs e)
        {

            var SQL = (from x in DCCDDC.viewQuestionAnswers where Int32.Parse(GlobalCode.nQuizNum) == x.QuizID select x);
            foreach (var c in SQL)
            {
                string[] a = { c.QOne, c.QTwo, c.QThree, c.QFour, c.QQuestion };
                dicQuestion.Add(c.QuizID, a);

                Random rnd = new Random();
                //int randomlist = rnd.Next(0, listQuestion.Count);
                //int listrandom = listQuestion[randomlist];

                //random
                for (int x = 0; x < dicQuestion.Count; x++)
                {
                    int index = rnd.Next(0, dicQuestion.Count);
                    pair = dicQuestion.ElementAt(index);
                }
                string[] randQuest = pair.Value;
                txtQuizQuestion.Text = randQuest[4];
                txtFirst.Text = randQuest[0];
                txtSecond.Text = randQuest[1];
                txtThird.Text = randQuest[2];
                txtFourth.Text = randQuest[3];

            }

            btnStartQuiz.IsEnabled = false;
            btnNextQuestion.IsEnabled = true;


        }
        private void btnNextQuestion_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
