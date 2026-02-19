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
        private void AddTrain_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.Trains.Add(new TrainCard
                {
                    Name = $"Train № {mainWindow.Trains.Count + 1}"
                });
            }
        }
        private void UserBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            LoginPopup.IsOpen = true;
        }
    }
}
