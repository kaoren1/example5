using ProductPractic.ProductPractic5DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
    /// Логика взаимодействия для StoreWindow.xaml
    /// </summary>
    public partial class StoreWindow : Window
    {
        ProductPractic5Entities pr = new ProductPractic5Entities();

        MaterialsTableAdapter MaterialsTableAdapter = new MaterialsTableAdapter();

        StylesTableAdapter StylesTableAdapter = new StylesTableAdapter();
        
        SizeTableAdapter SizeTableAdapter = new SizeTableAdapter();

        ColoursTableAdapter ColoursTableAdapter = new ColoursTableAdapter();

        ProvidersTableAdapter ProvidersTableAdapter = new ProvidersTableAdapter();

        FurnitureTableAdapter FurnitureTableAdapter = new FurnitureTableAdapter();

        public int ID;
        public StoreWindow()
        {
            InitializeComponent();
            this.Title = "Склад";

            Text4.ItemsSource = MaterialsTableAdapter.GetData();
            Text4.DisplayMemberPath = "MaterialName";

            Text5.ItemsSource = StylesTableAdapter.GetData();
            Text5.DisplayMemberPath = "StyleName";

            Text6.ItemsSource = SizeTableAdapter.GetData();
            Text6.DisplayMemberPath = "SizeName";

            Text7.ItemsSource = ColoursTableAdapter.GetData();
            Text7.DisplayMemberPath = "ColourName";

            Text8.ItemsSource = ProvidersTableAdapter.GetData();
            Text8.DisplayMemberPath = "ProviderName";

            Store.ItemsSource = FurnitureTableAdapter.GetDataByF();
        }
        private void CREATE_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)Text4.SelectedItem;
            int init = Convert.ToInt32(selectedRow["ID_Material"]);

            DataRowView selectedRow1 = (DataRowView)Text5.SelectedItem;
            int init1 = Convert.ToInt32(selectedRow1["ID_Style"]);

            DataRowView selectedRow2 = (DataRowView)Text6.SelectedItem;
            int init2 = Convert.ToInt32(selectedRow2["ID_Size"]);

            DataRowView selectedRow3 = (DataRowView)Text7.SelectedItem;
            int init3 = Convert.ToInt32(selectedRow3["ID_Colour"]);

            DataRowView selectedRow4 = (DataRowView)Text8.SelectedItem;
            int init4 = Convert.ToInt32(selectedRow4["ID_Provider"]);

            FurnitureTableAdapter.InsertQuery(Text1.Text, Convert.ToInt32(Text2.Text), Convert.ToDouble(Text3.Text), init, init1, init2, init3, init4);

            Store.ItemsSource = FurnitureTableAdapter.GetDataByF();
        }

        private void UPDATE_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)Text4.SelectedItem;
            int init = Convert.ToInt32(selectedRow["ID_Material"]);

            DataRowView selectedRow1 = (DataRowView)Text5.SelectedItem;
            int init1 = Convert.ToInt32(selectedRow1["ID_Style"]);

            DataRowView selectedRow2 = (DataRowView)Text6.SelectedItem;
            int init2 = Convert.ToInt32(selectedRow2["ID_Size"]);

            DataRowView selectedRow3 = (DataRowView)Text7.SelectedItem;
            int init3 = Convert.ToInt32(selectedRow3["ID_Colour"]);

            DataRowView selectedRow4 = (DataRowView)Text8.SelectedItem;
            int init4 = Convert.ToInt32(selectedRow4["ID_Provider"]);

            FurnitureTableAdapter.UpdateQuery(Text1.Text, Convert.ToInt32(Text2.Text), Convert.ToDouble(Text3.Text), init, init1, init2, init3, init4, ID);

            Store.ItemsSource = FurnitureTableAdapter.GetDataByF();
        }

        private void DELETE_Click(object sender, RoutedEventArgs e)
        {
            FurnitureTableAdapter.DeleteQuery(ID);
            Store.ItemsSource = FurnitureTableAdapter.GetDataByF();
        }
        private void Text_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string inputText = e.Text;

            if (!string.IsNullOrEmpty(inputText) && !char.IsDigit(inputText[0]) && (textBox.Name == "Text2" || textBox.Name == "Text3"))
            {
                e.Handled = true;
            }
        }

        private void Store_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Store != null && Store.SelectedItem != null)
            {
                DataRowView row = (DataRowView)Store.SelectedItem;

                ID = (int)row["ID_Furniture"];
                Text1.Text = "";
                Text1.Text = row["FurnitureName"].ToString();
                Text2.Text = "";
                Text2.Text = row["AmountStore"].ToString();
                Text3.Text = "";
                Text3.Text = row["PriceInRUB"].ToString();
            }
        }
    }
}
