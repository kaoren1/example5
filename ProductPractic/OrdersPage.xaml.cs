using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductPractic
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        private KasirWindow kasir;
        public OrdersPage(KasirWindow kasir)
        {
            InitializeComponent();
            this.kasir = kasir;
        }

        private void Order_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Order != null && Order.SelectedItem != null)
            {

                DataRowView selectedRow = (DataRowView)Order.SelectedItem;

                
                if (selectedRow != null)
                {
                    kasir.ID = (int)selectedRow["ID_Order"];
                    kasir.Text3.Text = selectedRow["OrderDate"].ToString();
                    kasir.Text4.Text = selectedRow["PriceOrderRUB"].ToString();
                    kasir.Text5.Text = selectedRow["EnterRUB"].ToString();
                    kasir.Text6.Text = selectedRow["ChangeRUB"].ToString();
                }
            }
        }
    }
}
