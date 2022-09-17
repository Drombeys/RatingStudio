using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace RatingStudio.Avalonia.Views;

public partial class AggregatedDataRankingView : UserControl
{
    public AggregatedDataRankingView() => InitializeComponent();

    private void InitializeComponent() => AvaloniaXamlLoader.Load(this);
}