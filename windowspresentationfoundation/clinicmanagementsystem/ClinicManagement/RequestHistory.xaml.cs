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
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Clinic
{
    /// <summary>
    /// Interaction logic for RequestHistory.xaml
    /// </summary>
    public partial class RequestHistory : Window
    {
        private Login login = new Login();
        private Dictionary<int, string[]> requestDetails = new Dictionary<int, string[]>();
        private string path = "";

        string stdDetails = "{0, -30}\t{1, -10}";
        string stdDetailss = "{0, -30}\t{1, -10}\t{2, -10}\t{3, -10}";
        string stdDetail = "{0, -25}\t{1, -30}";
        List<string> medicineList = new List<string>() { };
        List<string> equipList = new List<string>() { };
        public RequestHistory()
        {
            InitializeComponent();
            btn_Print.IsEnabled = false;

            lbl_Medicine.Content = String.Format(stdDetail, "Medicine Name: ", "Quantity:");
            lbl_Equipment.Content = String.Format(stdDetail, "Equipment Name: ", "Quantity:");



        }

        //private void ClearDate()
        //{
        //    dpkr_from.SelectedDate = null;
        //    dpkr_to.SelectedDate = null;
        //    dpkr_from.Text = "";
        //    dpkr_to.Text = "";
        //}

        private void WriteInFile(string message)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
                sw.Write(message);
        }

        private void ClearTxbx()
        {
            tb_studentid.Text = "";
            tb_date.Text = "";
            tb_time.Text = "";
            tb_FN.Text = "";
            tb_LN.Text = "";
            tb_Course.Text = "";
            tb_level.Text = "";
            tb_findings.Text = "";
            lb_medicinelist.Items.Clear();
            lb_materiallist.Items.Clear();
        }

        private void Search()
        {
            if (dpkr_from.SelectedDate == null || dpkr_to.SelectedDate == null)
            {

            }
            else
            {
                btn_Print.IsEnabled = true;
                requestDetails.Clear();
                lb_history.Items.Refresh();
                ClearTxbx();
                if (dpkr_from.SelectedDate == null || dpkr_to.SelectedDate == null)
                {

                }
                else
                {
                    DateTime start = DateTime.Parse(dpkr_from.SelectedDate.ToString());
                    DateTime end = DateTime.Parse(dpkr_to.SelectedDate.ToString());
                    if (start > end)
                    {
                        MessageBox.Show("Select a proper range of date", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    var requestD = globalclass.clinic.W7_GetAllRecords(start, end);
                    foreach (W7_GetAllRecordsResult details in requestD)
                    {
                        string[] orderDetails = {
                                                details.Request_ID.ToString(),
                                                details.Student_ID.ToString(),
                                                details.Date.ToString(),
                                                details.Time.ToString(),
                                                details.FirstName.ToString(),
                                                details.LastName.ToString(),
                                                details.Course.ToString(),
                                                details.Course_Level.ToString(),
                                                details.Findings.ToString()
                                            };

                        requestDetails[details.Request_ID] = orderDetails;

                        lb_history.Items.Refresh();
                        lb_history.ItemsSource = requestDetails.Keys;
                        lb_history.Items.Refresh();
                    }
                    //ClearDate();
                }
            }
        }

        private void dpkr_from_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
            ClearTxbx();
        }

        private void dpkr_to_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
            ClearTxbx();
        }

        private void lb_history_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lb_medicinelist.Items.Clear();
            lb_materiallist.Items.Clear();
            lb_materiallist.SelectedItem = null;
            btn_Print.IsEnabled = true;
            if (lb_history.SelectedIndex == -1)
            {

            }
            else
            {
                

                int index = lb_history.SelectedIndex;
                int[] keys = requestDetails.Keys.ToArray();
                int key = keys[index];

                tb_studentid.Text = requestDetails[key][1];
                tb_date.Text = requestDetails[key][2].Split(' ')[0];
                tb_time.Text = requestDetails[key][3];
                tb_FN.Text = requestDetails[key][4];
                tb_LN.Text = requestDetails[key][5];
                tb_Course.Text = requestDetails[key][6];
                tb_level.Text = requestDetails[key][7];
                tb_findings.Text = requestDetails[key][8];

                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString("#FFECEAF3");
                tb_returnedQty.Text = null;
                lb_Status1.Background = brush;



                var equips = globalclass.clinic.W7_GetStudentEquipReqs(int.Parse(requestDetails[key][0]));
                foreach (W7_GetStudentEquipReqsResult equ in equips)
                {
                    lb_materiallist.Items.Add(String.Format(stdDetails, equ.EquipName, equ.Static_Quantity));
                }
                

                var equipPrint = (from c in globalclass.clinic.vHistoryLogs where int.Parse(lb_history.SelectedItem.ToString()) == c.Request_ID && tb_studentid.Text == c.Student_ID select c);
                foreach (vHistoryLog ep in equipPrint)
                {
                    int Quantity = int.Parse(ep.Static_Quantity.ToString()) - int.Parse(ep.Quantity.ToString());

                    if (Quantity < ep.Static_Quantity)
                    {
                        string status = "Incomplete";
                        equipList.Add(String.Format(stdDetailss, ep.EquipName, ep.Static_Quantity, Quantity, status));
                    }
                    else if (Quantity == ep.Static_Quantity)
                    {
                        string status = "Complete";
                        equipList.Add(String.Format(stdDetailss, ep.EquipName, ep.Static_Quantity, Quantity, status));
                    }


                }

                var meds = globalclass.clinic.W7_GetStudentMedsReqs(int.Parse(requestDetails[key][0]));
                foreach (W7_GetStudentMedsReqsResult me in meds)
                {
                    lb_medicinelist.Items.Add(String.Format(stdDetails, me.MedName, me.Quantity));
                    
                }

                var medicinePrint = (from c in globalclass.clinic.vStudentRequestMeds where int.Parse(lb_history.SelectedItem.ToString()) == c.Request_ID && tb_studentid.Text == c.Student_ID select c);
                foreach (vStudentRequestMed mp in medicinePrint)
                {
                    medicineList.Add(String.Format(stdDetails, mp.MedName, mp.Quantity));
                }

            }
        }

        private void lb_materiallist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb_materiallist.SelectedItem == null)
            {

            }
            else
            {
                int ReqID = int.Parse(lb_history.SelectedItem.ToString());
                string equipName = lb_materiallist.SelectedItem.ToString().Split('\t')[0].Substring(0, lb_materiallist.SelectedItem.ToString().Split('\t')[0].Length - 1);
                string Static_Qty = lb_materiallist.SelectedItem.ToString().Substring(lb_materiallist.SelectedItem.ToString().IndexOf("\t") + 1);
                var returnQty = globalclass.clinic.W7_ReturnedQty(ReqID, equipName);
                foreach (W7_ReturnedQtyResult qty in returnQty)
                {
                    tb_returnedQty.Text = qty.Return_Quantity.ToString();
                    if (int.Parse(Static_Qty) > int.Parse(tb_returnedQty.Text))
                    {
                        lb_Status1.Background = Brushes.Red;
                    }
                    else if (int.Parse(Static_Qty) == int.Parse(tb_returnedQty.Text))
                    {
                        lb_Status1.Background = Brushes.Green;
                    }
                    else
                    {
                        var converter = new System.Windows.Media.BrushConverter();
                        var brush = (Brush)converter.ConvertFromString("#FFECEAF3");
                        lb_Status1.Background = brush;
                    }

                }
                    
            }
        }

        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {
            
            string rStudentID = tb_studentid.Text;
            string rDate = tb_date.Text;
            string rTime = tb_time.Text;
            string rFN = tb_FN.Text;
            string rLN = tb_LN.Text;
            string rCourse = tb_Course.Text;
            string rLevel = tb_level.Text;
            string rFindings = tb_findings.Text;
            string[] All = new string[] { rStudentID, rDate, rTime, rFN, rLN, rCourse, rLevel, rFindings};

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File(.txt;*)|.txt;*";
            sfd.InitialDirectory = @"C:\";
            if (dpkr_from.SelectedDate == null || dpkr_to.SelectedDate == null)
                sfd.FileName = "Report";
            else
                sfd.FileName = "Report From " + dpkr_from.SelectedDate + " To " + dpkr_to.SelectedDate;

            if (sfd.ShowDialog() == true)
            {

                path = System.IO.Path.GetFullPath(sfd.FileName);
                WriteInFile("User Details:" + "\n");
                WriteInFile(String.Format(stdDetails, "Student ID:", All[0]));
                WriteInFile(String.Format(stdDetails, "\nDate and Time of Borrowed:", All[1] + " " +All[2]));
                WriteInFile(String.Format(stdDetails, "\nFirstName:", All[3]));
                WriteInFile(String.Format(stdDetails, "\nLastName:", All[4]));
                WriteInFile(String.Format(stdDetails, "\nCourse:", All[5]));
                WriteInFile(String.Format(stdDetails, "\nLevel:", All[6]));
                WriteInFile(String.Format(stdDetails,"\nFindings/ Ailment:", All[7]));




                WriteInFile("\n--------------------------" + "\n");
                WriteInFile(String.Format(stdDetailss,"Equipment List:", "Quantity", "Returned", "Status"));

                for (int x = 0; x < equipList.Count; x++)
                {
                    WriteInFile("\n"+ equipList[x] + "\n");
                }

                WriteInFile("--------------------------" + "\n");
                WriteInFile(String.Format(stdDetails, "Medicine List:", "Quantity\n"));

                for (int x = 0; x < medicineList.Count; x++)
                {
                    WriteInFile("\n" + medicineList[x] + "\n");
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Close application?", "Close", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Environment.Exit(0);
            else
                e.Cancel = true;
        }

        #region //Main Navigator
        BitmapImage ByteArrayToImage(byte[] imgByte) //ADDED CODE
        {
            Stream stream = new MemoryStream(imgByte);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();
            return image;
        }

        void Names()
        {
            globalclass.idnum = Title.ToString();
            globalclass.username = lbl_staffname.Content.ToString();
            img_staff.Source = ByteArrayToImage(globalclass.imageloc);

        }

        private void btn1_itemlog_Click(object sender, RoutedEventArgs e)
        {
            BorrowedItemLog bil = new BorrowedItemLog();
            Hide();
            bil.Show();
            bil.Title = globalclass.idnum = Title.ToString();
            bil.lbl_staffname.Content = globalclass.username;
        }

        private void btn1_medicine_Click(object sender, RoutedEventArgs e)
        {
            Names();
            MedicineInventory mi = new MedicineInventory();
            Hide();
            mi.Show();
            mi.Title = globalclass.idnum;
            mi.lbl_staffname.Content = globalclass.username;
            mi.img_staff.Source = ByteArrayToImage(globalclass.imageloc);
        }

        private void btn1_equipments_Click(object sender, RoutedEventArgs e)
        {
            Names();
            EquipmentInventory ei = new EquipmentInventory();
            Hide();
            ei.Show();
            ei.Title = globalclass.idnum;
            ei.lbl_staffname.Content = globalclass.username;
            ei.img_staff.Source = ByteArrayToImage(globalclass.imageloc);
        }

        private void btn1_records_Click(object sender, RoutedEventArgs e)
        {
            Names();
            RequestHistory rh = new RequestHistory();
            Hide();
            rh.Show();
            rh.Title = globalclass.idnum;
            rh.lbl_staffname.Content = globalclass.username;
            rh.img_staff.Source = ByteArrayToImage(globalclass.imageloc);

        }

        private void btn1_staff_Click(object sender, RoutedEventArgs e)
        {
            Names();
            UpdateStaff staff = new UpdateStaff();
            Hide();
            staff.Show();
            staff.Title = globalclass.idnum;
            staff.lbl_staffname.Content = globalclass.username;
            staff.img_staff.Source = ByteArrayToImage(globalclass.imageloc);
            //staff.lbl_staffname.Content = globalclass.username;
        }

        private void btn1_request_Click(object sender, RoutedEventArgs e)
        {
            Names();
            RequestLists rl = new RequestLists();
            Hide();
            rl.Show();
            rl.Title = globalclass.idnum;
            rl.lbl_staffname.Content = globalclass.username;
            rl.img_staff.Source = ByteArrayToImage(globalclass.imageloc);
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
        #endregion
    }
}
