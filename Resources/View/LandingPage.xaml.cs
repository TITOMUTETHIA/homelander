namespace PropertApp.ViewModel;
namespace PropertApp.views;

public partial class LandingPage : ContentPage
{
	public LandingPage()
	{
		InitializeComponent();
		this.BindingContext = new LandingPageViewModel();
    }
}