using MapleSugar.Models;
using MapleSugar.PageModels.Base;
using MapleSugar.ViewModels.Buttons;
using System.Collections.ObjectModel;
using MapleSugar.Services.Navigation;

namespace MapleSugar.PageModels
{
    public class HistoryPageModel : PageModelBase
    {
        // public IEnumerable<IEnumerable<ChartEntry>> MultiBarEntries { get; set; }

        /*  -------------------------------------------------  data fields ---------------------------------------------------------  */
        private string[] _collectionYear;
        public string[] CollectionYear
        {
            get => _collectionYear;
            set
            {
                SetProperty(ref _collectionYear, value);
            }
        }

        public float[] _amountc;
        public float[] Amountc
        {
            get => _amountc;
            set
            {
                SetProperty(ref _amountc, value);
            }
        }

        private float[] _amountb;
        public float[] Amountb
        {
            get => _amountb;
            set
            {
                SetProperty(ref _amountb, value);
            }
        }
        private float[] _amountf;
        public float[] Amountf
        {
            get => _amountf;
            set
            {
                SetProperty(ref _amountf, value);
            }
        }

        private float[] _amountl;
        public float[] Amountl
        {
            get => _amountl;
            set
            {
                SetProperty(ref _amountl, value);
            }
        }

        private string[] _unit;
        public string[] Unit
        {
            get => _unit;
            set
            {
                SetProperty(ref _unit, value);
            }
        }

        /* ------------------------------------    buttons -------------------------------------------- */

        ButtonModel _load_Button_Clicked;
        public ButtonModel Load_Button_Clicked
        {
            get => _load_Button_Clicked;
            set => SetProperty(ref _load_Button_Clicked, value);
        }

        /* ------------------------------------    Misc  -------------------------------------------- */
        private string _historyfile;
        public string HistoryFile
        {

            get => _historyfile;
            set => SetProperty(ref _historyfile, value);
        }

        ObservableCollection<HistoryListItem> _historyItems;

        public ObservableCollection<HistoryListItem> HistoryItems

        {
            get => _historyItems;
            set => SetProperty(ref _historyItems, value);
        }

        private int _lineCount;
        public int LineCount
        {
            get => _lineCount;
            set
            {
                SetProperty(ref _lineCount, value);
            }
        }
       

        /* -------------------------------------------------------------   main code --------------------------------------------- */

        //  public ObservableCollection<Grouping<string, HistoryListItem>> MyItems { get; set; } = new ObservableCollection<Grouping<string, HistoryListItem>>();       


        public HistoryPageModel()
        {
            HistoryItems = new ObservableCollection<HistoryListItem>();
            Load_Button_Clicked = new ButtonModel("Load Data", LoadHistoryAction);
        }

        private async void LoadHistoryAction()
        {
            try
            {
                var HistoryFile = await FilePicker.PickAsync();

                if (HistoryFile != null)
                {
                    // read JSON 
                    var items = HistoryListService.GetSHistory(File.ReadAllText(HistoryFile.FullPath));

                    foreach (var item in items)
                    {
                        HistoryItems.Add(item);
                    }


                    BindingContext = this;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("iOS Main Exception: {0}", ex);
            }
        }      
    }
}
