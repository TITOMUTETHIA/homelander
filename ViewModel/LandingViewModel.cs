using System.Windows.Input;
using homeapp.View;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using homeapp.Model;
using homeapp.Resources.View;

namespace homeapp.ViewModel
{
    public class LandingViewModel : BaseViewModel
    {
        public List<string> Section => new List<string> { "Trending", "Popular", "Buy", "Rent" };
        public List<Home> Homes => HomeRepo.GetHomes();
        public Home? SelectedHome { get; set; }
        public ICommand HomeSelectedCommand => new Command(async obj =>
        {
            var home = SelectedHome;
            if (home == null)
                return;

            // Use current application's first window's Page (single-window scenario).
            var navigation = App.Current?.Windows?.FirstOrDefault()?.Page?.Navigation;
            if (navigation != null)
            {
                await navigation.PushAsync(new DetailsPage(home));
                SelectedHome = null; // Reset the selected home after navigation
            }
            // If navigation is null, do nothing (or consider logging / alternative fallback).
        });
    }
}
