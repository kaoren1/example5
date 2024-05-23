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
    /// Логика взаимодействия для ColoursPage.xaml
    /// </summary>
    public partial class ColoursPage : Page
    {
        private AdminWindow admin;
        public ColoursPage(AdminWindow admin)
        {
            InitializeComponent();
            this.admin = admin;
        }

        private void Colour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Colour != null && Colour.SelectedItem != null)
            {

                Colours selectedMaterial = Colour.SelectedItem as Colours;


                if (selectedMaterial != null)
                {
                    admin.ID = selectedMaterial.ID_Colour;
                    admin.Text1.Text = selectedMaterial.ColourName;
                }
            }
        }
    }
}
