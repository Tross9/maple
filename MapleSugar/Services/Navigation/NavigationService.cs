
using MapleSugar.PageModels.Base;

namespace MapleSugar.Services.Navigation
{
    public class NavigationService : INavigationService

    {
        public Task GoBackAsync()
        {
            return App.Current.MainPage.Navigation.PopAsync();
        }

        public async Task NavigateToAsync<TPageModelBase>(object navigationData = null, bool setRoot = false)
            where TPageModelBase : PageModelBase
        {
            var page = PageModelLocator.CreatePageFor(typeof(TPageModelBase));

            if (setRoot)
            {
                if (page is TabbedPage tabbedPage)
                {
                    App.Current.MainPage = tabbedPage;
                } 
                else
                {
                    App.Current.MainPage = new NavigationPage(page);
                }
                
            }
            else
            {
                if (page is TabbedPage tabPage)
                {

                    //change here, but you need to hide the navigationbar by the   android:TabbedPage.ToolbarPlacement="Bottom" in the MenuPage.xaml
                    App.Current.MainPage = new NavigationPage(tabPage);
                }
                //change here, detect current Main page is Navigation page
                else if (App.Current.MainPage is NavigationPage navPage)
                {
                    //change here. navigate the detailed page
                    await navPage.Navigation.PushAsync(page);
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(page);
                }
            }

            if (page.BindingContext is PageModelBase pmBase)
            {
                await pmBase.InitializeAsync(navigationData);
            }         
          
        }
    }
}
