using System.Collections.ObjectModel;
using System.Windows;

namespace MyApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<TrainCard> Trains { get; set; }
        private Content _mainContent;
        public MainWindow()
        {
            InitializeComponent();

            Trains = new ObservableCollection<TrainCard>();
            this.DataContext = this;

            _mainContent = new Content();
            GoToMain();
        }
        public void GoToMain()
        {
            MainContentArea.Content = _mainContent;
            TopPanelControl.SetMode(isMainPage:true);
        }
        public void GoToTrainDetails(TrainCard train)
        {
            TrainDetailsView detailsView = new TrainDetailsView(train);
            MainContentArea.Content = detailsView;
            TopPanelControl.SetMode(isMainPage: false);
        }
    }
}
