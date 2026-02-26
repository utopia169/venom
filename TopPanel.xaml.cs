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
            string trainEmoji = "🏋️";

            if (selectedType.Contains("Chest workout") || selectedType.Contains("Back workout"))
                trainEmoji = "🏋️";
            else if (selectedType.Contains("Leg workout"))
                trainEmoji = "🦵";
            else if (selectedType.Contains("Arm workout"))
                trainEmoji = "💪";
            else if (selectedType.Contains("Shoulder workout"))
                trainEmoji = "🦾";
            else if (selectedType.Contains("Cardio workout"))
                trainEmoji = "🏃‍";

                var MainWindow = Window.GetWindow(this) as MainWindow;

            if (MainWindow != null) 
            {
                MainWindow.Trains.Add(new TrainCard
                {
                    Date = selectedDate,
                    Type = selectedType,
                    Emoji = trainEmoji,
                });
            }
            CreateTrainPopup.IsOpen = false;
        }

        private void TopPanel_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (window != null)
            {
                window.DragMove();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Screen_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (window != null) {
                if (window.WindowState == WindowState.Maximized)
                {
                    window.WindowState = WindowState.Normal;
                }
                else
                {
                    window.WindowState = WindowState.Maximized;
                }
            }
        }

        private void RollUp_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (window != null) {
            window.WindowState = WindowState.Minimized;
            }
        }
    }
}
