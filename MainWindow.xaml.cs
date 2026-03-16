using System.Collections.ObjectModel;
using System.Windows;

namespace MyApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<WorkoutCard> Trains { get; set; }
        private Content _mainContent;
        public MainWindow()
        {
            InitializeComponent();

            Trains = new ObservableCollection<WorkoutCard>();
            this.DataContext = this;

            _mainContent = new Content();
            GoToMain();
        }
        public void GoToMain()
        {
            MainContentArea.Content = _mainContent;
            TopPanelControl.SetMode(isMainPage:true);
        }
        public void GoToTrainDetails(WorkoutCard train)
        {
            TrainDetailsView detailsView = new TrainDetailsView(train);
            MainContentArea.Content = detailsView;
            TopPanelControl.SetMode(isMainPage: false);
        }

        public void GoToLibrary()
        {
            MainContentArea.Content = new LibraryView();
            TopPanelControl.SetMode(isMainPage: false);
        }
    }
}
