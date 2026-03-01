using System.Windows.Controls;

namespace MyApp
{
    public partial class TrainDetailsView : UserControl
    {
        private TrainCard _currentTrain;
        public TrainDetailsView(TrainCard train)
        {
            InitializeComponent();
            _currentTrain = train;

        }
    }
}
