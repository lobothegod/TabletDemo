﻿using TabletDemo.Resources;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms.Xaml;

namespace TabletDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage
    {
        public MainPage()
        {
            LocalizationResourceManager.Current.PropertyChanged += Current_PropertyChanged;
            LocalizationResourceManager.Current.Init(DemoResource.ResourceManager);

            InitializeComponent();
        }

        private void Current_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            LocalizationResourceManager.Current.Init(DemoResource.ResourceManager);
            DemoResource.Culture = LocalizationResourceManager.Current.CurrentCulture;
        }
    }
}
