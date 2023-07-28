using Newtonsoft.Json;
using StardustViewer.Model;
using Microsoft.Extensions.Logging;
using StardustViewer.Utils;
using StardustViewer.ViewModel;
using System.Collections.ObjectModel;

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