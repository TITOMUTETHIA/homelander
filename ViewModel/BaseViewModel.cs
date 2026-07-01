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
        public ICommand CloeCommand => new Command(() => Application.Current.MainPage.Navigation.PopAsync());
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
