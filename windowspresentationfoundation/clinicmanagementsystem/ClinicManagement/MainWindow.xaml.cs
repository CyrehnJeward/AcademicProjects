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

namespace Clinic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Close application?", "Close", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Environment.Exit(0);
            else
                e.Cancel = true;
        }

        private void btn1_request_Click(object sender, RoutedEventArgs e)
        {
            RequestLists rl = new RequestLists();
            Hide();
            rl.Show();
            rl.Title = "RequestList: User : " + Title.Substring(17);
        }

        private void btn1_medicine_Click(object sender, RoutedEventArgs e)
        {
            MedicineInventory mi = new MedicineInventory();
            Hide();
            mi.Show();
        }

        private void btn1_equipments_Click(object sender, RoutedEventArgs e)
        {
            EquipmentInventory ei = new EquipmentInventory();
            Hide();
            ei.Show();
        }

        private void btn1_records_Click(object sender, RoutedEventArgs e)
        {
            RequestHistory rh = new RequestHistory();
            Hide();
            rh.Show();
        }

        private void btn1_staff_Click(object sender, RoutedEventArgs e)
        {
            ListOfStaff staff = new ListOfStaff();
            Hide();
            staff.Show();
        }

        private void btn1_logout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            Hide();
            login.Show();
        }
    }
}