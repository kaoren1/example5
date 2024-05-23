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
    /// Логика взаимодействия для MaterialsPage.xaml
    /// </summary>
    public partial class MaterialsPage : Page   
    {
        private AdminWindow admin;

        public MaterialsPage(AdminWindow adminWindow)
        {
            InitializeComponent();
            this.admin = adminWindow;
        }

        private void Material_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Material != null && Material.SelectedItem != null)
            {

                Materials selectedMaterial = Material.SelectedItem as Materials;


                if (selectedMaterial != null)
                {
                    admin.ID = selectedMaterial.ID_Material;
                    admin.Text1.Text = selectedMaterial.MaterialName;
                }
            }
        }


    }
}
