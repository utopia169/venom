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
        private void AddTrainClick(object sender, RoutedEventArgs e) {
        CreateTrainPopup.IsOpen = true;
        }

        private void ConfirmAddTrain_Click(object sender, RoutedEventArgs e)
        {
            string newTrainName = TrainNameTextBox.Text;
            if (!string.IsNullOrWhiteSpace(newTrainName))
            {
                var mainWindow = Window.GetWindow(this) as MainWindow;
                if (mainWindow != null)
                    mainWindow.Trains.Add(new TrainCard
                    { Name = newTrainName });
                TrainNameTextBox.Text = string.Empty;
                CreateTrainPopup.IsOpen = false;
            }
            //else {
            //    MessaageBox.Show("fdds");
            //}
        }
    }
}
