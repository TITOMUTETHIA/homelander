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

            // Subscribe to handler changed event
            HandlerChanged += OnCustomHandlerChanged;
        }

        private void OnCustomHandlerChanged(object? sender, EventArgs e)
        {
            if (Handler != null)
            {
                // View attached to a handler — run entrance animation
                _ = RunEntranceAnimationAsync();
            }
        }

        protected object? GetHandler()
        {
            return Handler;
        }

        private async Task RunEntranceAnimationAsync()
        {
            await this.TranslateToAsync(0, 0, 1000u, Easing.SinInOut);
            await this.RotateToAsync(0, 1000u, Easing.SinInOut);
        }

        private void AddCornerRadius()
        {
            int index = Random.Shared.Next(CornerValues.Count);
            this.CornerRadius = new Microsoft.Maui.CornerRadius(CornerValues[index]);
        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(
                nameof(CornerRadius),
                typeof(Microsoft.Maui.CornerRadius),
                typeof(CustomBorder),
                default(Microsoft.Maui.CornerRadius));

        public Microsoft.Maui.CornerRadius CornerRadius
        {
            get => (Microsoft.Maui.CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
    }
}
