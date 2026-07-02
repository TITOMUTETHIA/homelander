using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Windows.Input;
using homeapp.View;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using homeapp.ViewModel;
using System.Text;
using homeapp.Model;
namespace homeapp.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Used for data binding")]
        public ICommand CloeCommand => new Command(async () =>
        {
            var app = Application.Current;
            if (app?.Windows != null && app.Windows.Count > 0)
            {
                var page = app.Windows[0].Page;
                var nav = page?.Navigation;
                if (nav != null)
                    await nav.PopAsync();
            }
        });
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
