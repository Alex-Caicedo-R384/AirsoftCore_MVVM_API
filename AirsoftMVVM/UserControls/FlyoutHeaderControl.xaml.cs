namespace AirsoftMVVM.UserControls;

public partial class FlyoutHeaderControl : ContentView
{
	public FlyoutHeaderControl()
	{
		InitializeComponent();
		if (App.user != null)
		{
			lblText.Text = "Inicio Sesion como: ";
			Correolbl.Text = App.user.Name;
		}
	}
}