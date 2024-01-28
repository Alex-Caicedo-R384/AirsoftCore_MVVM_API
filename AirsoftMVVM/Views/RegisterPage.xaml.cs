using AirsoftMVVM.ViewModels;

namespace AirsoftMVVM.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}