using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using homeapp.Model;
using homeapp.View;

namespace homeapp.ViewModel
{
    public class LandingViewModel : BaseViewModel
    {
        public List<string> Section => new List<string> { "Trending", "Popular", "Buy", "Rent" };
        public List<Home> Homes => HomeRepo.GetHomes();

        public ICommand HomeSelectedCommand => new Command(async obj =>
        {
            if (obj is not Home home)
                return;

            var navigation = App.Current?.Windows?.FirstOrDefault()?.Page?.Navigation;
            if (navigation != null)
            {
                await navigation.PushAsync(new DetailsPage(home));
            }
        });
    }
}
