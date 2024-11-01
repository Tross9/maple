
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using DynamicData;
using ReactiveUI;
using System.Reactive;
using DynamicData.Binding;
using MapleSugar.Models;
using MapleSugar.Services;
using MapleSugar.ViewModels.Buttons;
using System.Windows.Input;
using MapleSugar.PageModels.Base;
using MapleSugar.Services.Navigation;

namespace MapleSugar.PageModels
{
    public class FilterViewModel : ReactiveObject, IDisposable
    {
        public FilterViewModel()       {
            
        // Initial data
        Load_Button_Clicked = new ButtonModel("Load Data", LoadFilterAction);

            //Search logic
            Func<FilterList, bool> treeFilter(string text) => tree =>
            {
                return string.IsNullOrEmpty(text) || tree.TreeNumber.ToString().ToLower().Contains(text.ToLower()) || tree.Sector.ToString().Contains(text.ToLower());
            };

            var filterPredicate = this.WhenAnyValue(x => x.SearchText)
                                      .Throttle(TimeSpan.FromMilliseconds(250), RxApp.TaskpoolScheduler)
                                      .DistinctUntilChanged()
                                      .Select(treeFilter);

            //Filter logic
            Func<FilterList, bool> countryFilter(string sector) => tree =>
            {
                return sector == "All" || sector == tree.Sector.ToString().ToLower();
            };

            var countryPredicate = this.WhenAnyValue(x => x.SelectedSectorFilter)
                                       .Select(countryFilter);

            //sort
            var sortPredicate = this.WhenAnyValue(x => x.SortBy)
                                    .Select(x => x == "Sector" ? SortExpressionComparer<FilterList>.Ascending(a => a.Sector) : SortExpressionComparer<FilterList>.Ascending(a => a.SortField));

            _cleanUp = _sourceCache.Connect()
            .RefCount()
            .Filter(countryPredicate)
            .Filter(filterPredicate)
            .Sort(sortPredicate)
            .Bind(out _trees)
            .DisposeMany()
            .Subscribe();

            //Set default values
            SelectedSectorFilter = "All";
            SortBy = "TreeNumber";

            SortCommand = ReactiveCommand.CreateFromTask(ExecuteSort);

            OnEditCommand = new Microsoft.Maui.Controls.Command(OnEditCommandAction);
        }

        private async Task ExecuteSort()
        {
            var sort = await App.Current.MainPage.DisplayActionSheet("Sort by", "Cancel", null, buttons: new string[] { "Sector", "SortField" });
            if (sort != "Cancel")
            {
                SortBy = sort;
            }
        }

        public void Dispose()
        {
            _cleanUp.Dispose();
        }

        public ReadOnlyObservableCollection<FilterList> Trees => _trees;

        public string SearchText
        {
            get => _searchText;
            set => this.RaiseAndSetIfChanged(ref _searchText, value);
        }

        public string SelectedSectorFilter
        {
            get => _selectedSectorFilter;
            set => this.RaiseAndSetIfChanged(ref _selectedSectorFilter, value);
        }

        private string SortBy
        {
            get => _sortBy;
            set => this.RaiseAndSetIfChanged(ref _sortBy, value);
        }

        ButtonModel _load_Button_Clicked;

        public ButtonModel Load_Button_Clicked
        {
            get => _load_Button_Clicked;
            set => this.RaiseAndSetIfChanged(ref _load_Button_Clicked, value);
        }

        private async void LoadFilterAction()
        {
            try
            {
                var FilterFile = await FilePicker.PickAsync();
                

                if (FilterFile != null)
                {
                    _sourceCache.Clear();
                    // read JSON 
                    _sourceCache.AddOrUpdate(FilterListService.GetSTrees(File.ReadAllText(FilterFile.FullPath)) );                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("iOS Main Exception: {0}", ex);
            }
        }

        public async void OnEditCommandAction(object SelectedObj)
        {
            FilterList filterList = SelectedObj as FilterList;

            var navService = PageModelLocator.Resolve<NavigationService>();
            await navService.NavigateToAsync<TreeInfoPageModel>(filterList, false);
            return;
        }
        public ReactiveCommand<Unit, Unit> SortCommand { get; }

        private SourceCache<FilterList, string> _sourceCache = new SourceCache<FilterList, string>(x => x.SortField.ToLower());
        private readonly ReadOnlyObservableCollection<FilterList> _trees;
        private string _searchText;
        private string _selectedSectorFilter;
        private string _sortBy;
        public ICommand OnEditCommand { get; set; }

        private readonly IDisposable _cleanUp;
    }
}
