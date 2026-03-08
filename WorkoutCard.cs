using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;


namespace MyApp
{
    public class WorkoutCard : INotifyPropertyChanged
    {
        public string Date { get; set; }
        public string Type { get; set; }
        public string Emoji { get; set; }

        public ObservableCollection<ExercisesItem> Exercises { get; set; } = new ObservableCollection<ExercisesItem>();

        private DateTime? _startTime;
        public DateTime? StartTime
        {
            get => _startTime;
            set
            {
                _startTime = value;
                OnPropertyChanged(); 
                OnPropertyChanged(nameof(Duration)); 
            }
        }

        private DateTime? _endTime;
        public DateTime? EndTime
        {
            get => _endTime;
            set
            {
                _endTime = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Duration));
            }
        }

        public string Duration
        {
            get
            {
                if (StartTime == null || EndTime == null)
                    return "--:--";

                TimeSpan diff = EndTime.Value - StartTime.Value;

                if (diff.TotalMinutes < 0)
                    return "--:--";
                return diff.ToString(@"hh\:mm");
            }
        }
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

    public class ExercisesItem : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public ObservableCollection<SetItem> SetItems { get; set; } = new ObservableCollection<SetItem>();

        public double AverageWeight => SetItems.Any() ? SetItems.Average (s => s.Weight) : 0;
        public double AverageReps => SetItems.Any() ? SetItems.Average(s => s.Reps) : 0;

        public ExercisesItem()
        {
            SetItems.CollectionChanged += (s, e) =>
            {
                if (e.NewItems != null)
                {
                    foreach (INotifyPropertyChanged item in e.NewItems)
                    {
                        item.PropertyChanged += SetItem_PropertyChanged;
                    }
                }
                if (e.OldItems != null)
                {
                    foreach (INotifyPropertyChanged item in e.OldItems)
                    {
                        item.PropertyChanged -= SetItem_PropertyChanged;
                    }
                }

                OnPropertyChanged (nameof(AverageWeight));
                OnPropertyChanged (nameof(AverageReps));
            };
        }

        public  void SetItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(AverageWeight));
            OnPropertyChanged(nameof(AverageReps));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
