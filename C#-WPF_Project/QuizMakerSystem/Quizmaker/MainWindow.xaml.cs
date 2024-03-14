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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Finals_Machine_Problem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataClassesDataContext DCCDDC = new DataClassesDataContext(Properties.Settings.Default.BT3MP1_TrialConnectionString);
        string username;
        string password;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            username = txtUsername.Text;
            password = txtPassword.Text;
            var users = DCCDDC.uspLoginUser(Int32.Parse(username), password);
            foreach (uspLoginUserResult ulr in users)
            {
                if (ulr.UserID == Int32.Parse(username) && ulr.UserPassword == password)
                {
                    if (ulr.UserTypeID == 1)
                    {
                        MessageBox.Show("Welcome Teacher", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        WindowPage1 a = new WindowPage1();
                        a.Show();
                        this.Close();
                        
                    }
                    else if (ulr.UserTypeID == 2)
                    {
                        MessageBox.Show("Welcome Student","Information",MessageBoxButton.OK,MessageBoxImage.Information);
                        Quiz_Number a = new Quiz_Number();
                        a.Show();
                        this.Close(); 
                    }
                }
                else
                {
                    MessageBox.Show(".");
                }

            }


        }
    }
}
