using System;
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
        private TrainCard _trainToEdit;
        private void EditTrain_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            _trainToEdit = btn.DataContext as TrainCard;
            if (_trainToEdit != null) 
            {
                if (DateTime.TryParse(_trainToEdit.Date, out DateTime oldDate))
                {
                    EditDatePicker.SelectedDate = oldDate;
                }
                foreach (ComboBoxItem item in EditTypeComboBox.Items)
                {
                    if (item.Content.ToString() == _trainToEdit.Type)
                    {
                        EditTypeComboBox.SelectedItem = item;
                        break;
                    }
                }
                EditTrainPopup.IsOpen = true;
            }
        }
        private void SaveEdit_Click(object sender, RoutedEventArgs e)
        {
            if (_trainToEdit != null)
            { 
                var mainWindow = Window.GetWindow(this) as MainWindow;
                if (mainWindow != null)
                {
                    string newDate = EditDatePicker.SelectedDate.HasValue
                        ? EditDatePicker.SelectedDate.Value.ToString("dd.MM.yyyy")
                        : _trainToEdit.Date;

                    var selectedTypeItem = EditTypeComboBox.SelectedItem as ComboBoxItem;
                    string newType = selectedTypeItem != null ? selectedTypeItem.Content.ToString() : _trainToEdit.Type;

                    string newEmoji = "🏋️";

                    if (newType.Contains("Chest") || newType.Contains("Back")) newEmoji = "🏋️";
                    else if (newType.Contains("Leg")) newEmoji = "🦵";
                    else if (newType.Contains("Arm")) newEmoji = "💪";
                    else if (newType.Contains("Shoulder")) newEmoji = "🦾";
                    else if (newType.Contains("Cardio")) newEmoji = "🏃‍";

                    int index = mainWindow.Trains.IndexOf(_trainToEdit);
                    if (index != -1)
                    {
                        mainWindow.Trains[index] = new TrainCard
                        {
                            Date = newDate,
                            Type = newType,
                            Emoji = newEmoji,
                        };
                    }
                }
                EditTrainPopup.IsOpen = false;
                _trainToEdit = null;
            }
        }

        private void CancelEdit_Click(object sender, RoutedEventArgs e)
        {
            EditTrainPopup.IsOpen = false;
            _trainToEdit = null;
        }

        private void TrainCard_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Border clickedBorder = sender as Border;
            TrainCard selectedTrain = clickedBorder.DataContext as TrainCard;

            if (selectedTrain != null) 
            {
                var mainWindow = Window.GetWindow(this) as MainWindow;
                if (mainWindow != null) 
                {
                    mainWindow.GoToTrainDetails(selectedTrain);
                }
            }
        }
    }
}