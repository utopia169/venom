using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyApp
{
    public class TrainCard : INotifyPropertyChanged
    {
        public string Date { get; set; }
        public string Type { get; set; }
        public string Emoji { get; set; }

        private string _duration = "00:00:00";
        public string Duration
        {
            get => _duration;
            set {  _duration = value; OnPropertyChanged(); }
        }

        public ObservableCollection<ExercisesItem> Exercises { get; set; } = new ObservableCollection<ExercisesItem>();

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    public class SetItem : INotifyPropertyChanged
    {
        private double _weight;
        private int _reps;

        public double Weight { get => _weight; set { _weight = value; OnPropertyChanged(); } }
        public int Reps { get => _reps; set { _reps = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged( [CallerMemberName] string prop = "") =>
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( prop ) );
    }

    public class ExercisesItem
    {
        public string Name { get; set; }
        public ObservableCollection<SetItem> SetItems { get; set; } = new ObservableCollection<SetItem>();
    }
}
