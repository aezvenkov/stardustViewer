using Newtonsoft.Json;
using StardustViewer.Model;
using Microsoft.Extensions.Logging;
using StardustViewer.ViewModel;

namespace StardustViewer
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}