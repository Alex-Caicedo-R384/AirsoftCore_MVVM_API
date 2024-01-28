using AirsoftMVVM.ViewModels;

namespace AirsoftMVVM.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}