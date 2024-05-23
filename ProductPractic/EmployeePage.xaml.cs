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
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        private AdminWindow admin;
        public EmployeePage(AdminWindow admin)
        {
            InitializeComponent();
            this.admin = admin;
        }

        private void Employee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Employee != null && Employee.SelectedItem != null)
            {

                DataRowView selectedRow = (DataRowView)Employee.SelectedItem;


                if (selectedRow != null)
                {
                    admin.ID = (int)selectedRow["ID_Employee"];
                    admin.Text1.Text = selectedRow["Login1"].ToString();
                    admin.Text2.Text = selectedRow["Password1"].ToString();
                    admin.Text3.Text = selectedRow["EmployeeSurname"].ToString();
                    admin.Text4.Text = selectedRow["EmployeeName"].ToString();
                    admin.Text5.Text = selectedRow["EmployeeMiddleName"].ToString();
                }
            }
        }
    }
}
