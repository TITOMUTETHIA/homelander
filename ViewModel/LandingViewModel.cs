using System.Windows.Input;
using homeapp.View;
using System.Linq;
using System.Threading.Tasks;  
using System.Collections.Generic;
using System;

namespace homeapp.ViewModel
{
    public class LandingViewModel : BaseViewModel
    {
        public List<String> Section => new List<string> { "Trending", "Popular", "Buy", "Rent" };
        public List<Home> Homes => HomeRepo.GetHomes();
        public Home SelectedHome
        {
            get; set;
        }
        public ICommand HomeSelectedCommand => new Command(obj =>

        {
            if (SelectedHome != null)
            {
                // Navigate to the details page with the selected home
                App.Current.MainPage.Navigation.PushAsync(new DetailsPage(SelectedHome));
            }
            SelectedHome = null; // Reset the selected home after navigation
        }
        )
    }
}
