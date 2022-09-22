using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using DynamicData;
using RatingStudio.Domain.Dto;
using RatingStudio.Infrastructure.Matrix;
using RatingStudio.Infrastructure.ParsingFiles;
using ReactiveUI;
using Splat;

namespace RatingStudio.Avalonia.ViewModels;

/// <summary>
/// Aggregated data ranking view model
/// </summary>
public class AggregatedDataRankingViewModel : ViewModelBase
{
    private readonly IExcelParser<UniversityRatingDto> _excelParser;
    private readonly IStoreMatrix<int?, IList<UniversityRatingDto>> _storeMatrix;

    #region Public Properties

    public ObservableCollection<UniversityRatingDto> UniversityRating { get; private set; } = new();

    #region Commands

    public ReactiveCommand<Unit, Unit> LoadDataCommand { get; set; } = null!;

    #endregion
    
    #endregion
    
    #region Constructor

    /// <summary>
    /// Default constructor
    /// </summary>
    public AggregatedDataRankingViewModel(
        IExcelParser<UniversityRatingDto> excelParser,
        IStoreMatrix<int?, IList<UniversityRatingDto>> storeMatrix
        )
    {
        _excelParser = excelParser;
        _storeMatrix = storeMatrix;

        SetupCommands();
    }
    
    #endregion
    
    private void SetupCommands()
    {
        LoadDataCommand = ReactiveCommand.CreateFromObservable(LoadDataImpl);
        LoadDataCommand.ThrownExceptions.Subscribe(ex => this.Log().Error("Something went wrong", ex));
    }

    private async Task<IList<UniversityRatingDto>> ExcelParserAsync()
    {
        //TODO: Добавить окно выбора файла
        var file = new FileInfo("test_table.xlsx");

        return await _excelParser.ParseAsync(file);
    }

    private IObservable<Unit> LoadDataImpl()
    {
        return Observable.StartAsync(async () =>
        {
            UniversityRating.Clear();

            UniversityRating.AddRange(await ExcelParserAsync());

            //Перенос данных в матрицу
            var matrix = _storeMatrix.Store(UniversityRating);
        });
    }
}