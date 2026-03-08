using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Controls;

namespace MyApp
{
    public partial class TrainDetailsView : UserControl
    {
        private WorkoutCard _currentTrain;

        private Dictionary<string, List<string>> _exerciseLibrary = new Dictionary<string, List<string>> 
        {
            {"Chest workout", new List<string> {"Bench Press", "Include Duramble Press", "Chest Fly" } },
            { "Leg workout", new List<string> { "Squats", "Leg Press", "Leg Extension" } },
            { "Back workout", new List<string> { "Pull-ups", "Deadlift", "Bent Over Row" } },
            { "Arm workout", new List<string> { "Bicep Curls", "Tricep Dips", "Hammer Curls" } },
            { "Shoulder workout", new List<string> { "Overhead Press", "Lateral Raise", "Front Raise" } },
            { "Cardio workout", new List<string> { "Running", "Cycling", "Jump Rope" } }
        };


        public TrainDetailsView(WorkoutCard train)
        {
            InitializeComponent();
            _currentTrain = train;

            this.DataContext = _currentTrain;

            ExercisesList.ItemsSource  = _currentTrain.Exercises;

        }

        private void AddExerciseBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string currentType = _currentTrain.Type;

            if (_exerciseLibrary.ContainsKey(currentType))
            {
                ExerciseListBox.ItemsSource = _exerciseLibrary[currentType];
            }
            else
            {
                ExerciseListBox.ItemsSource = null;
            }

            ExercisePopup.IsOpen = true;
        }

        private void ExercisesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ExerciseListBox.SelectedItem != null)
            {
                string selectedExerciseName = ExerciseListBox.SelectedItem.ToString();

                ExercisesItem newExercise = new ExercisesItem()
                {
                    Name = selectedExerciseName
                };

                _currentTrain.Exercises.Add(newExercise);

                ExercisePopup.IsOpen = false;
                ExerciseListBox.SelectedItem = null;
            }
        }
        private void AddSet_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Button btnAdd = sender as Button;
            ExercisesItem exercises = btnAdd?.Tag as ExercisesItem;

            if (exercises != null) 
            {
                exercises.SetItems.Add(new SetItem()
                {
                    Weight = 0,
                    Reps = 0
                });
            }
        }
        private void RemoveSet_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Button btn = sender as Button;
            SetItem set = btn?.Tag as SetItem;

            if (set == null) return;

            foreach (var exercise in _currentTrain.Exercises)
            {
                if (exercise.SetItems.Contains(set))
                {
                    exercise.SetItems.Remove(set);
                    break;
                }
            }
        }
    }
}
