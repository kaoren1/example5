using ProductPractic.ProductPractic5DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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
using System.Windows.Shapes;

namespace ProductPractic
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public int ID;

        Role1TableAdapter role1TableAdapter = new Role1TableAdapter();

        EmployeeTableAdapter employeeTableAdapter = new EmployeeTableAdapter();

        MaterialsTableAdapter MaterialsTableAdapter = new MaterialsTableAdapter();

        ColoursTableAdapter ColoursTableAdapter = new ColoursTableAdapter();

        PaymentsTableAdapter PaymentsTableAdapter = new PaymentsTableAdapter();

        SizeTableAdapter SizeTableAdapter = new SizeTableAdapter();

        ProvidersTableAdapter ProvidersTableAdapter = new ProvidersTableAdapter();

        StylesTableAdapter StylesTableAdapter = new StylesTableAdapter();

        ProductPractic5Entities pr = new ProductPractic5Entities();
        public AdminWindow()
        {
            InitializeComponent();
            this.Title = "Админ";
            Switch.Items.Add("Роли");
            Switch.Items.Add("Работники");
            Switch.Items.Add("Материалы");
            Switch.Items.Add("Стили");
            Switch.Items.Add("Размер");
            Switch.Items.Add("Цвета");
            Switch.Items.Add("Поставщики");
            Switch.Items.Add("Средства оплаты");
        }

        private void Switch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch ((string)Switch.SelectedItem)
            {
                case "Роли":
                    RolePage role = new RolePage(this);
                    role.Role.ItemsSource = pr.Role1.ToList();
                    Frame.Content = role;

                    Reset();
                    Clear(1, 4, true);
                    break;
                case "Работники":
                    EmployeePage employee = new EmployeePage(this);
                    employee.Employee.ItemsSource = employeeTableAdapter.GetDataE();
                    Frame.Content = employee;

                    Text6.ItemsSource = role1TableAdapter.GetData();
                    Text6.DisplayMemberPath = "Name1";

                    Reset();
                    Clear(5, 0, false);
                    break;
                case "Материалы":
                    MaterialsPage materials = new MaterialsPage(this);
                    materials.Material.ItemsSource = pr.Materials.ToList();
                    Frame.Content = materials;

                    Reset();
                    Clear(1, 4, true);
                    break;
                case "Стили":
                    StylesPage styles = new StylesPage(this);
                    styles.Style.ItemsSource = pr.Styles.ToList();
                    Frame.Content = styles;

                    Reset();
                    Clear(1, 4, true);
                    break;
                case "Размер":
                    SyzePage syze = new SyzePage(this);
                    syze.Size.ItemsSource = pr.Size.ToList();
                    Frame.Content = syze;

                    Reset();
                    Clear(1, 4, true);
                    break;
                case "Цвета":
                    ColoursPage colours = new ColoursPage(this);
                    colours.Colour.ItemsSource = pr.Colours.ToList();
                    Frame.Content = colours;

                    Reset();
                    Clear(1, 4, true);
                    break;
                case "Поставщики":
                    ProvidersPage providers = new ProvidersPage(this);
                    providers.Providers.ItemsSource = pr.Providers.ToList();
                    Frame.Content = providers;

                    Reset();
                    Clear(1, 4, true);
                    break;
                case "Средства оплаты":
                    PaymentsPage payments = new PaymentsPage(this);
                    payments.Payments.ItemsSource = pr.Payments.ToList();
                    Frame.Content = payments;

                    Reset();
                    Clear(1, 4, true);
                    break;
            }
        }

        private void Reset()
        {

            if (GridRight.Children.Contains(Text1) == false)
            {
                GridRight.Children.Insert(1, Text1);
            }

            if (GridRight.Children.Contains(Text2) == false)
            {
                GridRight.Children.Insert(2, Text2);
            }

            if (GridRight.Children.Contains(Text3) == false)
            {
                GridRight.Children.Insert(3, Text3);
            }

            if (GridRight.Children.Contains(Text4) == false)
            {
                GridRight.Children.Insert(4, Text4);
            }

            if (GridRight.Children.Contains(Text5) == false)
            {
                GridRight.Children.Insert(5, Text5);
            }

            if (GridRight.Children.Contains(Text6) == false)
            {
                GridRight.Children.Insert(6, Text6);
            }

        }

        private void Clear(int textBoxToClearCount, int textBoxToRemoveCount, bool removeComboBox)
        {
            Panel panel = GridRight;
            List<TextBox> textBoxes = panel.Children.OfType<TextBox>().ToList();

            int textBoxIndex = panel.Children.IndexOf(textBoxes.First());

            for (int i = 0; i < textBoxToClearCount && i < textBoxes.Count; i++)
            {
                textBoxes[i].Text = "";
            }

            for (int i = 0; i < textBoxToRemoveCount && i + textBoxToClearCount < textBoxes.Count; i++)
            {
                panel.Children.Remove(textBoxes[i + textBoxToClearCount]);
            }

            if (removeComboBox)
            {
                List<ComboBox> comboBoxes = panel.Children.OfType<ComboBox>().ToList();
                if (comboBoxes.Any())
                {
                    panel.Children.Remove(comboBoxes.First());
                }
            }
            else
            {
                List<ComboBox> comboBoxes = panel.Children.OfType<ComboBox>().ToList();
                if (comboBoxes.Any())
                {
                    int comboBoxIndex = panel.Children.IndexOf(comboBoxes.First());
                    panel.Children.RemoveAt(comboBoxIndex);
                    panel.Children.Insert(comboBoxIndex - 1, comboBoxes.First());
                    comboBoxes.First().SelectedIndex = -1;
                }
            }
        }

        private void CREATE_Click(object sender, RoutedEventArgs e)
        {

            switch ((string)Switch.SelectedItem)
            {
                case "Роли":
                    RolePage role = new RolePage(this);
                    role.Role.ItemsSource = pr.Role1.ToList();
                    Frame.Content = role;

                    Role1 r = new Role1()
                    {
                        Name1 = Text1.Text
                    };
                    pr.Role1.Add(r);
                    pr.SaveChanges();
                    role.Role.ItemsSource = pr.Role1.ToList();
                    break;
                case "Работники":
                    EmployeePage employee = new EmployeePage(this);
                    employee.Employee.ItemsSource = pr.Employee.ToList();
                    Frame.Content = employee;

                    DataRowView selected = (DataRowView)Text6.SelectedItem;
                    int i = Convert.ToInt32(selected["ID_Role"]);

                    employeeTableAdapter.InsertQuery(Text1.Text, HashPassword(Text2.Text), Text3.Text, Text4.Text, Text5.Text, i);

                    employee.Employee.ItemsSource = employeeTableAdapter.GetDataE();
                    Frame.Content = employee;

                    break;
                case "Материалы":
                    MaterialsPage materials = new MaterialsPage(this);
                    materials.Material.ItemsSource = pr.Materials.ToList();
                    Frame.Content = materials;

                    Materials mat = new Materials()
                    {
                        MaterialName = Text1.Text
                    };
                    pr.Materials.Add(mat);
                    pr.SaveChanges();
                    materials.Material.ItemsSource = pr.Materials.ToList();

                    break;
                case "Стили":
                    StylesPage styles = new StylesPage(this);
                    styles.Style.ItemsSource = pr.Styles.ToList();
                    Frame.Content = styles;

                    Styles st = new Styles()
                    {
                        StyleName = Text1.Text
                    };
                    pr.Styles.Add(st);
                    pr.SaveChanges();
                    styles.Style.ItemsSource = pr.Styles.ToList();

                    break;
                case "Размер":
                    SyzePage syze = new SyzePage(this);
                    syze.Size.ItemsSource = pr.Size.ToList();
                    Frame.Content = syze;

                    Size sz = new Size()
                    {
                        SizeName = Text1.Text
                    };
                    pr.Size.Add(sz);
                    pr.SaveChanges();
                    syze.Size.ItemsSource = pr.Size.ToList();

                    break;
                case "Цвета":
                    ColoursPage colours = new ColoursPage(this);
                    colours.Colour.ItemsSource = pr.Colours.ToList();
                    Frame.Content = colours;

                    Colours cs = new Colours()
                    {
                        ColourName = Text1.Text
                    };
                    pr.Colours.Add(cs);
                    pr.SaveChanges();
                    colours.Colour.ItemsSource = pr.Colours.ToList();

                    break;
                case "Поставщики":
                    ProvidersPage providers = new ProvidersPage(this);
                    providers.Providers.ItemsSource = pr.Providers.ToList();
                    Frame.Content = providers;

                    Providers pre = new Providers()
                    {
                        ProviderName = Text1.Text
                    };
                    pr.Providers.Add(pre);
                    pr.SaveChanges();
                    providers.Providers.ItemsSource = pr.Providers.ToList();

                    break;
                case "Средства оплаты":
                    PaymentsPage payments = new PaymentsPage(this);
                    payments.Payments.ItemsSource = pr.Payments.ToList();
                    Frame.Content = payments;

                    Payments pay = new Payments()
                    {
                        PaymentName = Text1.Text
                    };
                    pr.Payments.Add(pay);
                    pr.SaveChanges();
                    payments.Payments.ItemsSource = pr.Payments.ToList();
                    break;
            }
        }



        private void UPDATE_Click(object sender, RoutedEventArgs e)
        {
            switch ((string)Switch.SelectedItem)
            {
                case "Роли":
                    RolePage role = new RolePage(this);
                    role.Role.ItemsSource = pr.Role1.ToList();
                    Frame.Content = role;

                    try
                    {
                        role1TableAdapter.UpdateQuery(Text1.Text,ID);

                        role.Role.ItemsSource = role1TableAdapter.GetData();
                        Frame.Content = role;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка обновления данных из зависимых таблиц");
                    }
                    break;
                case "Работники":
                    EmployeePage employee = new EmployeePage(this);
                    employee.Employee.ItemsSource = pr.Employee.ToList();
                    Frame.Content = employee;

                    try
                    {
                        DataRowView selected = (DataRowView)Text6.SelectedItem;
                        int i = Convert.ToInt32(selected["ID_Role"]);

                        employeeTableAdapter.UpdateQuery(Text1.Text, HashPassword(Text2.Text), Text3.Text, Text4.Text, Text5.Text, i, ID);

                        employee.Employee.ItemsSource = employeeTableAdapter.GetDataE();
                        Frame.Content = employee;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка обновления данных из зависимых таблиц");
                    }
                    break;
                case "Материалы":
                    MaterialsPage materials = new MaterialsPage(this);
                    materials.Material.ItemsSource = pr.Materials.ToList();
                    Frame.Content = materials;

                    try
                    {
                        MaterialsTableAdapter.UpdateQuery(Text1.Text, ID);

                        materials.Material.ItemsSource = MaterialsTableAdapter.GetData();
                        Frame.Content = materials;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка обновления данных из зависимых таблиц");
                    }
                    break;

                case "Стили":
                    StylesPage styles = new StylesPage(this);
                    styles.Style.ItemsSource = pr.Styles.ToList();
                    Frame.Content = styles;

                    try
                    {
                        StylesTableAdapter.UpdateQuery(Text1.Text, ID);

                        styles.Style.ItemsSource = StylesTableAdapter.GetData();
                        Frame.Content = styles;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка обновления данных из зависимых таблиц");
                    }
                    break;
                case "Размер":
                    SyzePage syze = new SyzePage(this);
                    syze.Size.ItemsSource = SizeTableAdapter.GetData();
                    Frame.Content = syze;

                    try
                    {
                        SizeTableAdapter.UpdateQuery(Text1.Text, ID);

                        syze.Size.ItemsSource = SizeTableAdapter.GetData();
                        Frame.Content = syze;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка обновления данных из зависимых таблиц");
                    }
                    break;
                case "Цвета":
                    ColoursPage colours = new ColoursPage(this);
                    colours.Colour.ItemsSource = pr.Colours.ToList();
                    Frame.Content = colours;

                    try
                    {
                        ColoursTableAdapter.UpdateQuery(Text1.Text, ID);

                        colours.Colour.ItemsSource = ColoursTableAdapter.GetData();
                        Frame.Content = colours;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка обновления данных из зависимых таблиц");
                    }
                    break;
                case "Поставщики":
                    ProvidersPage providers = new ProvidersPage(this);
                    providers.Providers.ItemsSource = pr.Providers.ToList();
                    Frame.Content = providers;

                    try
                    {
                        ProvidersTableAdapter.UpdateQuery(Text1.Text, ID);

                        providers.Providers.ItemsSource = ProvidersTableAdapter.GetData();
                        Frame.Content = providers;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка обновления данных из зависимых таблиц");
                    }
                    break;
                case "Средства оплаты":
                    PaymentsPage payments = new PaymentsPage(this);
                    payments.Payments.ItemsSource = pr.Payments.ToList();
                    Frame.Content = payments;

                    try
                    {
                        PaymentsTableAdapter.UpdateQuery(Text1.Text, ID);

                        payments.Payments.ItemsSource = PaymentsTableAdapter.GetData();
                        Frame.Content = payments;
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
                case "Роли":
                    RolePage role = new RolePage(this);
                    role.Role.ItemsSource = pr.Role1.ToList();
                    Frame.Content = role;

                    try
                    {
                        role1TableAdapter.DeleteQuery(ID);

                        role.Role.ItemsSource = role1TableAdapter.GetData();
                        Frame.Content = role;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка удаления данных из зависимых таблиц");
                    }
                    break;
                case "Работники":
                    try
                    {
                        EmployeePage employee = new EmployeePage(this);
                        employee.Employee.ItemsSource = pr.Employee.ToList();
                        Frame.Content = employee;

                        employeeTableAdapter.DeleteQuery(ID);

                        employee.Employee.ItemsSource = employeeTableAdapter.GetDataE();
                        Frame.Content = employee;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка удаления данных из зависимых таблиц");

                    }
                    break;
                case "Материалы":
                    MaterialsPage materials = new MaterialsPage(this);
                    materials.Material.ItemsSource = pr.Materials.ToList();
                    Frame.Content = materials;

                    try
                    {
                        MaterialsTableAdapter.DeleteQuery(ID);

                        materials.Material.ItemsSource = MaterialsTableAdapter.GetData();
                        Frame.Content = materials;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка удаления данных из зависимых таблиц");
                    }
                    break;

                case "Стили":
                    StylesPage styles = new StylesPage(this);
                    styles.Style.ItemsSource = pr.Styles.ToList();
                    Frame.Content = styles;

                    try
                    {
                        StylesTableAdapter.DeleteQuery(ID);

                        styles.Style.ItemsSource = StylesTableAdapter.GetData();
                        Frame.Content = styles;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка удаления данных из зависимых таблиц");
                    }
                    break;
                case "Размер":
                    SyzePage syze = new SyzePage(this);
                    syze.Size.ItemsSource = pr.Size.ToList();
                    Frame.Content = syze;

                    try
                    {
                        SizeTableAdapter.DeleteQuery(ID);

                        syze.Size.ItemsSource = SizeTableAdapter.GetData();
                        Frame.Content = syze;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка удаления данных из зависимых таблиц");
                    }
                    break;
                case "Цвета":
                    ColoursPage colours = new ColoursPage(this);
                    colours.Colour.ItemsSource = pr.Colours.ToList();
                    Frame.Content = colours;

                    try
                    {
                        ColoursTableAdapter.DeleteQuery(ID);

                        colours.Colour.ItemsSource = ColoursTableAdapter.GetData();
                        Frame.Content = colours;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка удаления данных из зависимых таблиц");
                    }
                    break;
                case "Поставщики":
                    ProvidersPage providers = new ProvidersPage(this);
                    providers.Providers.ItemsSource = pr.Providers.ToList();
                    Frame.Content = providers;

                    try
                    {
                        ProvidersTableAdapter.DeleteQuery(ID);

                        providers.Providers.ItemsSource = ProvidersTableAdapter.GetData();
                        Frame.Content = providers;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка удаления данных из зависимых таблиц");
                    }
                    break;
                case "Средства оплаты":
                    PaymentsPage payments = new PaymentsPage(this);
                    payments.Payments.ItemsSource = pr.Payments.ToList();
                    Frame.Content = payments;

                    try
                    {
                        PaymentsTableAdapter.DeleteQuery(ID);

                        payments.Payments.ItemsSource = PaymentsTableAdapter.GetData();
                        Frame.Content = payments;
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

            switch ((string)Switch.SelectedItem)
            {
                case "Роли":
                    if (!string.IsNullOrEmpty(inputText) && !char.IsLetter(inputText[0]) && textBox.Name == "Text1")
                    {
                        e.Handled = true;
                    }
                    break;
                case "Работники":
                    if (!string.IsNullOrEmpty(inputText) && !char.IsLetter(inputText[0]) && (textBox.Name == "Text1" || textBox.Name == "Text2" || textBox.Name == "Text3" || textBox.Name == "Text4" || textBox.Name == "Text5"))
                    {
                        e.Handled = true;
                    }
                    break;
                case "Материалы":
                    if (!string.IsNullOrEmpty(inputText) && !char.IsLetter(inputText[0]) && textBox.Name == "Text1")
                    {
                        e.Handled = true;
                    }
                    break;
                case "Стили":
                    if (!string.IsNullOrEmpty(inputText) && !char.IsLetter(inputText[0]) && textBox.Name == "Text1")
                    {
                        e.Handled = true;
                    }
                    break;
                case "Размер":
                    if (!string.IsNullOrEmpty(inputText) && !char.IsLetter(inputText[0]) && textBox.Name == "Text1")
                    {
                        e.Handled = true;
                    }
                    break;
                case "Цвета":
                    if (!string.IsNullOrEmpty(inputText) && !char.IsLetter(inputText[0]) && textBox.Name == "Text1")
                    {
                        e.Handled = true;
                    }
                    break;
                case "Поставщики":
                    if (!string.IsNullOrEmpty(inputText) && !char.IsLetter(inputText[0]) && textBox.Name == "Text1")
                    {
                        e.Handled = true;
                    }
                    break;
                case "Средства оплаты":
                    if (!string.IsNullOrEmpty(inputText) && !char.IsLetter(inputText[0]) && textBox.Name == "Text1")
                    {
                        e.Handled = true;
                    }
                    break;
            }
        }
        private void Text2_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if ((string)Switch.SelectedItem == "Работники")
            {
                string maskedText = "";
                foreach (char c in Text2.Text)
                {
                    maskedText += "•";
                }

                Text2.Text = maskedText;
            }
        }
        private void Import_Click(object sender, RoutedEventArgs e)
        {

        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
