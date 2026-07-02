using System.Linq;
using System.Threading.Tasks;
using homeapp.ViewModel;
using Microsoft.Maui.Controls; // or Xamarin.Forms if this is a Xamarin.Forms project

namespace homeapp.Resources.View
{
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(Model.Home SelectedHome)
        {
            InitializeComponent();

            var viewModel = new DetailsViewModel
            {
                SelectedProperty = SelectedHome,
                HomeImages = SelectedHome.Images.Take(2).ToList(),
                MoreItems = SelectedHome.Images.Count - 2
            };

            this.BindingContext = viewModel;
            SetViewPositions();

            Loaded += async (s, e) =>
            {
                // start some animations immediately
                _ = FadeAndScale(detailsBtn);
                _ = RotateView(detailsBtn);
                _ = FadeAndTranslate(imagesView);

                await Task.Delay(500);

                await FadeAndTranslate(addressView, fadelength: 1000, translateLength: 1500);
                await FadeAndScale(buyBtn, fadelength: 1000, scaleLength: 1500);
                await FadeAndTranslate(popView, fadelength: 1000, translateLength: 1500);
            };
        }

        private void SetViewPositions()
        {
            // Implementation for setting view positions
            detailsBtn.Opacity = 0;
            detailsBtn.Scale = 0.2;
            detailsBtn.Rotation = 300;

            imagesView.TranslationX = 300;
            imagesView.Opacity = 0;

            addressView.TranslationX = addressView.TranslationY = -30;
            addressView.Opacity = 0;

            buyBtn.Opacity = 0;
            buyBtn.Scale = 0.2;

            popView.TranslationY = 300;
            popView.Opacity = 0.5;
        }

        private async Task FadeAndTranslate(VisualElement view, uint fadelength = 1000, uint translateLength = 1500)
        {
            // fade and translate/scale as intended (adjust to desired animation)
            var fadeTask = view.FadeTo(1, fadelength, Easing.SinInOut);
            var translateTask = view.TranslateTo(0, 0, translateLength, Easing.SinInOut);
            await Task.WhenAll(fadeTask, translateTask);
        }

        private async Task FadeAndScale(VisualElement view, uint fadelength = 1000, uint scaleLength = 1500)
        {
            var fadeTask = view.FadeTo(1, fadelength, Easing.SinInOut);
            var scaleTask = view.ScaleTo(1, scaleLength, Easing.SinInOut);
            await Task.WhenAll(fadeTask, scaleTask);
        }

        private Task RotateView(VisualElement view) => view.RotateTo(0, 1500, Easing.SinInOut);
    }
}