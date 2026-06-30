using Android.Widget;
using homeapp.ViewModel;

namespace homeapp.Resources.View;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(Model.Home SelectedHome)
	{
        InitializeComponent();
        var viewModel = new DetailsViewModel () { SelectedHome = SelectedHome, HomeImages};
        viewModel.HomeImages = SelectedHome.Images.Take(count:2).ToList();
        viewModel.MoreItems = SelectedHome.Images.Count - 2;    
        this.BindingContext = viewModel;
        SetViewPositions();
        Loaded += (s, e) =>
        {
            FadeAndScale(detailsBtn);
            RotateView(detailsBtn);
            FadeAndTranslate(imagesView);

            Task.Delay(millisecondsDelay: 500);
            {
                FadeAndTranslate(addressView, fadelength: 1000, translateLength: 1500);
                FadeAndScale(buyBtn, fadelength: 1000, scaleLength: 1500);
                FadeAndTranslate(popView, fadelength: 1000, translateLength: 1500);
            }
        }})
        };
    })
    }
    private void SetViewPositions()
    {
        // Implementation for setting view positions
        detailsBtn.Opacity = 0;
        detailBtn.Scale = 0.2;
        DetailsBtn.Rotation = 300;

        imageView.TranslationX = 300;
        imageView.Opacity = 0;
        addressView.TranslationX = addressView.TranslationY = -30;
        addresView.Opacity = 0;

        buyBtn.Opacity = 0;
        buyBtn.Scale = 0.2;

        popView.TranslationY = 300;
        popView.Opacity = 0.5   ;
    }
}

pivate void FadeAndTranslateView(VisualElement view, uint fadeLength = 1000, uint translateLength = 1500)
    {
     view.FadeTo(Opacity: 1, fadeLength, Easing.SinInOut);
     view.ScaleTo(scale: 1, translateLength, Easing.SinInOut);
    }
    private void FadeAndScale(VisualElement view, uint fadeLength = 1000, uint scaleLength = 1500)
    {
        view.FadeTo(Opacity: 1, fadeLength, Easing.SinInOut);
        view.ScaleTo(scale: 1, scaleLength, Easing.SinInOut);
    }

    private void RotateView(VisualElement view)=>view.RotateTo(rotation: 0, length: 1500, easing: Easing.SinInOut);)
}
}