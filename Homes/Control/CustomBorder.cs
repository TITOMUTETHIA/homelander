using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        protected override object? GetHandler()
        {
            return Handler;
        }

        protected override void OnHandlerChanged(object? newHandler)
        {
            base.OnHandlerChanged(            base.GetHandler());

            if (newHandler != null)
            {
                // View attached to a newHandler — run entrance animation
                _ = RunEntranceAnimationAsync();
            }
        }

        [Obsolete]
        private async Task RunEntranceAnimationAsync()
        {
            await this.TranslateTo(0, 0, 1000u, Easing.SinInOut);
            await this.RotateTo(0, 1000u, Easing.SinInOut);
        }

        private void AddCornerRadius()
        {
            int index = Random.Shared.Next(CornerValues.Count);
            this.CornerRadius = new Microsoft.Maui.CornerRadius(CornerValues[index]);
        }
    }
}
