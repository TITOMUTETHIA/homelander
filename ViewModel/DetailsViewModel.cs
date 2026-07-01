using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;

namespace homeapp.ViewModel
{
    public partial class DetailsViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public Home SelectedProperty { get; set; }
        public List<string> HomeImages { get; set; } = new List<string>();
        public int MoreItems { get; set; }
        public ICommand CloeCommand => new Command(() => Application.Current.MainPage.Navigation.PopAsync()); 

        // If you raise PropertyChanged in this class, use BaseViewModel.OnPropertyChanged or implement here.
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
