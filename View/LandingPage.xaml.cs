using homeapp.ViewModel;

namespace homeapp.View;

public partial class LandingPage : ContentPage
{
    public LandingPage()
    {
        InitializeComponent();
        BindingContext = new LandingViewModel();
    }
}

