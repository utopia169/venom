using System.Collections.ObjectModel;
using System.Windows;

namespace MyApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<TrainCard> Trains { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            Trains = new ObservableCollection<TrainCard>();
            this.DataContext = this;
        }
    }
}
