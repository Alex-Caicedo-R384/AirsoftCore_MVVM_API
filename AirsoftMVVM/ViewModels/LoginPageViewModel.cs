using AirsoftMVVM.Models;
using AirsoftMVVM.Services;
using AirsoftMVVM.UserControls;
using AirsoftMVVM.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;

namespace AirsoftMVVM.ViewModels;

public partial class LoginPageViewModel : ObservableObject 
{
    [ObservableProperty]
    private string _email;

    [ObservableProperty]
    private string _password;

    readonly ILoginRepository loginService = new LoginService();

    [RelayCommand]
    public async void SignIn() 
    {
        try 
        {
            if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
            {
                User user = await loginService.Login(Email, Password);
                if (user != null)
                {
                    if (Preferences.ContainsKey(nameof(App.user)))
                    {
                        Preferences.Remove(nameof(App.user));
                    }
                    string userDetails = JsonConvert.SerializeObject(user);
                    Preferences.Set(nameof(App.user), userDetails);
                    App.user = user;
                    Shell.Current.FlyoutHeader = new FlyoutHeaderControl();
                    await Shell.Current.GoToAsync(nameof(HomePage));
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "El Correo y/o contraseñas incorrectos", "OK");
                    return;
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Todos los campos son requeridos", "OK");
                return;
            }    
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            return;
        }
    }

}
