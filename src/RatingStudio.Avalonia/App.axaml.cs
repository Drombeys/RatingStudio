using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using RatingStudio.Avalonia.ViewModels;
using RatingStudio.UniversityRating.ParsingFiles;

namespace RatingStudio.Avalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel(
                    new AggregatedDataRankingViewModel(
                        new UniversityRatingExcelParsing()
                        )
                )
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}