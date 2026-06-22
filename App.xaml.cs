using homeapp.Resources.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui; // if needed
using Microsoft.Maui.Controls;

namespace homeapp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // Do not set MainPage here (deprecated)
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new LandingPage()));
        }
    }
}