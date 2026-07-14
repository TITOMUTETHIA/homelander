using System;
using System.Linq;
using System.Threading.Tasks;
using homeapp.Model;
using homeapp.ViewModel;
using Microsoft.Maui.Controls;

namespace homeapp.View
{
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(Home selectedHome)
        {
            InitializeComponent();

            var viewModel = new DetailsViewModel
            {
                SelectedProperty = selectedHome,
                HomeImages = selectedHome.Images.Take(2).ToList(),
                MoreItems = Math.Max(selectedHome.Images.Count - 2, 0)
            };

            BindingContext = viewModel;
            SetViewPositions();

            Loaded += async (s, e) =>
            {
                if (detailsBtn != null)
                {
                    _ = FadeAndScale(detailsBtn);
                    _ = RotateView(detailsBtn);
                }

                if (imagesView != null)
                {
                    _ = FadeAndTranslate(imagesView);
                }

                await Task.Delay(500);

                if (addressView != null)
                {
                    await FadeAndTranslate(addressView, 1000, 1500);
                }

                if (buyBtn != null)
                {
                    await FadeAndScale(buyBtn, 1000, 1500);
                }

                if (popView != null)
                {
                    await FadeAndTranslate(popView, 1000, 1500);
                }
            };
        }

        private void SetViewPositions()
        {
            if (detailsBtn != null)
            {
                detailsBtn.Opacity = 0;
                detailsBtn.Scale = 0.2;
                detailsBtn.Rotation = 300;
            }

            if (imagesView != null)
            {
                imagesView.TranslationX = 300;
                imagesView.Opacity = 0;
            }

            if (addressView != null)
            {
                addressView.TranslationX = -30;
                addressView.TranslationY = -30;
                addressView.Opacity = 0;
            }

            if (buyBtn != null)
            {
                buyBtn.Opacity = 0;
                buyBtn.Scale = 0.2;
            }

            if (popView != null)
            {
                popView.TranslationY = 300;
                popView.Opacity = 0.5;
            }
        }

        private static async Task FadeAndTranslate(VisualElement view, uint fadelength = 1000, uint translateLength = 1500)
        {
            var fadeTask = view.FadeToAsync(1, fadelength, Easing.SinInOut);
            var translateTask = view.TranslateToAsync(0, 0, translateLength, Easing.SinInOut);
            await Task.WhenAll(fadeTask, translateTask);
        }

        private static async Task FadeAndScale(VisualElement view, uint fadelength = 1000, uint scaleLength = 1500)
        {
            var fadeTask = view.FadeToAsync(1, fadelength, Easing.SinInOut);
            var scaleTask = view.ScaleToAsync(1, scaleLength, Easing.SinInOut);
            await Task.WhenAll(fadeTask, scaleTask);
        }

        private static Task RotateView(VisualElement view) => view.RotateToAsync(0, 1500, Easing.SinInOut);

        private async void OnContactAgentClicked(object sender, EventArgs e)
        {
            // Navigate to ContactAgentPage passing the selected property
            if (BindingContext is DetailsViewModel vm && vm.SelectedProperty != null)
            {
                await Navigation.PushAsync(new ContactAgentPage(vm.SelectedProperty));
            }
            else
            {
                await DisplayAlert("Contact", "Unable to determine the selected property.", "OK");
            }
        }
    }
}
