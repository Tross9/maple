
using MapleSugar.Models;

namespace MapleSugar.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TreeInfoPage : ContentPage
    {
        public TreeInfoPage()
        {
            InitializeComponent();
        }
       
        public TreeInfoPage(CheckListItem checkListItem)
        {
            InitializeComponent();

        }
    }
}
