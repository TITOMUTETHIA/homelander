using System;
using System.Collections.Generic;
using System.Text;

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
                    DefaultImage = "https://images.unsplash.com/photo-1505691938895-1758d7feb511",
                    Address = "123 Main St, Anytown, USA",
                    Price = 250000,
                    Images = new List<string>
                    {
                        "https://images.unsplash.com/photo-1505691938895-1758d7feb511",
                        "https://images.unsplash.com/photo-1560185127-6c1f3b0e4f1b",
                        "https://images.unsplash.com/photo-1570129477492-45c003edd2be"
                    }
                },
                new Home
                {
                    DefaultImage = "https://images.unsplash.com/photo-1560185127-6c1f3b0e4f1b",
                    Address = "456 Oak St, Anytown, USA",
                    Price = 350000,
                    Images = new List<string>
                    {
                        "https://images.unsplash.com/photo-1560185127-6c1f3b0e4f1b",
                        "https://images.unsplash.com/photo-1570129477492-45c003edd2be",
                        "https://images.unsplash.com/photo-1505691938895-1758d7feb511"
                    }
                },
                new Home
                {
                    DefaultImage = "https://images.unsplash.com/photo-1570129477492-45c003edd2be",
                    Address = "789 Pine St, Anytown, USA",
                    Price = 450000,
                    Images = new List<string>
                    {
                        "https://images.unsplash.com/photo-1570129477492-45c003edd2be",
                        "https://images.unsplash.com/photo-1505691938895-1758d7feb511",
                        "https://images.unsplash.com/photo-1560185127-6c1f3b0e4f1b"
                    }
                }
            };
        }
    }
}
