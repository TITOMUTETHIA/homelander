using HomeApp.View;
namespace HomeApp.View;


public partial class LandingPage : ContentPage
{
    public LandingPage()
    {
        InitializeComponent();
        this.BindingContext = new LandingViewModel();
        (SectionList.Children[index:0] as RadioButton).IsChecked = true;
    }
}

