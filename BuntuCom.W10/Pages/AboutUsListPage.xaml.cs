//---------------------------------------------------------------------------
//
// <copyright file="AboutUsListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>5/6/2016 2:55:06 PM</createdOn>
//
//---------------------------------------------------------------------------

using System.ComponentModel;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.DataProviders.Html;
using BuntuCom.Sections;
using BuntuCom.ViewModels;
using AppStudio.Uwp;

namespace BuntuCom.Pages
{
    public sealed partial class AboutUsListPage : Page
    {
	    public ListViewModel ViewModel { get; set; }

        private DataTransferManager _dataTransferManager;
		public static readonly DependencyProperty HtmlContentProperty =
            DependencyProperty.Register("HtmlContent", typeof(string), typeof(AboutUsListPage), new PropertyMetadata(string.Empty));
        public AboutUsListPage()
        {
			this.ViewModel = ListViewModel.CreateNew(Singleton<AboutUsConfig>.Instance);

            this.InitializeComponent();

        }

        public string HtmlContent
        {
            get { return (string)GetValue(HtmlContentProperty); }
            set { SetValue(HtmlContentProperty, value); }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync();
			if (ViewModel.Items != null && ViewModel.Items.Count > 0)
			{
                HtmlContent = ViewModel.Items[0].Content;
            }
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _dataTransferManager.DataRequested -= OnDataRequested;

            base.OnNavigatedFrom(e);
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            ViewModel.ShareContent(args.Request);
        }
    }
}
