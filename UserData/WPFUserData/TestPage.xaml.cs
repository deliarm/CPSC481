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

namespace WPFUserData
{
    /// <summary>
    /// Interaction logic for TestPage.xaml
    /// </summary>
    /// https://docs.microsoft.com/en-us/dotnet/desktop/wpf/app-development/navigation-overview?view=netframeworkdesktop-4.8
    public partial class TestPage : Page
    {
        public TestPage()
        {
            InitializeComponent();

            // Can only access the NavigationService when the page has been loaded
            this.Loaded += new RoutedEventHandler(CancelNavigationPage_Loaded);
            this.Unloaded += new RoutedEventHandler(CancelNavigationPage_Unloaded);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch("AddMealPage.xaml");
        }

        void CancelNavigationPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigating += new NavigatingCancelEventHandler(NavigationService_Navigating);
        }

        void CancelNavigationPage_Unloaded(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigating -= new NavigatingCancelEventHandler(NavigationService_Navigating);
        }

        void NavigationService_Navigating(object sender, NavigatingCancelEventArgs e)
        {

        }
  
    }
}
