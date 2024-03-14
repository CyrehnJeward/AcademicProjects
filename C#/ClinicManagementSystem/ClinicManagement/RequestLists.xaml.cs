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

namespace Clinic
{
    /// <summary>
    /// Interaction logic for RequestList.xaml
    /// </summary>
    public partial class RequestLists : Window
    {
        Login login = new Login();
        Dictionary<string, string[]> dicRequestList = new Dictionary<string, string[]>();
        int ID = 0;

        private bool equipPlus = false;
        private bool equipMinus = false;
        private bool medPlus = false;
        private bool medMinus = false;
        private int equipQuantity = 0;
        private int medQuantity = 0;
        public RequestLists()
        {
            InitializeComponent();
            requestlist();
            MedAndEquip();
            lbl_title.Content = "Request ID: ";
        }

        void requestlist()
        {
            Login login = new Login();
            var list = globalclass.clinic.W4_RequestList();
            dicRequestList.Clear();
            foreach (W4_RequestListResult rec in list)
            {

                string[] record = { rec.Student_ID.ToString(), rec.FirstName.ToString(), rec.LastName.ToString(), rec.Course, rec.Course_Level.ToString(), rec.Findings };
                dicRequestList[rec.Request_ID.ToString()] = new string[] { record[0], record[1], record[2], record[3], record[4], record[5] };

            }
            lb_requestlist.Items.Refresh();
            lb_requestlist.ItemsSource = dicRequestList.Keys;
            lb_requestlist.Items.Refresh();
        }

        void MedAndEquip()
        {
            //Login login = new Login();
            var meds = globalclass.clinic.W4_Medicines();
            foreach (W4_MedicinesResult med in meds)
                cmb_medlist.Items.Add(med.MedName);

            var equips = globalclass.clinic.uspEquipments();
            foreach (uspEquipmentsResult equip in equips)
                cmb_equiplist.Items.Add(equip.EquipName);
        }

        void studentEquips()
        {
            //Login login = new Login();
            lb_materiallist.Items.Clear();
            var studentEquips = globalclass.clinic.W4_GetStudentRequestEquips(int.Parse(lb_requestlist.SelectedItem.ToString()));
            foreach (W4_GetStudentRequestEquipsResult equip in studentEquips)
            {
                if (equip.Remove != true)
                {
                    lb_materiallist.Items.Add(equip.EquipName + " | " + equip.Quantity);
                }
            }
        }

        void PlusMinusQuantity()
        {
            if (cmb_equiplist.SelectedItem == null)
                tb_equipquantity.Text = "";
            if (cmb_medlist.SelectedItem == null)
                tb_medsquantity.Text = "";

            if (equipPlus)
            {
                equipQuantity++;

                if (equipQuantity > int.Parse(lbl_equipstock.Content.ToString().Substring(7)))
                    equipQuantity = 0;
                tb_equipquantity.Text = equipQuantity.ToString();
            }
            if (equipMinus)
            {
                equipQuantity--;

                if (equipQuantity < 0)
                    equipQuantity = int.Parse(lbl_equipstock.Content.ToString().Substring(7));
                tb_equipquantity.Text = equipQuantity.ToString();
            }
            if (medPlus)
            {
                medQuantity++;

                if (medQuantity > int.Parse(lbl_medstock.Content.ToString().Substring(7)))
                    medQuantity = 0;
                tb_medsquantity.Text = medQuantity.ToString();
            }
            if (medMinus)
            {
                medQuantity--;

                if (medQuantity < 0)
                    medQuantity = int.Parse(lbl_medstock.Content.ToString().Substring(7));
                tb_medsquantity.Text = medQuantity.ToString();
            }
        }

        void EquipDetailsClear()
        {
            cmb_equiplist.SelectedItem = null;
            cmb_equiplist.Text = "";
            lbl_equipstock.Content = "Stock: ";
            tb_equipquantity.Text = "";
            equipQuantity = 0;
        }

        void MedsDetailsClear()
        {
            cmb_medlist.SelectedItem = null;
            cmb_medlist.Text = "";
            lbl_medstock.Content = "Stock: ";
            tb_medsquantity.Text = "";
            medQuantity = 0;
        }

