using AirsoftMVVM.Models;

namespace AirsoftMVVM;

public partial class App : Application
{
    public static User user;
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}