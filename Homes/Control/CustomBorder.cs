using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;    

namespace homeapp.Homes.Control
{
    public class CustomBorder : Border  
    {
        public CustomBorder()
        {
            TranslationX = new Random().Next(-500, 500);
            Rotation = Math.Max(TranslationX, 100);
            AddCornerRadius();

            Loaded += async (s, e) =>
            {
               await this.TranslateToAsync(x: 0, y: 0, length: 1000, easing: Easing.SinInOut);
await this.RotateToAsync(rotation: 0, length: 1000, easing: Easing.SinInOut);

            };
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
