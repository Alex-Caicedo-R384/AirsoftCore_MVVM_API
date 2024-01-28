using AirsoftMVVM.Models;
using AirsoftMVVM.Services;
using AirsoftMVVM.UserControls;
using AirsoftMVVM.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;

namespace AirsoftMVVM.ViewModels;

public partial class RegisterPageViewModel : ObservableObject
{

    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private string _email;

    [ObservableProperty]
    private string _password;

    readonly ILoginRepository loginService = new LoginService();

    [RelayCommand]
    public async void Register()
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
            {
                if (await loginService.EmailExists(Email))
                {
                    await Shell.Current.DisplayAlert("Error", "El correo electrónico ya está en uso", "OK");
                    return;
                }

                User user = await loginService.Register(Name, Email, Password);
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
                    await Shell.Current.GoToAsync("//LoginPage");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "El registro no fue exitoso", "OK");
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

    [RelayCommand]
    public async void GoToLoginPage()
    {
        try
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
    }
}
