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
    /// Interaction logic for Login.xaml
    /// </summary>
    
    public partial class Login : Window
    {
       
        bool mask = true;
        public Login()
        {
            InitializeComponent();
            mask = !(bool)pShowHide.IsChecked;
            if (mask)
                tb_Password.IsEnabled = false;
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

        void login()
        {
            bool flac = true;
            if (tb_Username.Text == "")
            {
                MessageBox.Show("Please enter username", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                tb_Username.Focus();
                tb_Password.Text = "";
            }
            else if (tb_Username.Text != "" && tb_Password.Text == "")
            {
                MessageBox.Show("Please enter password", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                tb_Password.Focus();
            }
            else if (tb_Username.Text != "" && tb_Password.Text != "")
            {
                RequestLists mn = new RequestLists();

                var user = globalclass.clinic.W1_Login(tb_Username.Text, tb_Password.Text);

                foreach (W1_LoginResult detail in user)
                {
                    if (tb_Username.Text == detail.Username && tb_Password.Text == detail.Password)
                    {
                        MessageBox.Show("Welcome user " + detail.Username, "", MessageBoxButton.OK, MessageBoxImage.Information);
                        globalclass.staffID = tb_Username.Text;
                        Hide();
                        mn.Show();
                        mn.Title = "USER ID : " + detail.Username;


                        var a = globalclass.clinic.W1_StaffDetails(detail.User_ID);

                        foreach (W1_StaffDetailsResult b in a)
                        {
                            globalclass.imageloc = b.Photo_Loc.ToArray();
                            mn.lbl_staffname.Content = "MR. " + b.LastName.ToUpper();
                            mn.img_staff.Source = ByteArrayToImage(globalclass.imageloc); //ADDED CODE
                        }
                        flac = false;
                    }
                }
                if (flac)
                {
                    MessageBox.Show("User does not exist", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                    tb_Username.Text = "";
                    tb_Password.Text = "";
                    tb_Username.Focus();
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

        private void btn1_login_Click(object sender, RoutedEventArgs e)
        {
            login();
        }

        private void btn1_studentlogin_Click(object sender, RoutedEventArgs e)
        {
            PatientInfo pi = new PatientInfo();

            if (MessageBox.Show("Do you want to proceed as a Patient/Student?", "Verification", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                MessageBox.Show("Welcome Patient/Student", "Welcome", MessageBoxButton.OK, MessageBoxImage.Information);
                Hide();
                pi.Show();
            }
        }

        private void tb_Username_TextChanged(object sender, TextChangedEventArgs e)
        {
            int username = 0;
            if (int.TryParse(tb_Username.Text, out username))
                lbl_note.Visibility = Visibility.Hidden;
            else
            {
                lbl_note.Visibility = Visibility.Visible;
                tb_Username.Text = "";
            }
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                login();
        }

        private void tb_Password_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (!mask)
                Passwordmasked.Password = tb_Password.Text;
        }

        private void Passwordmasked_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (mask)
                tb_Password.Text = Passwordmasked.Password;
        }

        private void pShowHide_Checked(object sender, RoutedEventArgs e)
        {
            mask = !mask;
            tb_Password.IsEnabled = true;
            tb_Password.Visibility = Visibility.Visible;
            Passwordmasked.IsEnabled = false;
            Passwordmasked.Visibility = Visibility.Hidden;
            tb_Password.Focus();
        }

        private void pShowHide_Unchecked(object sender, RoutedEventArgs e)
        {
            mask = !mask;
            tb_Password.IsEnabled = false;
            tb_Password.Visibility = Visibility.Hidden;
            Passwordmasked.IsEnabled = true;
            Passwordmasked.Visibility = Visibility.Visible;
            Passwordmasked.Focus();
        }
    }
}