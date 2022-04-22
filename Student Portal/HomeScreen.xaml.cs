using Student_Portal.ViewModels;
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
using System.Windows.Shapes;

namespace Student_Portal
{
    /// <summary>
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : Window
    {
        public HomeScreen()
        {
            InitializeComponent();
        }

        private void UpdateAdminBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AdminAccontViewModel();
            SelectedItemLbl.Content = "Admin Personal Details";
        }

        private void CreateUserBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new CreateUserAccountViewModel();
        }

        private void ContentControl_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
    }
}
