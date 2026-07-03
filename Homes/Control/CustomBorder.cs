using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace homeapp.Homes.Control
{
    public partial class CustomBorder : Border
    {
        private static readonly List<int> CornerValues = new List<int> { 10, 40, 70, 10 };

        public CustomBorder()
        {
            TranslationX = Random.Shared.Next(-500, 500);
            Rotation = Random.Shared.Next(-10, 10);
            AddCornerRadius();

            Loaded += async (s, e) =>
            {
                await this.TranslateToAsync(x: 0, y: 0, length: 1000, easing: Easing.SinInOut);
                await this.RotateToAsync(rotation: 0, length: 1000, easing: Easing.SinInOut);
            };
        }

        private void AddCornerRadius()
        {
            int index = Random.Shared.Next(CornerValues.Count);
            CornerRadius = new CornerRadius(CornerValues[index]);
        }
    }
}
