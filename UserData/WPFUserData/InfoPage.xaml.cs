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
    /// Interaction logic for InfoPage.xaml
    /// </summary>
    public partial class InfoPage : Page
    {
        public InfoPage()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Goal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (goalCombo.SelectedItem.ToString()  == "Maintain"){
                weightGoalPanel.Visibility = Visibility.Collapsed;
            } else  {
                weightGoalPanel.Visibility = Visibility.Visible;

                if (goalCombo.SelectedItem.ToString() == "Lose")
                {
                    weightLabel.Text = "Lose";
                }
                else
                {
                    weightLabel.Text = "Gain";
                } ;
            }
        }
    }
}