        void RequestDetailsClear()
        {
            lb_requestlist.SelectedItem = null;
            tb_studentid.Text = "";
            tb_FN.Text = "";
            tb_LN.Text = "";
            tb_Course.Text = "";
            tb_Level.Text = "";
            tb_Ailment.Text = "";
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
            //Login login = new Login();

            if (lb_requestlist.SelectedIndex == -1)
            {

            }
            else
            {
                int temp = lb_requestlist.SelectedIndex;
                string[] keys = dicRequestList.Keys.ToArray();
                string key = keys[temp];

                tb_studentid.Text = dicRequestList[key][0];
                tb_FN.Text = dicRequestList[key][1];
                tb_LN.Text = dicRequestList[key][2];
                tb_Course.Text = dicRequestList[key][3];
                tb_Level.Text = dicRequestList[key][4];
                tb_Ailment.Text = dicRequestList[key][5];

                studentEquips();
                btn1_remove.IsEnabled = true;
            }
        }



        private void btn1_removeequipreq_Click(object sender, RoutedEventArgs e)
        {
            //Login login = new Login();
            MessageBoxResult result = MessageBox.Show("Remove this Item?", "", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                if (lb_materiallist.SelectedItem == null)
                {
                    MessageBox.Show("Select an Item First", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                {
                    string[] equipDetails = lb_materiallist.SelectedItem.ToString().Split('|');
                    var rowC = globalclass.clinic.W4_checkExistingItem(int.Parse(lb_requestlist.SelectedItem.ToString()), equipDetails[0]);
                    foreach (W4_checkExistingItemResult count in rowC)
                    {
                        if (count.rowCount == 1)
                        {
                            globalclass.clinic.W4_EquipmentReUpdate(int.Parse(lb_requestlist.SelectedItem.ToString()), equipDetails[0], int.Parse(equipDetails[1]));
                            studentEquips();
                        }
                        else
                            lb_materiallist.Items.Remove(lb_materiallist.SelectedItem);
                    }
                    EquipDetailsClear();
                }
            }
        }

        private void btn1_removemedreq_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Remove this Item?", "", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                if (lb_medicinelist.SelectedItem == null)
                {
                    MessageBox.Show("Select an Item First", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                {
                    lb_medicinelist.Items.Remove(lb_medicinelist.SelectedItem);
                    MedsDetailsClear();
                }
            }
        }

        private void cmb_equiplist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Login login = new Login();
            if (cmb_equiplist.SelectedItem == null)
            {

            }
            else
            {
                var equipData = globalclass.clinic.W4_EquipmentStock(cmb_equiplist.SelectedItem.ToString());
                foreach (W4_EquipmentStockResult stock in equipData)
                    lbl_equipstock.Content = "Stock: " + stock.Available_Qty;

                tb_equipquantity.Text = "0";
            }
        }

        private void cmb_medlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_medlist.SelectedItem == null)
            {

            }
            else
            {
                var medData = globalclass.clinic.uspMedicineStock(cmb_medlist.SelectedItem.ToString());
                foreach (uspMedicineStockResult stock in medData)
                    lbl_medstock.Content = "Stock: " + stock.Available_Qty;

                tb_medsquantity.Text = "0";
            }
        }

