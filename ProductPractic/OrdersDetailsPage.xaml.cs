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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductPractic
{
    /// <summary>
    /// Логика взаимодействия для OrdersDetailsPage.xaml
    /// </summary>
    public partial class OrdersDetailsPage : Page
    {
        private KasirWindow kasir;
        public OrdersDetailsPage(KasirWindow kasir)
        {
            InitializeComponent();
            this.kasir = kasir;
        }

        private void Orders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Orders != null && Orders.SelectedItem != null)
            {

                DataRowView selectedRow = (DataRowView)Orders.SelectedItem;

                if (selectedRow != null)
                {
                    kasir.ID = (int)selectedRow["ID_OrderDetails"];
                }
            }
        }
    }
}
