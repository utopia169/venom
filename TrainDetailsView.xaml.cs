using System.Collections.Generic;
using System.Windows.Controls;

namespace MyApp
{
    public partial class TrainDetailsView : UserControl
    {
        private TrainCard _currentTrain;

        private Dictionary<string, List<string>> _exerciseLibrary = new Dictionary<string, List<string>> 
        {
            {"Chest workout", new List<string> {"Bench Press", "Include Duramble Press", "Chest Fly" } },
            { "Leg workout", new List<string> { "Squats", "Leg Press", "Leg Extension" } },
            { "Back workout", new List<string> { "Pull-ups", "Deadlift", "Bent Over Row" } },
            { "Arm workout", new List<string> { "Bicep Curls", "Tricep Dips", "Hammer Curls" } },
            { "Shoulder workout", new List<string> { "Overhead Press", "Lateral Raise", "Front Raise" } },
            { "Cardio workout", new List<string> { "Running", "Cycling", "Jump Rope" } }
        };

        public TrainDetailsView(TrainCard train)
        {
            InitializeComponent();
            _currentTrain = train;

            this.DataContext = _currentTrain;

            ExercisesList.ItemsSource  = _currentTrain.Exercises;

        }
    }
}
