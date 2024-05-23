using ProductPractic.ProductPractic5DataSetTableAdapters;
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
using System.Windows.Shapes;

namespace ProductPractic
{
    /// <summary>
    /// Логика взаимодействия для KasirWindow.xaml
    /// </summary>
    public partial class KasirWindow : Window
    {
        ProductPractic5Entities pr = new ProductPractic5Entities();

        OrdersTableAdapter OrdersTableAdapter = new OrdersTableAdapter();

        OrderDetailsTableAdapter OrderDetailsTableAdapter =  new OrderDetailsTableAdapter();

        PaymentsTableAdapter paymentsTableAdapter = new PaymentsTableAdapter();

        EmployeeTableAdapter employeeTableAdapter = new EmployeeTableAdapter();

        FurnitureTableAdapter FurnitureTableAdapter = new FurnitureTableAdapter();

        public int ID;
        public KasirWindow()
        {
            InitializeComponent();
            this.Title = "Касир";
            Switch.Items.Add("Заказы");
            Switch.Items.Add("Детали заказов");
        }

        private void Switch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch ((string)Switch.SelectedItem)
            {
                case "Заказы":
                    OrdersPage o = new OrdersPage(this);
                    o.Order.ItemsSource = OrdersTableAdapter.GetDataByAll();
                    Frame.Content = o;

                    Text1.ItemsSource = paymentsTableAdapter.GetData();
                    Text1.DisplayMemberPath = "PaymentName";

                    Text2.ItemsSource = employeeTableAdapter.GetDataE();
                    Text2.DisplayMemberPath = "EmployeeSurname";
                    break;
                case "Детали заказов":
                    OrdersDetailsPage or = new OrdersDetailsPage(this);
                    or.Orders.ItemsSource = OrderDetailsTableAdapter.GetDataByAll();
                    Frame.Content = or;

                    Text1.ItemsSource = FurnitureTableAdapter.GetData();
                    Text1.DisplayMemberPath = "FurnitureName";

                    Text2.ItemsSource = OrdersTableAdapter.GetData();
                    Text2.DisplayMemberPath = "ID_Order";
                    break;
            }
        }

        private void CREATE_Click(object sender, RoutedEventArgs e)
        {

            switch ((string)Switch.SelectedItem)
            {
                case "Заказы":
                    OrdersPage o = new OrdersPage(this);

                    DataRowView selectedRow = (DataRowView)Text1.SelectedItem;
                    int init = Convert.ToInt32(selectedRow["ID_Payment"]);

                    DataRowView selectedRow1 = (DataRowView)Text2.SelectedItem;
                    int init1 = Convert.ToInt32(selectedRow1["ID_Employee"]);

                    OrdersTableAdapter.InsertQuery(init, init1, Text3.Text, Convert.ToInt32(Text4.Text), Convert.ToInt32(Text5.Text), Convert.ToInt32(Text6.Text));
                    o.Order.ItemsSource = OrdersTableAdapter.GetDataByAll();
                    Frame.Content = o;
                    break;
                case "Детали заказов":
                    OrdersDetailsPage or = new OrdersDetailsPage(this);

                    DataRowView selected = (DataRowView)Text1.SelectedItem;
                    int i = Convert.ToInt32(selected["ID_Furniture"]);

                    DataRowView selected1 = (DataRowView)Text2.SelectedItem;
                    int i1 = Convert.ToInt32(selected1["ID_Order"]);

                    OrderDetailsTableAdapter.InsertQuery(i, i1);
                    or.Orders.ItemsSource = OrderDetailsTableAdapter.GetDataByAll();
                    Frame.Content = or;
                    break;
            }
        }



        private void UPDATE_Click(object sender, RoutedEventArgs e)
        {
            switch ((string)Switch.SelectedItem)
            {
                case "Заказы":
                    try
                    {
                        OrdersPage o = new OrdersPage(this);
                        DataRowView selectedRow = (DataRowView)Text1.SelectedItem;
                        int init = Convert.ToInt32(selectedRow["ID_Payment"]);

                        DataRowView selectedRow1 = (DataRowView)Text2.SelectedItem;
                        int init1 = Convert.ToInt32(selectedRow1["ID_Employee"]);

                        OrdersTableAdapter.UpdateQuery(init, init1, Text3.Text, Convert.ToInt32(Text4.Text), Convert.ToInt32(Text5.Text), Convert.ToInt32(Text6.Text), ID);
                        o.Order.ItemsSource = OrdersTableAdapter.GetDataByAll();
                        Frame.Content = o;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка обновления данных из зависимых таблиц");

                    }
                    break;
                case "Детали заказов":
                    try
                    {
                        OrdersDetailsPage o = new OrdersDetailsPage(this); DataRowView selected = (DataRowView)Text1.SelectedItem;
                        int i = Convert.ToInt32(selected["ID_Furniture"]);

                        DataRowView selected1 = (DataRowView)Text2.SelectedItem;
                        int i1 = Convert.ToInt32(selected1["ID_Order"]);

                        OrderDetailsTableAdapter.UpdateQuery(i, i1, ID);
                        o.Orders.ItemsSource = OrderDetailsTableAdapter.GetDataByAll();
                        Frame.Content = o;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка обновления данных из зависимых таблиц");

                    }
                    break;
            }
        }

        private void DELETE_Click(object sender, RoutedEventArgs e)
        {
            switch ((string)Switch.SelectedItem)
            {
                case "Заказы":
                    try
                    {
                        OrdersPage o = new OrdersPage(this);
                        OrdersTableAdapter.DeleteQuery(ID);
                        o.Order.ItemsSource = OrdersTableAdapter.GetDataByAll();
                        Frame.Content = o;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка удаления данных из зависимых таблиц");

                    }
                    break;
                case "Детали заказов":
                    try
                    {
                        OrdersDetailsPage o = new OrdersDetailsPage(this);
                        OrderDetailsTableAdapter.DeleteQuery(ID);
                        o.Orders.ItemsSource = OrderDetailsTableAdapter.GetDataByAll();
                        Frame.Content = o;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка удаления данных из зависимых таблиц");

                    }
                    break;
            }
        }
        private void Text_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string inputText = e.Text;

            if (!string.IsNullOrEmpty(inputText) && !char.IsDigit(inputText[0]))
            {
                e.Handled = true;
            }
        }
        private void Text_PreviewTextInput1(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string inputText = e.Text;

            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c) && c != ':' && c != '.' && c != '/' && c != '-')
                {
                    e.Handled = true;
                    break;
                }
            }
        }
    }
}
