using MapleSugar.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MapleSugar.Services.Navigation
{
    public interface INavigationService
    {
        /// <summary>
        /// navigation method to push onto the Navigation Stack 
        /// </summary>
        /// <typeparam name="TPageModelBase"></typeparam>
        /// <param name="navigationData"></param>
        /// <param name="setRoot"></param>
        /// <returns></returns>
        Task NavigateToAsync<TPageModelBase>(object navigationData = null, bool setRoot = false)
             where TPageModelBase : PageModelBase;

        /// <summary>
        /// navigation method to pop off the Navigation Stack 
        /// </summary>
        /// <returns></returns>
        Task GoBackAsync();

    }
}
