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
    /// Interaction logic for MedicineInventory.xaml
    /// </summary>
    public partial class MedicineInventory : Window
    {
        Login login = new Login();
        Dictionary<string, string[]> d1TransactionList = new Dictionary<string, string[]>();
        Dictionary<int, string> d2TransactionKeyPair = new Dictionary<int, string>();
        Dictionary<string, byte[]> d3MedImage = new Dictionary<string, byte[]>(); //ADDED CODE

        int minQuantityValue = 0,
            maxQuantityValue = 10;

        TextBox[] EquipInfo = new TextBox[3];

        public MedicineInventory()
        {
            InitializeComponent();
            updateListBoxContent();

            EquipInfo[0] = tb_medname;
            EquipInfo[1] = tb_description;
            EquipInfo[2] = tb_quantity;

            tb_medname.IsReadOnly = true;
            tb_description.IsReadOnly = true;
            tb_quantity.IsReadOnly = true;
        }

        void WindowRefresh()
        {
            MedicineInventory mi = new MedicineInventory();
            Hide();
            mi.Show();
        }

        BitmapImage ByteArrayToImage(byte[] imgByte) //ADDED CODE
        {
            Stream stream = new MemoryStream(imgByte);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();
            return image;
        }

        byte[] ImageToByteArray(string path) //ADDED CODE
        {
            byte[] imageByteArray = new byte[] { };
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            using (BinaryReader reader = new BinaryReader(fileStream))
            {
                imageByteArray = new byte[reader.BaseStream.Length];
                for (int x = 0; x < reader.BaseStream.Length; x++)
                    imageByteArray[x] = reader.ReadByte();
            }
            return imageByteArray;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Close application?", "Close", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Environment.Exit(0);
            else
                e.Cancel = true;
        }

        public void updateListBoxContent()
        {

            lb_reqmeds.Items.Refresh();
            var users = (
                       from s in globalclass.clinic.Medicines
                       select s
                       );
            d1TransactionList.Clear();
            d3MedImage.Clear();
            foreach (Medicine u in users)
            {
                string[] a = { u.Medicine_ID.ToString(), u.Description, u.Available_Qty.ToString() };
                d1TransactionList[" • " + u.MedName] = a;
                d3MedImage[" • " + u.MedName] = u.Image_Loc.ToArray(); //ADDED CODE
            }
            lb_reqmeds.ItemsSource = d1TransactionList.Keys;
            lb_reqmeds.Items.Refresh();
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





        private void btn1_update_Click(object sender, RoutedEventArgs e)
        {
            if (btn1_update.Content.ToString() == "UPDATE")
            {
                if (EquipInfo[0].Text == "" || EquipInfo[1].Text == "" || EquipInfo[2].Text == "")
                {
                    MessageBox.Show("Please select an equipment!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                    foreach (TextBox detail in EquipInfo)
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
                    MessageBoxResult result = MessageBox.Show("Proceed to update equipment?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        updateListBoxContent();
                        btn1_add.IsEnabled = false;
                        //btn_ImagLoc.Visibility = Visibility.Visible;
                        //tb_imageLoc.Visibility = Visibility.Visible;
                        btn1_increment.IsEnabled = true;
                        btn1_decrement.IsEnabled = true;
                        tb_medname.IsEnabled = false;
                        btn1_update.Content = "CONFIRM";
                        tb_medname.IsReadOnly = false;
                        tb_description.IsReadOnly = false;
                        tb_quantity.IsReadOnly = true;
                    }
                    else
                    {
                        foreach (TextBox detail in EquipInfo)
                        {
                            detail.Focus();
                            break;
                        }
                    }
                }
            }
            else if (btn1_update.Content.ToString() == "CONFIRM")
            {

                MessageBoxResult result = MessageBox.Show("Confirm?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    globalclass.clinic.W6_UpdateMedicine(Int32.Parse(tb_medname.Text), tb_description.Text, Int32.Parse(tb_quantity.Text));

                    btn1_add.IsEnabled = true;
                    btn1_increment.IsEnabled = false;
                    btn1_decrement.IsEnabled = false;
                    tb_medname.IsEnabled = true;
                    btn_ImagLoc.Visibility = Visibility.Hidden;
                    tb_imageLoc.Visibility = Visibility.Hidden;
                    updateListBoxContent();
                    updateListBoxContent();
                    updateListBoxContent();
                    btn1_update.Content = "UPDATE";

                    tb_medname.IsReadOnly = true;
                    tb_description.IsReadOnly = true;
                    tb_quantity.IsReadOnly = true;

                    img_medImg.Source = ByteArrayToImage(d3MedImage[lb_reqmeds.SelectedItem.ToString()]); //ADDED CODE

                }
                else
                {
                    foreach (TextBox detail in EquipInfo)
                    {
                        detail.Focus();
                        break;
                    }


                }
            }
        }

            private void btn1_add_Click(object sender, RoutedEventArgs e)
            {
                if (btn1_add.Content.ToString() == "ADD")
                {

                MessageBoxResult result = MessageBox.Show("Proceed to add equipment?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        lbl_Idnum.Content = "NAME:";

                        btn1_update.IsEnabled = false;
                        btn_ImagLoc.Visibility = Visibility.Visible;
                        tb_imageLoc.Visibility = Visibility.Visible;
                        btn1_increment.IsEnabled = true;
                        btn1_decrement.IsEnabled = true;
                        EquipInfo[0].Text = "";
                        EquipInfo[1].Text = "";
                        EquipInfo[2].Text = "";
                        lb_reqmeds.IsHitTestVisible = false;

                        tb_medname.IsReadOnly = false;
                        tb_description.IsReadOnly = false;
                        tb_quantity.IsReadOnly = true;

                        btn1_add.Content = "CONFIRM";

                    }
                }

                else if (btn1_add.Content.ToString() == "CONFIRM")
                {
                    MessageBoxResult result = MessageBox.Show("CONFIRM?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        if (tb_imageLoc.Text != " ")
                        {


                            btn1_update.IsEnabled = true;
                            btn1_increment.IsEnabled = false;
                            btn1_decrement.IsEnabled = false;
                            globalclass.clinic.W5_MedicineStock(tb_medname.Text, tb_description.Text, Int32.Parse(tb_quantity.Text), ImageToByteArray(tb_imageLoc.Text));
                            EquipInfo[0].Text = "";
                            EquipInfo[1].Text = "";
                            EquipInfo[2].Text = "";
                            btn_ImagLoc.Visibility = Visibility.Hidden;
                            tb_imageLoc.Visibility = Visibility.Hidden;

                            lbl_Idnum.Content = "ID NO.:";
                            lb_reqmeds.IsHitTestVisible = true;
                            btn1_add.Content = "ADD";
                            updateListBoxContent();


                            tb_medname.IsReadOnly = true;
                            tb_description.IsReadOnly = true;
                            tb_quantity.IsReadOnly = true;
                            updateListBoxContent();
                        }
                        else
                        {
                            MessageBox.Show("Please input an image!", "Warning", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }

                    }
                    else
                    {
                        foreach (TextBox detail in EquipInfo)
                        {
                            detail.Focus();
                            break;
                        }
                    }
                }

            }

            private void lb_reqmeds_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                int temp = lb_reqmeds.SelectedIndex;
                string[] keys = d1TransactionList.Keys.ToArray<string>();
                string key = keys[temp];
                int uTypeIndex = 0;
                int count = 0;

                tb_medname.Text = d1TransactionList[key][0];
                tb_description.Text = d1TransactionList[key][1];
                tb_quantity.Text = d1TransactionList[key][2];
                img_medImg.Source = ByteArrayToImage(d3MedImage[lb_reqmeds.SelectedItem.ToString()]); //ADDED CODE


                foreach (KeyValuePair<int, string> kvp in d2TransactionKeyPair)
                {
                    if (kvp.Key == int.Parse(d1TransactionList[key][2]))
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

            public void ClearMe()
            {
                btn1_increment.IsEnabled = false;
                btn1_decrement.IsEnabled = false;
                tb_description.Text = null;
                tb_quantity.Text = null;
                lb_reqmeds.IsHitTestVisible = true;
                btn_ImagLoc.Visibility = Visibility.Hidden;
                tb_imageLoc.Visibility = Visibility.Hidden;
                btn1_update.Visibility = Visibility.Visible;
                btn1_add.Visibility = Visibility.Visible;
                btn1_add.IsEnabled = true;
                btn1_update.IsEnabled = true;
                tb_medname.IsReadOnly = true;
                tb_description.IsReadOnly = true;
                tb_quantity.IsReadOnly = true;

                btn1_add.Content = "ADD";
                btn1_update.Content = "UPDATE";

            }

            private void btnClear_Click(object sender, RoutedEventArgs e)
            {
                updateListBoxContent();
                ClearMe();
            }

            private void btn_ImagLoc_Click(object sender, RoutedEventArgs e) //ADDED CODE
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;*.jfif;";

                if (ofd.ShowDialog() == true)
                {
                    tb_imageLoc.Text = System.IO.Path.GetFullPath(ofd.FileName);
                }
            }


        #region //Main Navigator

        void Names()
        {
            globalclass.idnum = Title.ToString();
            globalclass.username = lbl_staffname.Content.ToString();
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
