using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using homeapp.Model;

namespace homeapp.ViewModel
{
    public partial class DetailsViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public required Home SelectedProperty { get; set; }
        public List<string> HomeImages { get; set; } = new List<string>();
        public int MoreItems { get; set; }

        // If you raise PropertyChanged in this class, use BaseViewModel.OnPropertyChanged or implement here.
        public new event PropertyChangedEventHandler? PropertyChanged;
    }
}
