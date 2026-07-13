using System;
using System.Collections.Generic;
using System.Linq;
using homeapp.Model;

namespace homeapp.Services
{
    public class FilterService
    {
        private List<Home> _allHomes;

        public FilterService()
        {
            _allHomes = HomeRepo.GetHomes();
        }

        public List<Home> ApplyFilters(
            string? searchTerm = null,
            string? category = null,
            string? propertyType = null,
            string? city = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            int? minBedrooms = null)
        {
            var filtered = _allHomes.AsEnumerable();

            // Search term filter
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var term = searchTerm.ToLower();
                filtered = filtered.Where(h =>
                    h.Address.ToLower().Contains(term) ||
                    h.City.ToLower().Contains(term) ||
                    h.Type.ToLower().Contains(term) ||
                    (h.Description?.ToLower().Contains(term) ?? false)
                );
            }

            // Category filter
            if (!string.IsNullOrWhiteSpace(category))
            {
                filtered = filtered.Where(h => h.Category == category);
            }

            // Property type filter
            if (!string.IsNullOrWhiteSpace(propertyType))
            {
                filtered = filtered.Where(h => h.Type == propertyType);
            }

            // City filter
            if (!string.IsNullOrWhiteSpace(city))
            {
                filtered = filtered.Where(h => h.City == city);
            }

            // Price range filter
            if (minPrice.HasValue)
            {
                filtered = filtered.Where(h => h.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                filtered = filtered.Where(h => h.Price <= maxPrice.Value);
            }

            // Bedrooms filter
            if (minBedrooms.HasValue)
            {
                filtered = filtered.Where(h => h.Bedrooms >= minBedrooms.Value);
            }

            return filtered.ToList();
        }

        public List<Home> SortByPrice(List<Home> homes, bool ascending = true)
        {
            return ascending
                ? homes.OrderBy(h => h.Price).ToList()
                : homes.OrderByDescending(h => h.Price).ToList();
        }

        public List<Home> SortByRating(List<Home> homes, bool descending = true)
        {
            return descending
                ? homes.OrderByDescending(h => h.Rating).ToList()
                : homes.OrderBy(h => h.Rating).ToList();
        }

        public List<Home> SortByNewest(List<Home> homes)
        {
            return homes.OrderByDescending(h => h.ListedDate).ToList();
        }
    }
}
