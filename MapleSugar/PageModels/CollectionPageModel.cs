
using System.Collections.ObjectModel;
using MapleSugar.Models;
using MapleSugar.ViewModels.Buttons;
using MapleSugar.PageModels.Base;
using System.Text;

namespace MapleSugar.PageModels
{
    public class CollectionPageModel : PageModelBase
    {
        public static string CollectionHeader = "";
        public static string SaveStatus = "";

        /*  ------------------------------------------------     Record layout ------------------------------- */

        private string _treeNumber;
        public string TreeNumber
        {

            get => _treeNumber;
            set
            {
                SetProperty(ref _treeNumber, value);
                //  OnPropertyChanged(nameof(saveAllowed));
            }
        }

        private string _subTreeNumber;
        public string SubTreeNumber
        {

            get => _subTreeNumber;
            set
            {
                SetProperty(ref _subTreeNumber, value);
                //  OnPropertyChanged(nameof(saveAllowed));
            }
        }

        private string _collectedAmount;
        public string CollectedAmount
        {
            get => _collectedAmount;
            set => SetProperty(ref _collectedAmount, value);
        }

        /* ------------------------------------------------ Variables  ---------------------------------------- */

        private String _statusMsg;
        public String StatusMsg
        {
            get => _statusMsg;
            set
            {
                SetProperty(ref _statusMsg, value);
            }
        }

        private bool _isDataEmpty;
        public bool IsDataEmpty
        {
            get => _isDataEmpty;
            set
            {
                SetProperty(ref _isDataEmpty, value);
            }
        }

        private bool _noDataFiles;
        public bool NoDataFiles
        {
            get => _noDataFiles;
            set
            {
                SetProperty(ref _noDataFiles, value);
            }
        }

        private string _fileName;
        public string OutputFileName
        {

            get => _fileName;
            set => SetProperty(ref _fileName, value);
        }

        private string _collectionDataToFile;
        public string CollectionDataToFile
        {

            get => _collectionDataToFile;
            set => SetProperty(ref _collectionDataToFile, value);
        }


        double _totalCollected;

        public double TotalCollected
        {
            get => _totalCollected;
            set => SetProperty(ref _totalCollected, value);
        }

        private bool _collectionFileSelected;
        public bool CollectionFileSelected
        {

            get => _collectionFileSelected;
            set => SetProperty(ref _collectionFileSelected, value);
        }

        /* ----------------------------------------------  precode section ----------------------------------------------- */

        ObservableCollection<WorkCollectedItem> _workcollectedItems;

        public ObservableCollection<WorkCollectedItem> WorkCollectedItems
        {
            get => _workcollectedItems;
            set => SetProperty(ref _workcollectedItems, value);
        }


        ButtonModel _saveCollectionDataModel;

        public ButtonModel SaveCollectionDataModel
        {
            get => _saveCollectionDataModel;
            set => SetProperty(ref _saveCollectionDataModel, value);
        }

        ButtonModel _open_File_Clicked;

        public ButtonModel Open_File_Clicked
        {
            get => _open_File_Clicked;
            set => SetProperty(ref _open_File_Clicked, value);
        }
        /*
        ButtonModel _close_App_Clicked;
        public ButtonModel Close_App_Clicked
        {
            get => _close_App_Clicked;
            set => SetProperty(ref _close_App_Clicked, value);
        }
        */
        /* -----------------------------------------------   main code section --------------------------------------  */

        public CollectionPageModel()
        {
            StatusMsg = "Ready";
            var CollectionDate = DateTime.Today;
            WorkCollectedItems = new ObservableCollection<WorkCollectedItem>();
            SaveCollectionDataModel = new ButtonModel("Save Data", OnSaveCollectionDataAction);
            Open_File_Clicked = new ButtonModel("Open File", OpenFileAction);
           // Close_App_Clicked = new ButtonModel("Close App", CloseAppAction);
        }

        public override async Task InitializeAsync(object navigationData)
        {
            TotalCollected = new double();
            // use to  load tree location data ???
            // WorkCollectedItems = await _workService.GetTreeWorkAsync();
            await base.InitializeAsync(navigationData);
        }
        private void OnSaveCollectionDataAction()
        {

            if (int.TryParse(_treeNumber, out _) && double.TryParse(_collectedAmount, out _))
            {
                try
                {
                    StatusMsg = " Checking for  file ";
                    // select file if null
                    if (!(CollectionFileSelected))
                    {
                        try
                        {
                            OpenFileAction();
                        }
                        catch
                        {
                            StatusMsg = "Major Catch error Occured - opening collectionFile";
                        }
                    }

                    try
                    {

                        if (CollectionFileSelected)
                        {
                            StatusMsg = " Validating Data ";
                            TotalCollected += Convert.ToDouble(_collectedAmount);

                            if (string.IsNullOrEmpty(_subTreeNumber))
                            {
                                _subTreeNumber = "0";
                            }

                            StatusMsg = " creating WorkCollectedItems";

                            WorkCollectedItems.Insert(0, new WorkCollectedItem
                            {
                                TreeNumber = Convert.ToInt32(_treeNumber),
                                SubTreeNumber = Convert.ToInt32(_subTreeNumber),
                                CollectedAmount = Convert.ToDouble(_collectedAmount)
                            });

                            StatusMsg = " writting CollectionDataToFile";
                            var CollectionDate = DateTime.Today;
                            CollectionDataToFile = string.Concat(CollectionDate, "|", TreeNumber, "|", SubTreeNumber, "|", CollectedAmount);
                            Task task = SaveDataAsync(CollectionDataToFile, OutputFileName);

                            // var backupFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "count.txt");

                            // clear input fields
                            TreeNumber = "";
                            CollectedAmount = "";
                            SubTreeNumber = "";
                            CollectionFileSelected = true;
                        }
                        else
                        {
                            StatusMsg = " Missing Collection  Data ";
                        }
                    }
                    catch
                    {
                        StatusMsg = "Major Catch error Occured - opening collectionFile";
                    }
                }
                catch
                {
                    StatusMsg = "Major Catch error Occured - TryParse opening collectionFile";
                }
            }
        }

        public static async Task SaveDataAsync(string CollectionDataToFile, string OutputFileName)
        {

            //  FileHelperService filehelper = new FileHelperService();
            //  await filehelper.ShareFileAsync();

            using (var writer = File.AppendText(OutputFileName))
                await writer.WriteLineAsync(CollectionDataToFile.ToString());
        }


        private async void OpenFileAction()
        // private async void Button_Clicked(Object sender, EventArgs e)
        {
            try
            {
                // var PickResult = await FilePicker.PickAsync(new PickOptions
                var CollectionFile = await FilePicker.PickAsync();

                if (CollectionFile != null)
                {
                    var sb = new StringBuilder();
                    OutputFileName = CollectionFile.FullPath;
                    CollectionHeader = sb.Append("CollectionDate|TreeNumber|SubTreeNumber|CollectedAmount").AppendLine().ToString();
                    // File.WriteAllText(OutputFileName);
                    File.WriteAllText(OutputFileName, CollectionHeader);
                    StatusMsg = " File Opened";
                    CollectionFileSelected = true;
                }
                else
                {
                    CollectionFileSelected = false;
                    StatusMsg = "No Data file selected";
                }
            }
            catch (Exception e)
            {
                StatusMsg = " catch error - OpenFileAction " + e ;
            }
        }
        /*
        public void CloseAppAction()
        {
            System.Environment.Exit(0);
        }
        */
    }
}

