using System;
using System.Windows.Input;
using Microsoft.Maui.ApplicationModel;
using homeapp.Model;
using System.Threading.Tasks;

namespace homeapp.ViewModel
{
    public class ContactAgentViewModel : BaseViewModel
    {
        private readonly Home _home;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;

        public ICommand SendCommand { get; }
        public ICommand CancelCommand { get; }

        public ContactAgentViewModel(Home home)
        {
            _home = home;
            SendCommand = new Command(async () => await SendAsync());
            CancelCommand = new Command(async () => await CancelAsync());
        }

        private Task CancelAsync()
        {
            // Close the page by popping navigation
            return Application.Current?.Windows?.FirstOrDefault()?.Page?.Navigation?.PopAsync() ?? Task.CompletedTask;
        }

        private async Task SendAsync()
        {
            try
            {
                // Prepare mailto
                var agentEmail = "agent@example.com"; // replace with real agent email or derive from _home
                var subject = $"Inquiry about {_home.Address}";
                var body = $"Hello,%0D%0A%0D%0AMy name is {Uri.EscapeDataString(Name)}.%0D%0AEmail: {Uri.EscapeDataString(Email)}%0D%0A%0D%0A{Uri.EscapeDataString(Message)}%0D%0A%0D%0AProperty: {_home.Address}%0D%0APrice: {_home.Price}";

                var mailto = new Uri($"mailto:{agentEmail}?subject={Uri.EscapeDataString(subject)}&body={body}");
                await Launcher.OpenAsync(mailto);
            }
            catch (Exception ex)
            {
                await Application.Current?.MainPage?.DisplayAlert("Error", "Unable to open email client: " + ex.Message, "OK");
            }
        }
    }
}
