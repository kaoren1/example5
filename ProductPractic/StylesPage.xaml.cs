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
    /// Логика взаимодействия для StylesPage.xaml
    /// </summary>
    public partial class StylesPage : Page
    {
        private AdminWindow admin;
        public StylesPage(AdminWindow admin)
        {
            InitializeComponent();
            this.admin = admin;
        }

        private void Style_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Style != null && Style.SelectedItem != null)
            {

                Styles selectedMaterial = Style.SelectedItem as Styles;


                if (selectedMaterial != null)
                {
                    admin.ID = selectedMaterial.ID_Style;
                    admin.Text1.Text = selectedMaterial.StyleName;
                }
            }
        }
    }
}
