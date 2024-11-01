
using System.Collections.ObjectModel;
using MapleSugar.Models;
using MapleSugar.ViewModels.Buttons;
using MapleSugar.PageModels.Base;
using MapleSugar.Services.Navigation;

namespace MapleSugar.PageModels
{
    public class TreeInfoPageModel : PageModelBase
    {
        public static string SaveStatus = "";
        /*  -------------------------------------------- record layout  --------------------------------- */
        private string _sector;
        public string Sector
        {
            get => _sector;
            set
            {
                SetProperty(ref _sector, value);
            }
        }

        private string _treeNumber;
        public string TreeNumber
        {
            get => _treeNumber;
            set
            {
                SetProperty(ref _treeNumber, value);
            }
        }

        private string _subTreeNumber;
        public string SubTreeNumber
        {
            get => _subTreeNumber;
            set
            {
                SetProperty(ref _subTreeNumber, value);
            }
        }

        private string _treeSubLetter;
        public string TreeSubLetter
        {
            get => _treeSubLetter;
            set
            {
                SetProperty(ref _treeSubLetter, value);
            }
        }

        private string _treeLocation;
        public string TreeLocation
        {
            get => _treeLocation;
            set
            {
                SetProperty(ref _treeLocation, value);
            }
        }

        private string _circumference;
        public string Circumference
        {
            get => _circumference;
            set
            {
                SetProperty(ref _circumference, value);
            }
        }

        private string _gridX;
        public string GridX
        {
            get => _gridX;
            set
            {
                SetProperty(ref _gridX, value);
            }
        }

        private string _gridY;
        public string GridY
        {
            get => _gridY;
            set
            {
                SetProperty(ref _gridY, value);
            }
        }

        private string _latSec;
        public string LatSec
        {
            get => _latSec;
            set
            {
                SetProperty(ref _latSec, value);
            }
        }

        private string _lonSec;
        public string LonSec
        {
            get => _lonSec;
            set
            {
                SetProperty(ref _lonSec, value);
            }
        }

        private string _treeCombineWith;
        public string TreeCombineWith
        {
            get => _treeCombineWith;
            set
            {
                SetProperty(ref _treeCombineWith, value);
            }
        }

        private string _container;
        public string Container
        {
            get => _container;
            set
            {
                SetProperty(ref _container, value);
            }
        }

        private string _comments;
        public string Comments
        {
            get => _comments;
            set
            {
                SetProperty(ref _comments, value);
            }
        }

        private bool _treeReprintTag;
        public bool TreeReprintTag
        {
            get => _treeReprintTag;
            set
            {
                SetProperty(ref _treeReprintTag, value);
            }
        }

        private bool _treeTapTube;
        public bool TreeTapTube
        {
            get => _treeTapTube;
            set
            {
                SetProperty(ref _treeTapTube, value);
            }
        }

        private bool _treetapped;
        public bool TreeTapped
        {
            get => _treetapped;
            set
            {
                SetProperty(ref _treetapped, value);
            }
        }

        /*  ------------------------------------- check boxes output fields --------------------------------------- */
        private int _reprintTag;
        public int ReprintTag
        {
            get => _reprintTag;
            set
            {
                SetProperty(ref _reprintTag, value);
            }
        }

        private int _tapTube;
        public int TapTube
        {
            get => _tapTube;
            set
            {
                SetProperty(ref _tapTube, value);
            }
        }

        private int _tapped;
        public int Tapped
        {
            get => _tapped;
            set
            {
                SetProperty(ref _tapped, value);
            }
        }

        /*  -------------------------------------------------- Flags and Variables  ----------------------------------------------- */
        private static string ?_fileName;
        public string ?OutputFileName
        {

            get => _fileName;
            set => SetProperty(ref _fileName, value);
        }

        private static bool _locationFileSelected;
        public bool LocationFileSelected
        {

            get => _locationFileSelected;
            set => SetProperty(ref _locationFileSelected, value);
        }

