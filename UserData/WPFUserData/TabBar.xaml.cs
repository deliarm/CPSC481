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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFUserData.Model;


namespace WPFUserData
{
    /// <summary>
    /// Interaction logic for TabBar.xaml
    /// </summary>
    public partial class TabBar : UserControl
    {
        public TabBar()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            // slow down animation somehow???
            add_popup.IsOpen = !add_popup.IsOpen;

        }

        private void to_activity(object sender, RoutedEventArgs e)
        {

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // move image up slightly on click??

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch("MainPage.xaml");
        }

        private void FoodButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch("FoodPage.xaml");
        }
        private void ActivityButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch("ActivitiesPage.xaml");
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch("ProfilePage.xaml");
        }
    }
}
