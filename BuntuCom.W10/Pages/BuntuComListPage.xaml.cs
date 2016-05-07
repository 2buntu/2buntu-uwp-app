//---------------------------------------------------------------------------
//
// <copyright file="BuntuComListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>5/6/2016 2:55:06 PM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;
using AppStudio.DataProviders.Rss;
using BuntuCom.Sections;
using BuntuCom.ViewModels;
using AppStudio.Uwp;

namespace BuntuCom.Pages
{
    public sealed partial class BuntuComListPage : Page
    {
	    public ListViewModel ViewModel { get; set; }
        public BuntuComListPage()
        {
			this.ViewModel = ListViewModel.CreateNew(Singleton<BuntuComConfig>.Instance);

            this.InitializeComponent();

        }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync();
            base.OnNavigatedTo(e);
        }

    }
}
