
namespace MapleSugar.PageModels.Base
{
    public class PageModelBase : ExtendedBindableObject 
    {
        string ?_title;

        public string ?Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        bool _isloading;

        public bool IsLoading
        {
            get => _isloading;
            set => SetProperty(ref _isloading, value);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="navigationData"></param>
        /// <returns></returns>
        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.CompletedTask;
        }
      
    }
}
