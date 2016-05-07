//---------------------------------------------------------------------------
//
// <copyright file="HomePage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>5/6/2016 2:55:06 PM</createdOn>
//
//---------------------------------------------------------------------------

using AppStudio.Uwp;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using BuntuCom.ViewModels;

namespace BuntuCom.Pages
{
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            ViewModel = new MainViewModel(12);            
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
        }		
        public MainViewModel ViewModel { get; set; }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync();			
            
        }

    }
}
