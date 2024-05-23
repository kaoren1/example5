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
    /// Логика взаимодействия для ProvidersPage.xaml
    /// </summary>
    public partial class ProvidersPage : Page
    {
        private AdminWindow admin;
        public ProvidersPage(AdminWindow admin)
        {
            InitializeComponent();
            this.admin = admin;
        }

        private void Providers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Providers != null && Providers.SelectedItem != null)
            {

                Providers selectedMaterial = Providers.SelectedItem as Providers;


                if (selectedMaterial != null)
                {
                    admin.ID = selectedMaterial.ID_Provider;
                    admin.Text1.Text = selectedMaterial.ProviderName;
                }
            }
        }
    }
}
