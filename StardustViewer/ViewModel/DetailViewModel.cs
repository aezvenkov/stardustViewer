using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using StardustViewer.Model;
using SkiaSharp;


namespace StardustViewer.ViewModel;

[QueryProperty(nameof(Model.Record), nameof(Model.Record))]
public partial class DetailViewModel : ObservableObject
{
    private ILogger<DetailPage> _logger;

    [ObservableProperty] private Record record;

    [ObservableProperty] private Image image;

    public DetailViewModel(ILogger<DetailPage> logger)
    {
        _logger = logger;
    }

    [RelayCommand]
    async Task GoBack() => Shell.Current.GoToAsync("..");
}