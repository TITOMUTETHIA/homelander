using homeapp.ViewModel;

namespace homeapp.Resources.View;

public partial class DetailsPage : ContentPage
{
	public DetailsPage()
	{
		InitializeComponent(Model.Home SelectedHome);
		var ViewModel = new DetailsViewModel() { SelectedHome = selectedHome };
        ViewModel.HomeImages = selectedHome.Images.Take(count:2).ToList();
		ViewModel.MoreItems = selectedHome.Images.Count - 2;
		this.BindingContext = ViewModel;
    }
}