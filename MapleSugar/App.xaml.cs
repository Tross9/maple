
using MapleSugar.PageModels;
using MapleSugar.PageModels.Base;
using MapleSugar.Services.Navigation;

namespace MapleSugar
{
    public partial class App : Application
    {
        public static double ScreenWidth { get; internal set; }

        public App()
        {
            InitializeComponent();
        }

        private Task InitNavigation()
        {
            var navService = PageModelLocator.Resolve<NavigationService>();
            return navService.NavigateToAsync<SplashPageModel>(null, true);
        }

        protected override async void OnStart()
        {
            base.OnStart();
            await InitNavigation();
            base.OnResume();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
