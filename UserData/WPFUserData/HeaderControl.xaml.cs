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
    /// Interaction logic for HeaderControl.xaml
    /// </summary>
    public partial class HeaderControl : UserControl
    {
        public bool BackButtonIsVisible { get; set; } = false;
        public HeaderControl()
        {
            InitializeComponent();
            this.DataContext = this;

            Title = "Default";
        }
        public string Title { get; set; }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

            Switcher.pageSwitcher._NavigationFrame.NavigationService.GoBack();
        }
    }
}
