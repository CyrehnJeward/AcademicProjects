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

namespace Clinic
{
    /// <summary>
    /// Interaction logic for PatientInfo.xaml
    /// </summary>
    public partial class PatientInfo : Window
    {
        public TextBox[] details = new TextBox[6];
        string stdDetail = "{0, -10}\t{1, -40}";
        string stdDetails = "{0, -30}\t{1, -10}";
        List<string> firstlist = new List<string>();
        public PatientInfo()
        {
            InitializeComponent();
            details[0] = tb_studentID;
            details[1] = tb_FN;
            details[2] = tb_LN;
            details[3] = tb_course;
            details[4] = tb_level;
            details[5] = tb_ailments;
            listboxNotification();

            lbl_Title.Content = String.Format(stdDetail, "STUDENT ID: ", "STATUS: ");
        }

        void Request()
        {
            RequestDetails rd = new RequestDetails();
            Login login = new Login();
            int level = 0;
            if (details[0].Text == "" || details[1].Text == "" || details[2].Text == "" || details[3].Text == "" || details[4].Text == "" || details[5].Text == "")
            {
                MessageBox.Show("Please Input all textboxes", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                foreach (TextBox detail in details)
                {
                    if (detail.Text == "")
                    {
                        detail.Focus();
                        break;
                    }
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Proceed to request equipment?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (int.TryParse(tb_level.Text, out level))
                    {
                        globalclass.clinic.W2_PatientInfo(tb_studentID.Text, tb_FN.Text, tb_LN.Text, tb_course.Text, int.Parse(tb_level.Text));
                        globalclass.clinic.W2_RequestFindings(tb_ailments.Text);
                        Hide();
                        rd.Show();
                        rd.Title = "RequestDetails: Student ID " + tb_studentID.Text;
                    }
                }
            }
        }


        void listboxNotification()
        {

            var list = (from s in globalclass.clinic.vPendings select s );
            firstlist.Clear();
            foreach (vPending rec in list)
            {
                if (rec.Request_Status == true)
                {
                    string records = (String.Format(stdDetails, rec.Student_ID, "Pending"));
                    firstlist.Add(records);
                }
                else if (rec.Request_Status == false)
                {
                    string records = (String.Format(stdDetails, rec.Student_ID, "Done"));
                    firstlist.Add(records);
                }



            }
            lb_Notification.Items.Refresh();
            lb_Notification.ItemsSource = firstlist;
            lb_Notification.Items.Refresh();
        }



        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Close application?", "Close", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Environment.Exit(0);
            else
                e.Cancel = true;
        }

        private void btn1_proceed_Click(object sender, RoutedEventArgs e)
        {
            Request();
        }

        private void btn1_cancel_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();

            if (MessageBox.Show("Do you want to exit?", "Close", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Hide();
                login.Show();
            }
        }

        private void tb_level_TextChanged(object sender, TextChangedEventArgs e)
        {
            int level = 0;
            if (int.TryParse(tb_level.Text, out level))
                lbl_note2.Visibility = Visibility.Hidden;
            else
            {
                lbl_note2.Visibility = Visibility.Visible;
                tb_level.Text = "";
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Request();
        }
    }
}
