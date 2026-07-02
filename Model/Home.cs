using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace homeapp.Model
{
    public class Home
    {
        public required string DefaultImage { get; set; }
        public required string Address { get; set; }
        public required decimal Price { get; set; }
        public List<string> Images { get; set; } = new List<string>();

    }
}
