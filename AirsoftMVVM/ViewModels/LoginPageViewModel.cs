using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AirsoftMVVM.ViewModels;

public partial class LoginPageViewModel : ObservableObject 
{
    [ObservableProperty]
    private string _email;

    [ObservableProperty]
    private string _password;

    [RelayCommand]
    public async void SignIn() 
    { 
    }

}
