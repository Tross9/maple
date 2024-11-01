using MapleSugar.ViewModels.Buttons;
using System;


namespace MapleSugar.PageModels
{
    class CloseAppPageModel
    {

        public ButtonModel Close_App_Clicked
        {
            get;
            set;
        }

        public CloseAppPageModel()
        {

            Close_App_Clicked = new ButtonModel("Close App", CloseAppAction);
        }

        public void CloseAppAction()
        {
            System.Environment.Exit(0);
        }
    }
}
