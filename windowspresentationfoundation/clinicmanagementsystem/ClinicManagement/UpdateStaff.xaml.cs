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
    /// Interaction logic for UpdateStaff.xaml
    /// </summary>
    public partial class UpdateStaff : Window
    {
        bool mask = true;
        Dictionary<string, string[]> d1TransactionList = new Dictionary<string, string[]>();
        Dictionary<int, string> d2TransactionKeyPair = new Dictionary<int, string>();
        Dictionary<string, byte[]> d3MedImage = new Dictionary<string, byte[]>();
        int UserID = 0;
        public UpdateStaff()
        {
            InitializeComponent();
            staff();
            //MessageBox.Show("" + globalclass.staffID);
            mask = !(bool)pShowHide.IsChecked;
            if (mask)
                tb_password.IsEnabled = false;
            else
                Passwordmasked.IsEnabled = false;
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

        void staff()
        {
            var staffer = (from s in globalclass.clinic.vStaffInfos select s);
            foreach (vStaffInfo st in staffer)
            {
                if (st.Username == globalclass.staffID)
                {
                    
                    image_staff.Source = ByteArrayToImage(st.Photo_Loc.ToArray());
                    UserID = int.Parse(st.User_ID.ToString());
                    tb_studentid.Text = st.Staff_ID.ToString();
                    tb_FN.Text = st.FirstName;
                    tb_LN.Text = st.LastName;
                    tb_Age.Text = st.Age.ToString();
                    tb_Email.Text = st.Email;
                    tb_username.Text = st.Username;
                    tb_password.Text = st.Password;
                }
            }
        }

        private void btn1_update_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Confirm update?", "", MessageBoxButton.YesNo, MessageBoxImage.Information);

            if (result == MessageBoxResult.Yes)
            {
                globalclass.clinic.W8_StaffInformation(UserID, tb_FN.Text, tb_LN.Text, tb_password.Text);
                MessageBox.Show("Update complete!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void tb_password_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (!mask)
                Passwordmasked.Password = tb_password.Text;
        }

        private void Passwordmasked_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (mask)
                tb_password.Text = Passwordmasked.Password;
        }
        private void pShowHide_Checked(object sender, RoutedEventArgs e)
        {
            mask = !mask;
            tb_password.IsEnabled = true;
            tb_password.Visibility = Visibility.Visible;
            Passwordmasked.IsEnabled = false;
            Passwordmasked.Visibility = Visibility.Hidden;
            tb_password.Focus();
        }

        private void pShowHide_Unchecked(object sender, RoutedEventArgs e)
        {
            mask = !mask;
            tb_password.IsEnabled = false;
            tb_password.Visibility = Visibility.Hidden;
            Passwordmasked.IsEnabled = true;
            Passwordmasked.Visibility = Visibility.Visible;
            Passwordmasked.Focus();
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
            RequestHistory rh = new RequestHistory();
            Hide();
            rh.Show();
            rh.Title = globalclass.idnum;
            rh.lbl_staffname.Content = globalclass.username;
            rh.img_staff.Source = ByteArrayToImage(globalclass.imageloc);
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
