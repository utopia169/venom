using System.Windows;
using System.Windows.Controls;

namespace MyApp
{
    public partial class Content : UserControl
    {
        public Content()
        {
            InitializeComponent();
        }

        private void DeleteTrain_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Button btn = sender as Button;

            TrainCard trainToDelete = btn.DataContext as TrainCard;
            if (trainToDelete != null)
            {
                var result = MessageBox.Show($"Delete train for {trainToDelete.Date}?",
                    "Confirm", 
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes) 
                {
                    var mainWindow = Window.GetWindow(this) as MainWindow;

                    if (mainWindow != null)
                    {
                        mainWindow.Trains.Remove(trainToDelete);
                    }
                }
            }

        }
    }
}
