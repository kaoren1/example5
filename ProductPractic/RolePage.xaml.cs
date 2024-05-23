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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductPractic
{
    /// <summary>
    /// Логика взаимодействия для RolePage.xaml
    /// </summary>
    public partial class RolePage : Page
    {
        private AdminWindow admin;
        public RolePage(AdminWindow admin)
        {
            InitializeComponent();
            this.admin = admin;
        }

        private void Role_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Role != null && Role.SelectedItem != null)
            {

                Role1 selectedMaterial = Role.SelectedItem as Role1;


                if (selectedMaterial != null)
                {
                    admin.ID = selectedMaterial.ID_Role;
                    admin.Text1.Text = selectedMaterial.Name1;
                }
            }
        }
    }
}
