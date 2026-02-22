using System;
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
            var selectedTypeItem = TrainigTypeComboBox.SelectedItem as ComboBoxItem;
            string selectedType = selectedTypeItem.Content.ToString();

            string selectedDate = TrainDataPicker.SelectedDate.HasValue
                ? TrainDataPicker.SelectedDate.Value.ToString("dd.MM.yyyy")
                : DateTime.Now.ToString("dd.MM.yyyy");

            var MainWindow = Window.GetWindow(this) as MainWindow;
            if (MainWindow != null) 
            {
                MainWindow.Trains.Add(new TrainCard
                {
                    Date = selectedDate,
                    Type = selectedType,
                });
            }
            CreateTrainPopup.IsOpen = false;
        }
    }
}
