using HomeApp.View;

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