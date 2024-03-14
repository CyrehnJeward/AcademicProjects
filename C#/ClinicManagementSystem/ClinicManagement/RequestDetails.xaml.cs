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
    /// Interaction logic for RequestDetails.xaml
    /// </summary>
    public partial class RequestDetails : Window
    {
        //ClinicManagementDBDataContext clinic = new ClinicManagementDBDataContext(Properties.Settings.Default.ClinicMSConnectionString);
        private int quantity = 0;
        bool add = false;
        bool minus = false;
        Login login = new Login();
        public RequestDetails()
        {
            InitializeComponent();
            Equipments();

            //cmb_medsfillup.ItemsSource
        }

        void Equipments()
        {
            //Login login = new Login();
            var equips = globalclass.clinic.uspEquipments();
            foreach (uspEquipmentsResult equip in equips)
                cmb_Equipment.Items.Add(equip.EquipName);

        }

        void addMinusQuantity()
        {
            if (cmb_Equipment.SelectedItem == null)
                tb_medsquantity.Text = "";
            else
            {
                if (add)
                {
                    quantity++;
                    if (quantity > int.Parse(lbl_stock.Content.ToString().Substring(13)))
                        quantity = 0;

                    tb_medsquantity.Text = quantity.ToString();
                }
                if (minus)
                {
                    quantity--;
                    if (quantity < 0)
                        quantity = int.Parse(lbl_stock.Content.ToString().Substring(13));

                    tb_medsquantity.Text = quantity.ToString();
                }
            }
        }

        void quantityTbx()
        {
            if (tb_medsquantity.Text == "")
                addMinusQuantity();
            else
            {
                quantity = int.Parse(tb_medsquantity.Text);
                addMinusQuantity();
            }
        }

        void reset()
        {
            cmb_Equipment.SelectedItem = null;
            cmb_Equipment.Text = "";
            tb_medsquantity.Text = "";
            lbl_stock.Content = "Item Stock : 0";
            lb_reqmeds.Items.Clear();
        }

        BitmapImage ByteArrayToImage(byte[] imgByte)
        {
            Stream stream = new MemoryStream(imgByte);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();
            return image;
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
            add = true;
            minus = false;
            quantityTbx();
        }

        private void btn1_decrement_Click(object sender, RoutedEventArgs e)
        {
            add = false;
            minus = true;
            quantityTbx();
        }


        private void btn1_addreqmeds_Click(object sender, RoutedEventArgs e)
        {
            if (tb_medsquantity.Text == "")
                lbl_note.Visibility = Visibility.Visible;
            else
            {
                string[] names = new string[lb_reqmeds.Items.Count];
                string item = "";
                for (int x = 0; x < names.Length; x++)
                {
                    string partial = lb_reqmeds.Items[x].ToString().Split('|')[0].Substring(0, lb_reqmeds.Items[x].ToString().Split('|')[0].Length - 1);
                    item = partial.Substring(3);
                    names[x] = item;
                }

                if (names.Contains(cmb_Equipment.SelectedItem))
                    MessageBox.Show("That Item already exist", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                else
                {
                    lbl_note.Visibility = Visibility.Hidden;
                    lb_reqmeds.Items.Add(" • " + cmb_Equipment.SelectedItem + " | " + tb_medsquantity.Text);
                    cmb_Equipment.SelectedItem = null;
                    cmb_Equipment.Text = "";
                    tb_medsquantity.Text = "";
                    lbl_stock.Content = "Item Stock : 0";
                }
            }
        }

        private void btn1_removemedreq_Click(object sender, RoutedEventArgs e)
        {
            if (lb_reqmeds.SelectedItem == null)
            {

            }
            else
                lb_reqmeds.Items.Remove(lb_reqmeds.SelectedItem);
        }

        private void btn1_reset_Click(object sender, RoutedEventArgs e)
        {
            reset();
        }

        private void btn1_back_Click(object sender, RoutedEventArgs e)
        {
            if (lb_reqmeds.Items.Count != 0)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to back?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    PatientInfo pi = new PatientInfo();
                    Hide();
                    pi.Show();
                }
            }
            else
            {
                PatientInfo pi = new PatientInfo();
                Hide();
                pi.Show();
            }
        }

        private void btn1_confirm_Click(object sender, RoutedEventArgs e)
        {
            //Login login = new Login();
            PatientInfo pi = new PatientInfo();
            if (lb_reqmeds.Items.Count == 0)
                MessageBox.Show("No Items Present in the Listbox", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                MessageBoxResult result = MessageBox.Show("Submit Request?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    //clinic.W2_DefaultRequest();

                    foreach (object req in lb_reqmeds.Items)
                    {
                        string[] de = req.ToString().Split('|');
                        var equipData = globalclass.clinic.W2_EquipmentStock(de[0].Substring(3));
                        foreach (W2_EquipmentStockResult data in equipData)
                            globalclass.clinic.W2_RequestDetails(data.Equip_ID, int.Parse(de[1].Substring(1)), int.Parse(de[1].Substring(1)));
                    }
                    MessageBox.Show("Your Request has submitted successfully", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    reset();
                    Hide();
                    pi.Show();
                }
            }
        }

        private void cmb_Equipment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Login login = new Login();
            if (cmb_Equipment.SelectedItem == null)
            {

            }
            else
            {
                var equipData = globalclass.clinic.W2_EquipmentStock(cmb_Equipment.SelectedItem.ToString());

                foreach (W2_EquipmentStockResult data in equipData)
                {
                    img_equipImg.Source = ByteArrayToImage(data.Image_Loc.ToArray());
                    lbl_stock.Content = "Item Stock : " + data.Available_Qty;
                }

                tb_medsquantity.Text = "0";
            }
        }
    }
}
    
