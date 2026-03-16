using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using static MyApp.WorkoutCard;

namespace MyApp
{
    /// <summary>
    /// Логика взаимодействия для LibraryView.xaml
    /// </summary>

    
    public partial class LibraryView : Window
    {
        public static ObservableCollection<LibraryExercise> FullLibrary { get; set; } = new ObservableCollection<LibraryExercise>();
        public LibraryView()
        {

            InitializeComponent();

            if (FullLibrary.Count == 0)
            {
                FullLibrary.Add(new LibraryExercise{Id = 1, Name = "Banch press", Category = "Chest workout"});
                FullLibrary.Add(new LibraryExercise { Id = 2, Name = "Squats", Category = "Leg workout" });
            }
            LibraryItemsList.ItemsSource = FullLibrary;
        }

        private void AddLibraryExercise_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NewExerciseName.Text)) 
            {
                var category = (NewExerciseCategory.SelectedItem as ComboBoxItem)?.Content.ToString();

                FullLibrary.Add(new LibraryExercise
                {
                    Name = NewExerciseName.Text,
                    Category = category
                });

                NewExerciseName.Clear();
            }
        }

        private void DeleteLibraryExercise_Click(object sender, RoutedEventArgs e)
        {
            var exercise = (sender as Button)?.Tag as LibraryExercise;
            if (exercise != null) 
            {
                FullLibrary.Remove(exercise);
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
