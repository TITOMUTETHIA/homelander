using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace homeapp.Homes.Control
{
    public class CustomBorder : Border
    {
        private static readonly List<int> CornerValues = new List<int> { 10, 40, 70, 10 };

        public CustomBorder()
        {
            TranslationX = Random.Shared.Next(-500, 500);
            Rotation = Random.Shared.Next(-10, 10);
            AddCornerRadius();
        }

        protected override void OnHandlerChanged()
        {
            base.OnHandlerChanged();

            if (Handler != null)
            {
                // View attached to a handler — run entrance animation
                _ = RunEntranceAnimationAsync();
            }
        }

        private async Task RunEntranceAnimationAsync()
        {
            await this.TranslateTo(x: 0, y: 0, length: 1000u, easing: Easing.SinInOut);
            await this.RotateTo(rotation: 0, length: 1000u, easing: Easing.SinInOut);
        }

        private void AddCornerRadius()
        {
            int index = Random.Shared.Next(CornerValues.Count);
            CornerRadius = new CornerRadius(CornerValues[index]);
        }
    }
}
