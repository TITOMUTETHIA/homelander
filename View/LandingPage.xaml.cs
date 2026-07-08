using HomeApp.View;
namespace HomeApp.View;


public partial class using HomeApp.View;
using homeapp.ViewModel;

namespace HomeApp.View;

public partial class LandingPage : ContentPage
{
    public LandingPage()
    {
        InitializeComponent();
        this.BindingContext = new LandingViewModel();
        // Set first radio button as checked if SectionList has items
        if (SectionList.Children.Count > 0)
            (SectionList.Children[0] as RadioButton).IsChecked = true;
    }
}LandingPage : ContentPage
{
    public LandingPage()
    {
        InitializeComponent();
        this.BindingContext = new LandingViewModel();
        (SectionList.Children[index: 0] as RadioButton).IsChecked = true;
    }
}

