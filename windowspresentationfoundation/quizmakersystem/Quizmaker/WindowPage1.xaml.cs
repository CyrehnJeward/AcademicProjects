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
    public partial class WindowPage1 : Window
    {
        DataClassesDataContext DCCDDC = new DataClassesDataContext(Properties.Settings.Default.BT3MP1_TrialConnectionString);


        Dictionary<string, string[]> d1ActiveQuiz = new Dictionary<string, string[]>();
        Dictionary<int, string> d1ActiveQuizKeyPair = new Dictionary<int, string>();

        Dictionary<string, string[]> d2ActiveList = new Dictionary<string, string[]>();

        public WindowPage1()
        {
            InitializeComponent();
            //------------------------------------------------------------------------------//
            var ActiveQuiz = (from s in DCCDDC.viewSUMofScore1s select s);
            d1ActiveQuiz.Clear();
            foreach (viewSUMofScore1 x in ActiveQuiz)
            {
                string[] a = { x.Attempt_ID.ToString() };
                d1ActiveQuiz[x.Quiz_ID.ToString()] = new string[] { a[0]};
            }
            lbActiveQuizzes.ItemsSource = d1ActiveQuiz.Keys;
            lbActiveQuizzes.Items.Refresh();


        }

        private void btnCreateQuiz_Click(object sender, RoutedEventArgs e)
        {
            WindowPage2 a = new WindowPage2();
            a.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }

        private void lbActiveQuizzes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbActiveQuizzes.SelectedIndex != -1)
            {
               
                string selectedQuizID = (string)lbActiveQuizzes.SelectedItem;
                var studentPerQuiz = (from x in DCCDDC.viewSUMofScore1s where x.Quiz_ID == int.Parse(selectedQuizID) select x);
                d2ActiveList.Clear();
                foreach (viewSUMofScore1 u in studentPerQuiz)
                {

                    string[] a = { u.Last_Name, u.First_Name, u.Student_Score.ToString(), u.Student_Attempt.ToString(),  };
                    d2ActiveList[u.User_ID.ToString()] = new string[] { a[0], a[1], a[2], a[3] };

                }
                lbActiveList.ItemsSource = d2ActiveList.Keys;
                lbActiveList.Items.Refresh();


            }
        }





        private void lbActiveList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbActiveList.SelectedIndex != -1)
            {
                int temp = lbActiveList.SelectedIndex;
                string[] keys = d2ActiveList.Keys.ToArray<string>();
                string key = keys[temp];
                int uTypeIndex = 0;
                int count = 0;
                

                lblName.Content = d2ActiveList[key][0] + ", " + d2ActiveList[key][1];
                lblAttemptScore.Content = d2ActiveList[key][2];
                lblTotalAttempt.Content = d2ActiveList[key][3];
                lblAverageScore.Content = d2ActiveList[key][2]; 

                foreach (KeyValuePair<int, string> kvp in d1ActiveQuizKeyPair)
                {
                    if (kvp.Key == int.Parse(d1ActiveQuiz[key][2]))
                    {
                        uTypeIndex = count;
                        break;
                    }
                    else
                    {
                        count++;
                    }
                }
            }

            
        }
    }
}
