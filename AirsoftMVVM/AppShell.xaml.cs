using AirsoftMVVM.ViewModels;
using AirsoftMVVM.Views;

namespace AirsoftMVVM
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            this.BindingContext = new AppShellViewModel();
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(ContactPage), typeof(ContactPage));
        }
    }
}