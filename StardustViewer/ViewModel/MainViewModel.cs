using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using StardustViewer.Model;

namespace StardustViewer.ViewModel;

public partial class MainViewModel : ObservableObject
{
    private ILogger<MainPage> _logger;

    [ObservableProperty] ObservableCollection<Record> records;

    public MainViewModel(ILogger<MainPage> logger)
    {
        Records = new ObservableCollection<Record>();
        _logger = logger;
    }

    [ICommand]
    async void LoadingRecords()
    {
        var result = await PickTask(new PickOptions
        {
            PickerTitle = "Pick JSON File Please"
        });
    }

    [ICommand]
    async void DeleteRecord(string s)
    {
        foreach (var item in records)
        {
            if (item.MeasurementTitle.Equals(s))
            {
                records.Remove(item);
            }
        }
    }

    [RelayCommand]
    async void Tap(Record record) => Shell.Current.GoToAsync(nameof(DetailPage),
        new Dictionary<string, object>
        {
            ["Record"] = record,
        });

    public async Task<FileResult> PickTask(PickOptions options)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(options);
            if (result != null)
            {
                if (result.FileName.EndsWith("json", StringComparison.OrdinalIgnoreCase))
                {
                    var stream = await result.OpenReadAsync();
                    var data = DeserializeJsonFromStream<List<Record>>(stream);
                    foreach (var record in data)
                    {
                        records.Add(record);
                    }
                }
            }

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.StackTrace);
        }

        return null;
    }

    private T DeserializeJsonFromStream<T>(Stream stream)
    {
        using var reader = new StreamReader(stream);
        using var jsonReader = new JsonTextReader(reader);
        var serializer = new JsonSerializer();
        return serializer.Deserialize<T>(jsonReader);
    }
}