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
    /// Interaction logic for RequestList.xaml
    /// </summary>
    public partial class RequestList : Window
    {
        ClinicConnectionDBDataContext clinic = new ClinicConnectionDBDataContext(Properties.Settings.Default.CMSConnectionString2);
        public RequestList()
        {
            InitializeComponent();
            requestlist();
        }

        void requestlist()
        {
            var list = clinic.uspRequestList();
            string record = "";

            foreach (uspRequestListResult rec in list)
            {
                record = rec.Student_ID + " | " + rec.FirstName + " " + rec.LastName + " | " + rec.RequestDate;
                lb_requestlist.Items.Add(record);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Close application?", "Close", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Environment.Exit(0);
            else
                e.Cancel = true;
        }

        private void lb_requestlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb_requestlist.SelectedItem == null)
            {

            }
            else
            {
                int ID = int.Parse(lb_requestlist.SelectedItem.ToString().Substring(0, 1));

                var bDetails = clinic.uspBorrowedEquipLog(ID);

                foreach (uspBorrowedEquipLogResult de in bDetails)
                {
                    tb_studentid.Text = de.Student_ID.ToString();
                    tb_FN.Text = de.FirstName;
                    tb_LN.Text = de.LastName;
                    tb_Course.Text = de.Course;
                    tb_Level.Text = de.Course_Level.ToString();
                    tb_Ailment.Text = de.Findings;
                }
            }
        }

        private void btn1_itemlog_Click(object sender, RoutedEventArgs e)
        {
            BorrowedItemLog bil = new BorrowedItemLog();
            Hide();
            bil.Show();
            bil.Title = "BorrowedItemLog: User : " + Title.Substring(20);
        }

        private void btn1_addreqmeds_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
