using StardustViewer.Utils;
#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

namespace StardustViewer;

public partial class App : Application
{
    const int WindowWidth = 660;
    const int WindowHeight = 780;

    public App()
    {
        InitializeComponent();

        Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
        {
#if WINDOWS
            var mauiWindow = handler.VirtualView;
            var nativeWindow = handler.PlatformView;
            nativeWindow.Activate();
            IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
            WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
            AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
            appWindow.Resize(new SizeInt32(WindowWidth, WindowHeight));
#endif
        });

        MainPage = new AppShell();

        Resources.Add(nameof(ValueToColorConverter), new ValueToColorConverter());
        Resources.Add(nameof(ByteArrayToImageConverter), new ByteArrayToImageConverter());
    }
}