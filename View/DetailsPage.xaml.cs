using System.Linq;
using System.Threading.Tasks;
using homeapp.ViewModel;
using Microsoft.Maui.Controls; // or Xamarin.Forms if this is a Xamarin.Forms project

namespace homeapp.Resources.View
{
    public partial class DetailsPage : ContentPage
    {
        // fields
        private VisualElement? detailsBtn;
        private VisualElement? imagesView;
        private VisualElement? addressView;
        private VisualElement? buyBtn;
        private VisualElement? popView;

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
                if (detailsBtn != null)
                {
                    _ = FadeAndScale(detailsBtn);
                    _ = RotateView(detailsBtn);
                }

                if (imagesView != null)
                    _ = FadeAndTranslate(imagesView);

                await Task.Delay(500);

                if (addressView != null)
                    await FadeAndTranslate(addressView, fadelength: 1000, translateLength: 1500);

                if (buyBtn != null)
                    await FadeAndScale(buyBtn, fadelength: 1000, scaleLength: 1500);

                if (popView != null)
                    await FadeAndTranslate(popView, fadelength: 1000, translateLength: 1500);
            };
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
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
                addressView.TranslationX = addressView.TranslationY = -30;
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

        // Option A: if RotateToAsync returns Task
        private static Task RotateView(VisualElement view) =>using System.Linq;
using System.Threading.Tasks;
using homeapp.ViewModel;
using Microsoft.Maui.Controls;
using homeapp.Model;

namespace homeapp.View  // Changed from homeapp.Resources.View
{
    public partial class DetailsPage : ContentPage
    {
        // fields
        private VisualElement? detailsBtn;
        private VisualElement? imagesView;
        private VisualElement? addressView;
        private VisualElement? buyBtn;
        private VisualElement? popView;

        public DetailsPage(Home SelectedHome)
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
                if (detailsBtn != null)
                {
                    _ = FadeAndScale(detailsBtn);
                    _ = RotateView(detailsBtn);
                }

                if (imagesView != null)
                    _ = FadeAndTranslate(imagesView);

                await Task.Delay(500);

                if (addressView != null)
                    await FadeAndTranslate(addressView, fadelength: 1000, translateLength: 1500);

                if (buyBtn != null)
                    await FadeAndScale(buyBtn, fadelength: 1000, scaleLength: 1500);

                if (popView != null)
                    await FadeAndTranslate(popView, fadelength: 1500, translateLength: 2000);
            };
        }
        
        // ... rest of your code
    }
}
            view.RotateToAsync(0, 1500, Easing.SinInOut);

        // Option B: if RotateToAsync returns Task<bool> (recommended by CA1859)
        // private static Task<bool> RotateView(VisualElement view) =>
        //     view.RotateToAsync(0, 1500, Easing.SinInOut);
    }
}