namespace RatingStudio.Avalonia.ViewModels;

public class MainViewModel : ViewModelBase
{
    #region Public Properties

    /// <summary>
    /// Aggregated data ranking view model
    /// </summary>
    public AggregatedDataRankingViewModel AggregatedDataRankingViewModel { get; private set; }

    #endregion
    
    #region Constructor
    
    public MainViewModel(AggregatedDataRankingViewModel aggregatedDataRankingViewModel)
    {
        AggregatedDataRankingViewModel = aggregatedDataRankingViewModel;
    }

    #endregion
}