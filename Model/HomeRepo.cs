using System;
using System.Collections.Generic;
using System.Linq;

namespace homeapp.Model
{
    public class HomeRepo
    {
        public static List<Home> GetHomes()
        {
            return new List<Home>
            {
                new Home
                {
                    Id = 1,
                    DefaultImage = "https://images.unsplash.com/photo-1505691938895-1758d7feb511",
                    Address = "123 Main St",
                    City = "San Francisco",
                    State = "CA",
                    Price = 850000,
                    Category = "Residential",
                    Type = "House",
                    Bedrooms = 4,
                    Bathrooms = 3,
                    SquareFeet = 2500,
                    Rating = 4.8,
                    Reviews = 24,
                    IsFeatured = true,
                    IsFavorite = false,
                    Description = "Beautiful modern home with stunning views",
                    ListedDate = DateTime.Now.AddDays(-15),
                    Images = new List<string>
                    {
                        "https://images.unsplash.com/photo-1505691938895-1758d7feb511",
                        "https://images.unsplash.com/photo-1560185127-6c1f3b0e4f1b",
                        "https://images.unsplash.com/photo-1570129477492-45c003edd2be"
                    }
                },
                new Home
                {
                    Id = 2,
                    DefaultImage = "https://images.unsplash.com/photo-1560185127-6c1f3b0e4f1b",
                    Address = "456 Oak St",
                    City = "Los Angeles",
                    State = "CA",
                    Price = 750000,
                    Category = "Residential",
                    Type = "Condo",
                    Bedrooms = 3,
                    Bathrooms = 2,
                    SquareFeet = 1800,
                    Rating = 4.5,
                    Reviews = 18,
                    IsFeatured = true,
                    IsFavorite = false,
                    Description = "Luxury condo in prime location",
                    ListedDate = DateTime.Now.AddDays(-8),
                    Images = new List<string>
                    {
                        "https://images.unsplash.com/photo-1560185127-6c1f3b0e4f1b",
                        "https://images.unsplash.com/photo-1570129477492-45c003edd2be",
                        "https://images.unsplash.com/photo-1505691938895-1758d7feb511"
                    }
                },
                new Home
                {
                    Id = 3,
                    DefaultImage = "https://images.unsplash.com/photo-1570129477492-45c003edd2be",
                    Address = "789 Pine St",
                    City = "New York",
                    State = "NY",
                    Price = 1250000,
                    Category = "Residential",
                    Type = "Townhouse",
                    Bedrooms = 5,
                    Bathrooms = 4,
                    SquareFeet = 3200,
                    Rating = 4.9,
                    Reviews = 32,
                    IsFeatured = true,
                    IsFavorite = false,
                    Description = "Elegant townhouse in Manhattan",
                    ListedDate = DateTime.Now.AddDays(-3),
                    Images = new List<string>
                    {
                        "https://images.unsplash.com/photo-1570129477492-45c003edd2be",
                        "https://images.unsplash.com/photo-1505691938895-1758d7feb511",
                        "https://images.unsplash.com/photo-1560185127-6c1f3b0e4f1b"
                    }
                },
                new Home
                {
                    Id = 4,
                    DefaultImage = "https://images.unsplash.com/photo-1552321554-5fefe8c9ef14",
                    Address = "321 Elm St",
                    City = "Seattle",
                    State = "WA",
                    Price = 650000,
                    Category = "Residential",
                    Type = "House",
                    Bedrooms = 3,
                    Bathrooms = 2,
                    SquareFeet = 2000,
                    Rating = 4.6,
                    Reviews = 15,
                    IsFeatured = false,
                    IsFavorite = false,
                    Description = "Cozy home near downtown",
                    ListedDate = DateTime.Now.AddDays(-20),
                    Images = new List<string>
                    {
                        "https://images.unsplash.com/photo-1552321554-5fefe8c9ef14",
                        "https://images.unsplash.com/photo-1560185127-6c1f3b0e4f1b",
                        "https://images.unsplash.com/photo-1505691938895-1758d7feb511"
                    }
                },
                new Home
                {
                    Id = 5,
                    DefaultImage = "https://images.unsplash.com/photo-1460317442991-0ec209397118",
                    Address = "654 Maple Ave",
                    City = "Boston",
                    State = "MA",
                    Price = 920000,
                    Category = "Residential",
                    Type = "Apartment",
                    Bedrooms = 2,
                    Bathrooms = 2,
                    SquareFeet = 1400,
                    Rating = 4.7,
                    Reviews = 28,
                    IsFeatured = true,
                    IsFavorite = false,
                    Description = "Modern apartment with city views",
                    ListedDate = DateTime.Now.AddDays(-5),
                    Images = new List<string>
                    {
                        "https://images.unsplash.com/photo-1460317442991-0ec209397118",
                        "https://images.unsplash.com/photo-1505691938895-1758d7feb511",
                        "https://images.unsplash.com/photo-1560185127-6c1f3b0e4f1b"
                    }
                },
                new Home
                {
                    Id = 6,
                    DefaultImage = "https://images.unsplash.com/photo-1564013799919-ab600027ffc6",
                    Address = "987 Cedar Lane",
                    City = "Chicago",
                    State = "IL",
                    Price = 580000,
                    Category = "Residential",
                    Type = "House",
                    Bedrooms = 3,
                    Bathrooms = 2,
                    SquareFeet = 1700,
                    Rating = 4.4,
                    Reviews = 12,
                    IsFeatured = false,
                    IsFavorite = false,
                    Description = "Charming home in quiet neighborhood",
                    ListedDate = DateTime.Now.AddDays(-12),
                    Images = new List<string>
                    {
                        "https://images.unsplash.com/photo-1564013799919-ab600027ffc6",
                        "https://images.unsplash.com/photo-1505691938895-1758d7feb511",
                        "https://images.unsplash.com/photo-1560185127-6c1f3b0e4f1b"
                    }
                }
            };
        }

        public static List<Home> SearchHomes(string searchTerm)
        {
            var homes = GetHomes();
            if (string.IsNullOrWhiteSpace(searchTerm))
                return homes;

            searchTerm = searchTerm.ToLower();
            return homes.Where(h => 
                h.Address.ToLower().Contains(searchTerm) ||
                h.City.ToLower().Contains(searchTerm) ||
                h.Type.ToLower().Contains(searchTerm)
            ).ToList();
        }

        public static List<Home> FilterByCategory(string category)
        {
            return GetHomes().Where(h => h.Category == category).ToList();
        }

        public static List<Home> FilterByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return GetHomes().Where(h => h.Price >= minPrice && h.Price <= maxPrice).ToList();
        }

        public static List<Home> GetFeaturedHomes()
        {
            return GetHomes().Where(h => h.IsFeatured).ToList();
        }

        public static List<string> GetCategories()
        {
            return new List<string> { "Residential", "Commercial", "Land", "Vacation" };
        }

        public static List<string> GetPropertyTypes()
        {
            return new List<string> { "House", "Condo", "Townhouse", "Apartment", "Villa" };
        }

        public static List<string> GetCities()
        {
            return GetHomes().Select(h => h.City).Distinct().ToList();
        }
    }
}
