using System;
using System.Collections.Generic;

namespace homeapp.Model
{
    public class Home
    {
        public int Id { get; set; }
        public required string DefaultImage { get; set; }
        public required string Address { get; set; }
        public required decimal Price { get; set; }
        public List<string> Images { get; set; } = new List<string>();

        // E-commerce properties
        public string? Category { get; set; } = "Residential";
        public string? Type { get; set; } = "House";
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int SquareFeet { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public double Rating { get; set; }
        public int Reviews { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsFavorite { get; set; }
        public string? Description { get; set; }
        public DateTime ListedDate { get; set; }
    }
}