        private string _locationDataToFile;
        public string LocationDataToFile
        {

            get => _locationDataToFile;
            set => SetProperty(ref _locationDataToFile, value);
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

        private bool _saveData;
        public bool SaveData
        {
            get => _saveData;
            set
            {
                SetProperty(ref _saveData, value);
            }
        }

        private bool _clearTreeData;
        public bool ClearTreeData
        {
            get => _clearTreeData;
            set
            {
                SetProperty(ref _clearTreeData, value);
            }
        }

        /*  -----------------------------------------------------  buttons -------------------------------------------------------- */
        ButtonModel _closePageClicked;
        public ButtonModel ClosePageClicked
        {
            get => _closePageClicked;
            set => SetProperty(ref _closePageClicked, value);
        }

        ButtonModel _saveLocationDataModel;

        public ButtonModel SaveLocationDataModel
        {
            get => _saveLocationDataModel;
            set => SetProperty(ref _saveLocationDataModel, value);
        }

        private string _lnavigationData;
        public string LnavigationData
        {

            get => _lnavigationData;
            set => SetProperty(ref _lnavigationData, value);
        }

        /* ---------------------------------------------------------------- main code section ------------------------------------------------*/
        ObservableCollection<WorkTreeLocationItem> _workTreeLocationItems;

        public ObservableCollection<WorkTreeLocationItem> WorkTreeLocationItems
        {
            get => _workTreeLocationItems;
            set => SetProperty(ref _workTreeLocationItems, value);
        }

        /*  main code */
        public TreeInfoPageModel()
        {  
            StatusMsg = "Ready"; 
            WorkTreeLocationItems = new ObservableCollection<WorkTreeLocationItem>();
            SaveLocationDataModel = new ButtonModel("Save Data", OnSaveLocationDataAction);
            ClosePageClicked = new ButtonModel("Return", ClosePageAction, false);
        }

        public override Task InitializeAsync(object navigationData)
        {            

            if (navigationData is WorkCollectedItem)
            {              
                _closePageClicked.IsVisible = false;
                _lnavigationData = "WorkCollectedItem";                
                WorkCollectedItem workCollectedItem = navigationData as WorkCollectedItem;                
            }


            if (navigationData is FilterList)
            {               
                _closePageClicked.IsVisible = true;
                _lnavigationData = "CheckListItem";
                _closePageClicked = new ButtonModel("Return", ClosePageAction, true);


                FilterList workCollectedItem = navigationData as FilterList;

                Sector = workCollectedItem.Sector.ToString();
                TreeNumber = workCollectedItem.TreeNumber.ToString();
                SubTreeNumber = workCollectedItem.SubTreeNumber.ToString();
                TreeSubLetter = workCollectedItem.TreeSubLetter.ToString();
                TreeLocation = workCollectedItem.TreeLocation.ToString();
                Circumference = workCollectedItem.Circumference.ToString();
                if (workCollectedItem.TreeReprintTag == 1)
                {
                    TreeReprintTag = true;
                }
                else
                {
                    TreeReprintTag = false;
                }
                if (workCollectedItem.TreeTapTube == 1)
                {
                    TreeTapTube = true;
                }
                else
                {
                    TreeTapTube = false;
                }
                if (workCollectedItem.Tapped == 1)
                {
                    TreeTapped = true;
                }
                else
                {
                    TreeTapped = false;
                }
                TreeCombineWith = workCollectedItem.TreeCombineWith.ToString();
                if (string.IsNullOrEmpty(workCollectedItem.Comments))
                {
                    Comments = " ";
                }
                else
                {
                    Comments = workCollectedItem.Comments.ToString();
                }
                GridX = workCollectedItem.GridX.ToString();
                GridY = workCollectedItem.GridY.ToString();
                LatSec = workCollectedItem.LatSec.ToString();
                LonSec = workCollectedItem.LonSec.ToString();
                if (string.IsNullOrEmpty(workCollectedItem.Container))
                {
                    Container = " ";
                }
                else
                {
                    Container = workCollectedItem.Container.ToString();
                }
            }
            return base.InitializeAsync(navigationData);
        }

        private void OnSaveLocationDataAction()
        {
            try
            {
                /*  ------------------------------------ test Data  ---------------------------------------- */
                if (string.IsNullOrEmpty(_sector)
                 || string.IsNullOrWhiteSpace(_sector)
                 || string.IsNullOrEmpty(_treeNumber)
                 || string.IsNullOrWhiteSpace(_treeNumber)
                 || string.IsNullOrEmpty(_treeSubLetter)
                 || string.IsNullOrWhiteSpace(_treeSubLetter)
                 || string.IsNullOrEmpty(_treeLocation)
                 || string.IsNullOrWhiteSpace(_treeLocation)
                 || string.IsNullOrEmpty(_circumference)
                 || string.IsNullOrWhiteSpace(_circumference))
                {
                    StatusMsg = "Missing required data fields";
                    SaveData = false;
                }
                else
                {
                    StatusMsg = " Running ";
                    SaveData = true;
                }

                // ----------------------------------------------------- write data  ------------------------------------------------ */
                if (SaveData)
                {
                    StatusMsg = " Checking for  file ";
                    // ----------------------------------- select file if null --------------------------------------------------------*/

                    if (!(LocationFileSelected) || OutputFileName == null)
                    {
                        StatusMsg = " Selecting  file ";
                        OpenFileAction();
                    }
                    // check data 

                    if (LocationFileSelected)
                    {
                        StatusMsg = " Validating Data ";
                        if (_treeReprintTag)
                        {
                            _reprintTag = 1;
                        }
                        else
                        {
                            _reprintTag = 0;
                        }

                        if (_treeTapTube)
                        {
                            _tapTube = 1;
                        }
                        else
                        {
                            _tapTube = 0;
                        }

                        if (_treetapped)
                        {
                            _tapped = 1;
                        }
                        else
                        {
                            _tapped = 0;
                        }

                        if (string.IsNullOrEmpty(_latSec))
                        {
                            _latSec = "0.0";
                        }

                        if (string.IsNullOrEmpty(_lonSec))
                        {
                            _lonSec = "0.0";
                        }

                        if (string.IsNullOrEmpty(_sector))
                        {
                            _sector = "0";
                        }

                        if (string.IsNullOrEmpty(_circumference))
                        {
                            _circumference = "0";
                        }

                        if (string.IsNullOrEmpty(_subTreeNumber))
                        {
                            _subTreeNumber = "0";
                        }

                        if (string.IsNullOrEmpty(_treeCombineWith))
                        {
                            _treeCombineWith = "0";
                        }

                        if (string.IsNullOrEmpty(_container))
                        {
                            _container = "N";
                            if (Convert.ToInt32(_circumference) <= 25)
                            {
                                _container = "S";
                            }
                            else if (Convert.ToInt32(_circumference) <= 30)
                            {
                                _container = "G";
                            }
                            else
                            {
                                _container = "B";
                            }
                        }

                        StatusMsg = " creating WorkTreeLocationItems";

                        _treeSubLetter = _treeSubLetter.ToUpper();
                        _treeLocation = _treeLocation.ToUpper();
                        _container = _container.ToUpper();
                        try
                        {

                            WorkTreeLocationItems.Insert(0, new WorkTreeLocationItem
                            {
                                WorkSector = Convert.ToInt32(_sector),
                                WorkTreeNumber = Convert.ToInt32(_treeNumber),
                                WorkSubTreeNumber = Convert.ToInt32(_subTreeNumber),
                                WorkTreeSubLetter = _treeSubLetter,
                                WorkTreeLocation = _treeLocation,
                                WorkCircumference = Convert.ToDouble(_circumference),
                                WorkReprintTag = _reprintTag,
                                WorkTapTube = _tapTube,
                                WorkTreeCombineWith = Convert.ToDouble(_treeCombineWith),
                                WorkComments = _comments,
                                WorkGridX = Convert.ToDouble(_gridX),
                                WorkGridY = Convert.ToDouble(_gridY),
                                WorkTapped = _tapped,
                                WorkLatSec = Convert.ToDouble(_latSec),
                                WorkLonSec = Convert.ToDouble(_lonSec),
                                WorkContainer = _container
                            });
                        }
                        catch
                        {
                            StatusMsg = "Major Catch error Occured - creating WorkTreeLocationItems";

                        }
                        try
                        {
                            LocationDataToFile = string.Concat(
                                 Sector, "|", TreeNumber, "|", SubTreeNumber, "|", TreeSubLetter, "|",
                                        TreeLocation, "|", Circumference, "|", ReprintTag, "|", TapTube, "|",
                                        TreeCombineWith, "|", Comments, "|", GridX, "|", GridY, "|",
                                        Tapped, "|", LatSec, "|", LonSec, "|", Container
                                );
                            StatusMsg = " Saving Data to Output ";
                            Task task = SaveDataAsync(LocationDataToFile, OutputFileName);
                            StatusMsg = SaveStatus;

                            // clear input fields
                            if (_clearTreeData)
                            {
                                Sector = "";
                                TreeNumber = "";
                                SubTreeNumber = "";
                                TreeSubLetter = "";
                                TreeLocation = "";
                                Circumference = "";
                                TreeReprintTag = false;
                                TreeTapTube = false;
                                TreeCombineWith = "";
                                Comments = "";
                                GridX = "";
                                GridY = "";
                                TreeTapped = false;
                                LatSec = "";
                                LonSec = "";
                                Container = "";
                            }
                            else
                            {
                                TreeSubLetter = "";
                                Circumference = "";
                                TreeReprintTag = false;
                                TreeTapTube = false;
                                Comments = "";
                                TreeTapped = false;
                            }

                            StatusMsg = " Ready ";
                            if (LnavigationData == "CheckListItem")
                            {
                                Navigateback();
                            }

                        }
                        catch
                        {
                            StatusMsg = "Major Catch error Occured - writting LocationDataToFile";

                        }
                    }
                }
                else
                {

                    StatusMsg = " Missing TreeNumber Or SaveData Flag";
                }
            }
            catch (Exception e)
            {
                StatusMsg = "Major Catch error Occured - OnSaveLocationDataAction" + e;
            }
        }

        public static async Task SaveDataAsync(string CollectionDataToFile, string OutputFileName)
        {
            try
            {
                using (var writer = File.AppendText(OutputFileName))

                    await writer.WriteLineAsync(CollectionDataToFile.ToString());

                SaveStatus = "Data record saved";
            }
            catch
            {
                SaveStatus = "Catch error - Data record NOT Saved";
            }
        }

        private async void OpenFileAction()
        // private async void Button_Clicked(Object sender, EventArgs e)
        {
            try
            {
                var LocationFile = await FilePicker.PickAsync();
                OutputFileName = LocationFile.FullPath;

                if (LocationFile != null)
                {
                    LocationFileSelected = true;
                    StatusMsg = " Creating Header";
                    LocationDataToFile = string.Concat("TreeSector|" +
                            "TreeNumber|" +
                            "SubTreeNumber|" +
                            "TreeSubLetter|" +
                            "TreeLocation|" +
                            "TreeCircumference|" +
                            "TreeReprint|" +
                            "TreeTapTube|" +
                            "TreeCombineWith" +
                            "Comments|" +
                            "GridX|" +
                            "GridY|" +
                            "Tapped|" +
                            "TreeLatSec|" +
                            "TreeLonSec|" +
                            "Container"
                        );
                    Task task = SaveDataAsync(LocationDataToFile, OutputFileName);

                }
                else
                {
                    LocationFileSelected = false;
                    StatusMsg = "No Data file selected";
                }
            }
            catch
            {
                StatusMsg = "Major Catch error Occured - opening LocationFile";
            }
        }

        public void ClosePageAction()
        {
            Navigateback();
        }

        public async void Navigateback()
        {
            // Navigate backwards
            var navService = PageModelLocator.Resolve<NavigationService>();
            await navService.GoBackAsync();

            //await navService.NavigateToAsync<CheckListPageModel>();
        }
    }
}

