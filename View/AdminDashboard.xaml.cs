using homeapp.ViewModel;

namespace homeapp.View;

public partial class AdminDashboard : ContentPage
{
    public AdminDashboard()
    {
        InitializeComponent();
        BindingContext = new AdminDashboardViewModel();
    }
}