        private void btn2_increment_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_equiplist.SelectedItem != null)
            {
                equipPlus = true;
                equipMinus = false;
                medPlus = false;
                medMinus = false;
                PlusMinusQuantity();
            }
        }

        private void btn2_decrement_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_equiplist.SelectedItem != null)
            {
                equipPlus = false;
                equipMinus = true;
                medPlus = false;
                medMinus = false;
                PlusMinusQuantity();
            }
        }

        private void btn1_increment_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_medlist.SelectedItem != null)
            {
                equipPlus = false;
                equipMinus = false;
                medPlus = true;
                medMinus = false;
                PlusMinusQuantity();
            }
        }

        private void btn1_decrement_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_medlist.SelectedItem != null)
            {
                equipPlus = false;
                equipMinus = false;
                medPlus = false;
                medMinus = true;
                PlusMinusQuantity();
            }
        }

        private void btn1_addreqequip_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_equiplist.SelectedItem == null)
            {

            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Add another Item?", "", MessageBoxButton.OKCancel, MessageBoxImage.Asterisk);
                if (result == MessageBoxResult.OK)
                {
                    string[] equipNames = new string[lb_materiallist.Items.Count];
                    string item = "";
                    for (int x = 0; x < equipNames.Length; x++)
                    {
                        item = lb_materiallist.Items[x].ToString().Split('|')[0].Substring(0, lb_materiallist.Items[x].ToString().Split('|')[0].Length - 1);
                        equipNames[x] = item;
                    }

                    if (equipNames.Contains(cmb_equiplist.SelectedItem.ToString()))
                        MessageBox.Show("That Item already exist", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                    else
                    {
                        lb_materiallist.Items.Add(cmb_equiplist.SelectedItem + " | " + tb_equipquantity.Text);

                    }
                }
                EquipDetailsClear();
            }
        }

        private void btn1_addreqmeds_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_medlist.SelectedItem == null)
            {

            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Add another Item?", "", MessageBoxButton.OKCancel, MessageBoxImage.Asterisk);
                if (result == MessageBoxResult.OK)
                {
                    string[] medNames = new string[lb_medicinelist.Items.Count];
                    string item = "";
                    for (int x = 0; x < lb_medicinelist.Items.Count; x++)
                    {
                        item = lb_medicinelist.Items[x].ToString().Split('|')[0].Substring(0, lb_medicinelist.Items[x].ToString().Split('|')[0].Length - 1);
                        medNames[x] = item;
                    }

                    if (medNames.Contains(cmb_medlist.SelectedItem.ToString()))
                        MessageBox.Show("That Item already exist", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                    else
                    {
                        lb_medicinelist.Items.Add(cmb_medlist.SelectedItem + " | " + tb_medsquantity.Text);
                    }
                }
                MedsDetailsClear();
            }
        }

        private void btn1_edit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Edit Patient Request?", "", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                if (lb_requestlist.SelectedItem == null)
                {
                    MessageBox.Show("Select a Patient First", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                {
                    ID = int.Parse(lb_requestlist.SelectedItem.ToString());
                    cmb_equiplist.IsEnabled = true;
                    btn1_removeequipreq.IsEnabled = true;
                    btn1_addreqequip.IsEnabled = true;
                    btn1_update.IsEnabled = true;
                    btn2_increment.IsEnabled = true;
                    btn2_decrement.IsEnabled = true;
                }
            }
        }

        private void btn1_remove_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Remove this request?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("Request " + lb_requestlist.SelectedItem + " remove successfully", "", MessageBoxButton.OK, MessageBoxImage.Information);
                globalclass.clinic.W4_Remove(int.Parse(lb_requestlist.SelectedItem.ToString()));
                requestlist();
            }
        }

        private void btn1_update_Click(object sender, RoutedEventArgs e)
        {
            if (lb_materiallist.SelectedItem == null)
            {
                MessageBox.Show("Select an Item first", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                string equipName = lb_materiallist.SelectedItem.ToString().Split('|').FirstOrDefault();
                var rorC = (from s in globalclass.clinic.vPendingPatientLists where ID == s.Request_ID && s.EquipName == equipName select s);
                int index = lb_materiallist.Items.IndexOf(lb_materiallist.SelectedItem);
                foreach (vPendingPatientList c in rorC)
                {
                    if (ID == c.Request_ID)
                    {
                        globalclass.clinic.W4_UpdateEquipQty(c.Request_ID, c.EquipName, int.Parse(tb_equipquantity.Text));
                        studentEquips();
                        MessageBox.Show("Item Updated", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }
                    else
                    {
                        string item = equipName + " | " + tb_equipquantity.Text;
                        lb_materiallist.Items.Remove(lb_materiallist.SelectedItem);
                        lb_materiallist.Items.Insert(index, item);
                        MessageBox.Show("Item not Updated", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }
                }

                EquipDetailsClear();
            }
        }

        private void lb_materiallist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb_materiallist.SelectedItem == null)
            {

            }
            else
            {
                string item = lb_materiallist.SelectedItem.ToString().Split('|')[0].Substring(0, lb_materiallist.SelectedItem.ToString().Split('|')[0].Length - 1);
                int index = cmb_equiplist.Items.IndexOf(item);
                cmb_equiplist.Text = cmb_equiplist.Items[index].ToString();
                equipQuantity = int.Parse(lb_materiallist.SelectedItem.ToString().Split('|')[1].Substring(1));
                tb_equipquantity.Text = lb_materiallist.SelectedItem.ToString().Split('|')[1].Substring(1);
            }
        }

        private void btn1_requests_Click(object sender, RoutedEventArgs e)
        {
            RequestLists rl = new RequestLists();
            string medName = "";
            string equipName = "";
            int medQty = 0;
            int equipQty = 0;
            string message = "Confirm request of patient " + lb_requestlist.SelectedItem + "?";
            string title = "Confirmation";
            MessageBoxButton button = MessageBoxButton.OKCancel;
            MessageBoxImage image = MessageBoxImage.Warning;
            MessageBoxResult result = MessageBox.Show(message, title, button, image);
            if (result == MessageBoxResult.OK)
            {
                globalclass.idnum = rl.Title.Substring(10);
                globalclass.username = rl.lbl_staffname.Content.ToString();

                if (lb_medicinelist.Items.Count == 0 && lb_materiallist.Items.Count == 0)
                {
                    MessageBox.Show("No Medicine nor Equipment selected", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    foreach (object meds in lb_medicinelist.Items)
                    {
                        string[] medDetails = meds.ToString().Split('|');
                        medName = medDetails[0].Substring(0, medDetails[0].Length - 1);
                        medQty = int.Parse(medDetails[1].Substring(1));
                        globalclass.clinic.W4_InsertRequestMeds(int.Parse(lb_requestlist.SelectedItem.ToString()), medName, medQty);
                    }

                    foreach (object equips in lb_materiallist.Items)
                    {
                        string[] equipDetails = equips.ToString().Split('|');
                        equipName = equipDetails[0].Substring(0, equipDetails[0].Length - 1);
                        equipQty = int.Parse(equipDetails[1].Substring(1));
                        globalclass.clinic.W4_InsertUpdateEquips(int.Parse(lb_requestlist.SelectedItem.ToString()), equipName, equipQty);
                    }

                    globalclass.clinic.W4_RequestUpdate(int.Parse(lb_requestlist.SelectedItem.ToString()), int.Parse(Title.Substring(10)), tb_Ailment.Text.ToString());
                    globalclass.clinic.W4_PatientInfoUpdate(int.Parse(lb_requestlist.SelectedItem.ToString()), tb_studentid.Text, tb_FN.Text, tb_LN.Text, tb_Course.Text, int.Parse(tb_Level.Text));
                    MessageBox.Show("Request Done Successfully!", "DONE", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                    lb_materiallist.Items.Clear();
                    lb_medicinelist.Items.Clear();
                    cmb_equiplist.IsEnabled = false;
                    btn1_removeequipreq.IsEnabled = false;
                    btn1_addreqequip.IsEnabled = false;
                    btn1_update.IsEnabled = false;
                    btn2_increment.IsEnabled = false;
                    btn2_decrement.IsEnabled = false;
                    lb_requestlist.Items.Refresh();
                    EquipDetailsClear();
                    MedsDetailsClear();
                    RequestDetailsClear();
                    requestlist();
                }
            }
        }

        private void btn1_back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mn = new MainWindow();
            Hide();
            mn.Show();
            var ID = globalclass.clinic.W4_GetStaffID(int.Parse(Title.Substring(20)));
            foreach (W4_GetStaffIDResult id in ID)
            {
                var a = globalclass.clinic.W1_StaffDetails(id.Staff_ID);

                foreach (W1_StaffDetailsResult b in a)
                {
                    Stream stream = new MemoryStream(b.Photo_Loc.ToArray());
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = stream;
                    image.EndInit();
                    mn.img_staff.Source = image;
                    mn.lbl_staffname.Content = b.LastName.ToUpper() + ", " + b.FirstName.ToUpper();
                    mn.lbl_designation.Content = "CLINIC STAFF";
                    mn.Title = "Mainwindow: User " + int.Parse(Title.Substring(20));
                }
            }
            login = null;
        }

        private void tb_Level_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(tb_Level.Text, out int level))
            {

            }
            else
                tb_Level.Text = "";
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
        }

        private void btn1_itemlog_Click(object sender, RoutedEventArgs e)
        {
            Names();
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
