using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Sytem.Threading.Tasks;    

namespace homeapp.Homes.Control
{
    public class CustomBorder : Border  
    {
        public CustomBorder()
        {
            AddCornerRadius();
        }
        private List<int> CornerValues = new List<int> { 10, 40, 70, 10};
        private void AddCornerRadius()
        {
            var index = new Random().Next(maxValue: 4);
            StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(CornerValues[index])
            };

        }
    }
}
