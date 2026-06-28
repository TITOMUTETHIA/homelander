
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Text;
namespace homeapp.ViewModel
{
    public class DetailsViewModel : BaseViewModel
    {
        public class DetailsViewModel : BaseViewModel
        {
          public Home SelectedProperty { get; set; }
          public List<String> HomeImages {  get; set; }
          public int MoreItems { get; set; }

          public ICommand CloeCommand => new Command(() => Application.Current.MainPage.Navigation.PopAsync()); 
         
    }
}
}
