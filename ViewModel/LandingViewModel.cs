using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using homeapp.Model;
using homeapp.Services;
using homeapp.View;

namespace homeapp.ViewModel
{
    public class LandingViewModel : BaseViewModel
    {
        private readonly FilterService _filterService;
        private ObservableCollection<Home> _homes;
        private ObservableCollection<Home> _featuredHomes;
        private string _searchTerm = string.Empty;
        private string _selectedCategory = string.Empty;
        private string _selectedCity = string.Empty;
        private bool _isFiltered;

        public LandingViewModel()
        {
            _filterService = new FilterService();
            _homes = new ObservableCollection<Home>(HomeRepo.GetHomes());
            _featuredHomes = new ObservableCollection<Home>(HomeRepo.GetFeaturedHomes());
        }

        public ObservableCollection<Home> Homes
        {
            get => _homes;
            set
            {
                if (_homes != value)
                {
                    _homes = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Home> FeaturedHomes
        {
            get => _featuredHomes;
            set
            {
                if (_featuredHomes != value)
                {
                    _featuredHomes = value;
                    OnPropertyChanged();
                }
            }
        }

        public string SearchTerm
        {
            get => _searchTerm;
            set
            {
                if (_searchTerm != value)
                {
                    _searchTerm = value;
                    OnPropertyChanged();
                }
            }
        }

        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    OnPropertyChanged();
                    ExecuteFilterCommand();
                }
            }
        }

        public string SelectedCity
        {
            get => _selectedCity;
            set
            {
                if (_selectedCity != value)
                {
                    _selectedCity = value;
                    OnPropertyChanged();
                    ExecuteFilterCommand();
                }
            }
        }

        public bool IsFiltered
        {
            get => _isFiltered;
            set
            {
                if (_isFiltered != value)
                {
                    _isFiltered = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<string> Categories => HomeRepo.GetCategories();
        public List<string> Cities => HomeRepo.GetCities();
        public List<string> PropertyTypes => HomeRepo.GetPropertyTypes();

        public ICommand SearchCommand => new Command(() => ExecuteFilterCommand());

        public ICommand ClearFiltersCommand => new Command(() =>
        {
            SearchTerm = string.Empty;
            SelectedCategory = string.Empty;
            SelectedCity = string.Empty;
            IsFiltered = false;
            Homes = new ObservableCollection<Home>(HomeRepo.GetHomes());
        });

        public ICommand HomeSelectedCommand => new Command(async obj =>
        {
            if (obj is not Home home)
                return;

            var navigation = Application.Current?.Windows?.FirstOrDefault()?.Page?.Navigation;
            if (navigation != null)
            {
                await navigation.PushAsync(new DetailsPage(home));
            }
        });

        public ICommand SortByPriceCommand => new Command(() =>
        {
            var sorted = _filterService.SortByPrice(Homes.ToList());
            Homes = new ObservableCollection<Home>(sorted);
        });

        public ICommand SortByRatingCommand => new Command(() =>
        {
            var sorted = _filterService.SortByRating(Homes.ToList());
            Homes = new ObservableCollection<Home>(sorted);
        });

        public ICommand SortByNewestCommand => new Command(() =>
        {
            var sorted = _filterService.SortByNewest(Homes.ToList());
            Homes = new ObservableCollection<Home>(sorted);
        });

        private void ExecuteFilterCommand()
        {
            var filtered = _filterService.ApplyFilters(
                searchTerm: string.IsNullOrWhiteSpace(SearchTerm) ? null : SearchTerm,
                category: string.IsNullOrWhiteSpace(SelectedCategory) ? null : SelectedCategory,
                city: string.IsNullOrWhiteSpace(SelectedCity) ? null : SelectedCity
            );

            Homes = new ObservableCollection<Home>(filtered);
            IsFiltered = !string.IsNullOrWhiteSpace(SearchTerm) ||
                        !string.IsNullOrWhiteSpace(SelectedCategory) ||
                        !string.IsNullOrWhiteSpace(SelectedCity);
        }
    }
}
