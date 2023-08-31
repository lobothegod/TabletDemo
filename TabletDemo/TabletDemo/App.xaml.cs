using Prism;
using Prism.Ioc;
using Prism.Unity;
using TabletDemo.Services;
using TabletDemo.ViewModels;
using TabletDemo.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace TabletDemo
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjYyMjAzNUAzMjMyMmUzMDJlMzBZMklTdVRxVXpDZm45TUhGTytnRDV1SWVNZ1NkN2w5am9pSWZzM2JKZlMwPQ==");

            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/GridDiccionario");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            //servicios:
            containerRegistry.RegisterSingleton<ITabletDemoService, TabletDemoServiceMockup>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<GridDiccionario, GridDiccionarioViewModel>();
        }
    }
}
