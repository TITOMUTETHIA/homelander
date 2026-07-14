using System;
using Microsoft.Maui.Controls;
using homeapp.Model;
using homeapp.ViewModel;

namespace homeapp.View;

public partial class ContactAgentPage : ContentPage
{
    public ContactAgentPage(Home home)
    {
        InitializeComponent();
        BindingContext = new ContactAgentViewModel(home);
    }
}
