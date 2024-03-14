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
    /// Interaction logic for BorrowedItemLog.xaml
    /// </summary>
    public partial class BorrowedItemLog : Window
    {


        int minQuantityValue = 0,
            maxQuantityValue = 10;
        string stdDetails = "{0, -10}\t{1, -60}";

        public BorrowedItemLog()
        {
            InitializeComponent();
            InitializeComponent();
            borrowedItemList();
            tb_studentid.IsReadOnly = true;
            tb_FN.IsReadOnly = true;
            tb_LN.IsReadOnly = true;
            tb_borrowedtime.IsReadOnly = true;
            tb_course.IsReadOnly = true;
            tb_level.IsReadOnly = true;
            tb_eqname.IsReadOnly = true;
        }

        void borrowedItemList()
        {
            lbl_Title.Content = (String.Format(stdDetails, "ID:", "Quantity:" ));
       
            var equipLog = (from c in globalclass.clinic.vBorrowedEquipLogs where c.Quantity > 0 select c);
            string record = "";
            //c.Time_of_Borrow != null
            foreach (vBorrowedEquipLog log in equipLog)
            {
                record = String.Format(stdDetails, log.eRequest_ID, log.Quantity);
                lb_borrowerslist.Items.Add(record);
            }
        }

        private void lb_borrowerslist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb_borrowerslist.SelectedItem != null)
            {
                int ID = int.Parse(lb_borrowerslist.SelectedItem.ToString().Split('\t').FirstOrDefault());
                int quantity = int.Parse(lb_borrowerslist.SelectedItem.ToString().Split('\t').LastOrDefault());
                var equipLogResults = (from c in globalclass.clinic.vBorrowedEquipLogs where ID == c.eRequest_ID && quantity == c.Quantity select c);

                foreach (vBorrowedEquipLog re in equipLogResults)
                {
                    tb_studentid.Text = re.Student_ID.ToString();
                    tb_FN.Text = re.FirstName;
                    tb_LN.Text = re.LastName;
                    tb_borrowedtime.Text = re.Time_of_Borrow.ToString();
                    tb_course.Text = re.Course;
                    tb_level.Text = re.Course_Level.ToString();
                    tb_eqname.Text = re.EquipName;
                }
            }
        }

        private void btn1_return_Click(object sender, RoutedEventArgs e)
        {
            if (lb_borrowerslist.SelectedItem != null)
            {
                int temp = int.Parse(tb_quantity.Text);
                MessageBoxResult result = MessageBox.Show("Confirm return request?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    int ID = int.Parse(lb_borrowerslist.SelectedItem.ToString().Split('\t').FirstOrDefault());
                    int quantity = int.Parse(lb_borrowerslist.SelectedItem.ToString().Split('\t').LastOrDefault());
                    var equipLogResults = (from c in globalclass.clinic.vBorrowedEquipLogs where ID == c.eRequest_ID && quantity == c.Quantity select c);

                    if (temp > quantity)
                    {
                        MessageBox.Show("Inputted quantity exceeds borrowed limit!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        foreach (vBorrowedEquipLog re in equipLogResults)
                        {
                            if (temp == quantity)
                            {
                                globalclass.clinic.W4_EquipReturned(re.eRequest_ID, re.Equip_ID, temp);
                                globalclass.clinic = new ClinicManagementDBDataContext(Properties.Settings.Default.FinalClinicMSConnectionString1);

                                lb_borrowerslist.Items.Clear();
                                lb_borrowerslist.Items.Refresh();
                                var equipLog = (from c in globalclass.clinic.vBorrowedEquipLogs where c.Quantity > 0 select c);
                                string record = "";
                                foreach (vBorrowedEquipLog log in equipLog)
                                {
                                    record = (String.Format(stdDetails, log.eRequest_ID, log.Quantity));
                                    lb_borrowerslist.Items.Add(record);
                                }

                                MessageBox.Show("Return request complete!");
                            }
                            else
                            {
                                globalclass.clinic.W4_EquipReturnedNormal(re.eRequest_ID, re.Equip_ID, temp);
                                globalclass.clinic = new ClinicManagementDBDataContext(Properties.Settings.Default.FinalClinicMSConnectionString1);

                                lb_borrowerslist.Items.Clear();
                                lb_borrowerslist.Items.Refresh();
                                var equipLog = (from c in globalclass.clinic.vBorrowedEquipLogs where c.Quantity > 0 select c);
                                string record = "";
                                foreach (vBorrowedEquipLog log in equipLog)
                                {
                                    record = (String.Format(stdDetails, log.eRequest_ID, log.Quantity));
                                    lb_borrowerslist.Items.Add(record);
                                }

                                MessageBox.Show("Return request processed. There is still a pending quantity!");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Please select an item log before proceeding?", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }



        void Names()
        {
            globalclass.idnum = Title.ToString();
            globalclass.username = lbl_staffname.Content.ToString();
            //img_staff.Source = new BitmapImage(new Uri(globalclass.imageloc, UriKind.Relative));

        }

        private void btn1_request_Click(object sender, RoutedEventArgs e)
        {
            Names();
            RequestLists ei = new RequestLists();
            Hide();
            ei.Show();
            ei.Title = globalclass.idnum;
            ei.lbl_staffname.Content = globalclass.username;
        }

        private void btn1_logout_Click(object sender, RoutedEventArgs e)
        {
            Names();
            Login login = new Login();
            globalclass.idnum = "";
            globalclass.username = "";
            Hide();
            login.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Close application?", "Close", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Environment.Exit(0);
            else
                e.Cancel = true;
        }

        private void btn1_increment_Click(object sender, RoutedEventArgs e)
        {
            int number;
            if (tb_quantity.Text != "")
            {
                number = Convert.ToInt32(tb_quantity.Text);
            }
            else
            {
                number = 0;
            }
            if (number < maxQuantityValue)
            {
                tb_quantity.Text = Convert.ToString(number + 1);
            }
        }

        private void btn1_decrement_Click(object sender, RoutedEventArgs e)
        {
            int number;
            if (tb_quantity.Text != "")
            {
                number = Convert.ToInt32(tb_quantity.Text);
            }
            else
            {
                number = 0;
            }
            if (number > minQuantityValue)
            {
                tb_quantity.Text = Convert.ToString(number - 1);
            }
        }

        private void tb_quantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(tb_quantity.Text, out int quan))
                tb_quantity.Text = "";
        }

    }
}
