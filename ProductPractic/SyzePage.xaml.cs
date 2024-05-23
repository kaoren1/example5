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
    /// Логика взаимодействия для SyzePage.xaml
    /// </summary>
    public partial class SyzePage : Page
    {
        private AdminWindow admin;
        public SyzePage(AdminWindow admin)
        {
            InitializeComponent();
            this.admin = admin;
        }

        private void Size_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Size != null && Size.SelectedItem != null)
            {

                Size selectedMaterial = Size.SelectedItem as Size;


                if (selectedMaterial != null)
                {
                    admin.ID = selectedMaterial.ID_Size;
                    admin.Text1.Text = selectedMaterial.SizeName;
                }
            }
        }
    }
}
