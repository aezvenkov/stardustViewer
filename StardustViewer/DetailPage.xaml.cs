using StardustViewer.ViewModel;

namespace StardustViewer;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;

        LabModeFrame.IsVisible = !Config.IsUserApp;
    }
}