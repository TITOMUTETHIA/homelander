using System.Collections.ObjectModel;
using System.Windows.Input;
using homeapp.Model;
using System.Linq;
using System;

namespace homeapp.ViewModel
{
    public class AdminDashboardViewModel : BaseViewModel
    {
        public ObservableCollection<Home> Listings { get; set; }
        public ObservableCollection<Home> AllListings { get; set; }

        public List<string> PropertyTypes => HomeRepo.GetPropertyTypes();
        public List<string> Cities => HomeRepo.GetCities();

        public string? SelectedType { get; set; }
        public string? SelectedCity { get; set; }

        public int TotalListings => Listings?.Count ?? 0;
        public int FeaturedCount => Listings?.Count(h => h.IsFeatured) ?? 0;

        public ICommand ToggleFeaturedCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand RefreshCommand { get; }
        public ICommand ApplyFilterCommand { get; }
        public ICommand ClearFilterCommand { get; }

        public AdminDashboardViewModel()
        {
            AllListings = new ObservableCollection<Home>(HomeRepo.GetHomes());
            Listings = new ObservableCollection<Home>(AllListings);

            ToggleFeaturedCommand = new Command<Home>(ToggleFeatured);
            DeleteCommand = new Command<Home>(DeleteListing);
            RefreshCommand = new Command(Refresh);
            ApplyFilterCommand = new Command(ApplyFilter);
            ClearFilterCommand = new Command(ClearFilter);
        }

        private void ToggleFeatured(Home home)
        {
            if (home == null) return;
            home.IsFeatured = !home.IsFeatured;
            // Notify UI for counts
            OnPropertyChanged(nameof(FeaturedCount));
        }

        private void DeleteListing(Home home)
        {
            if (home == null) return;
            Listings.Remove(home);
            AllListings.Remove(home);
            OnPropertyChanged(nameof(TotalListings));
            OnPropertyChanged(nameof(FeaturedCount));
        }

        private void Refresh()
        {
            AllListings = new ObservableCollection<Home>(HomeRepo.GetHomes());
            Listings = new ObservableCollection<Home>(AllListings);
            OnPropertyChanged(nameof(Listings));
            OnPropertyChanged(nameof(TotalListings));
            OnPropertyChanged(nameof(FeaturedCount));
        }

        private void ApplyFilter()
        {
            var filtered = AllListings.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(SelectedType))
                filtered = filtered.Where(h => h.Type == SelectedType);
            if (!string.IsNullOrWhiteSpace(SelectedCity))
                filtered = filtered.Where(h => h.City == SelectedCity);
            Listings = new ObservableCollection<Home>(filtered);
            OnPropertyChanged(nameof(Listings));
            OnPropertyChanged(nameof(TotalListings));
            OnPropertyChanged(nameof(FeaturedCount));
        }

        private void ClearFilter()
        {
            SelectedCity = null;
            SelectedType = null;
            Listings = new ObservableCollection<Home>(AllListings);
            OnPropertyChanged(nameof(SelectedCity));
            OnPropertyChanged(nameof(SelectedType));
            OnPropertyChanged(nameof(Listings));
            OnPropertyChanged(nameof(TotalListings));
            OnPropertyChanged(nameof(FeaturedCount));
        }
    }
}
