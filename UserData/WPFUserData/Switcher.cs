using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WPFUserData
{

    public static class Switcher
    {
        public static MainWindow pageSwitcher;

        public static void Switch(String newPageUrl)
        {
            pageSwitcher._NavigationFrame.NavigationService.Navigate(new Uri(newPageUrl, UriKind.Relative));
        }
    }
}
