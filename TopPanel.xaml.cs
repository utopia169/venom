using System.Windows;
using System.Windows.Controls;

namespace MyApp
{
    public partial class TopPanel : UserControl
    {
        public TopPanel()
        {
            InitializeComponent();
        }

        private void UserBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            LoginPopup.IsOpen = true;
        }
    }
}
