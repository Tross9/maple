using MapleSugar.PageModels.Base;
using MapleSugar.Services.Navigation;
using System.Windows.Input;

namespace MapleSugar.PageModels
{
    public class SplashPageModel : PageModelBase
    {       
        private ICommand _splashScreenCommand;

        public ICommand SplashScreenCommand
        {
            get => _splashScreenCommand;
            set => SetProperty(ref _splashScreenCommand, value);
        }

        private string _statusMsg;
        public string StatusMsg
        {
            get => _statusMsg;
            set
            {
                SetProperty(ref _statusMsg, value);
            }
        }

        private NavigationService _navigationService;
        public  SplashPageModel(NavigationService navigationService)
        {            
            _navigationService = navigationService;            
            SplashScreenCommand = new Command(OnSplashPageAction);
            StatusMsg = "Ready";
        }       
        private async void OnSplashPageAction(object ogj)
        {
            StatusMsg = "Loading Menu Screen -- Please Wait";
            await _navigationService.NavigateToAsync<MenuPageModel>();
        }
    }
}

