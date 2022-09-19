using System.Collections.ObjectModel;
using RatingStudio.Domain.Dto;

namespace RatingStudio.Avalonia.ViewModels;

/// <summary>
/// Aggregated data ranking view model
/// </summary>
public class AggregatedDataRankingViewModel : ViewModelBase
{
    #region Public Properties

    public ObservableCollection<UniversityRatingDto> UniversityRating { get; private set; } = new();

    #endregion
    
    #region Constructor

    /// <summary>
    /// Default constructor
    /// </summary>
    public AggregatedDataRankingViewModel()
    {
        
    }

    #endregion
}