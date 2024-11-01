﻿using MapleSugar.PageModels.Base;
using System.Windows.Input;

namespace MapleSugar.ViewModels.Buttons
{
    public class ButtonModel : ExtendedBindableObject
    {
        string _text;

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        bool _isVisible;

        public bool IsVisible
        {
            get => _isVisible;
            set => SetProperty(ref _isVisible, value);
        }
        bool _isEnabled;

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
         }

        ICommand _command;    

        public ICommand Command
        {
            get => _command;
            set => SetProperty(ref _command, value);
        }

        public ButtonModel(string title, ICommand command, bool isVisible = true, bool isEnabled = false)
        {
            Text = title;
            Command = command;
            IsVisible = isVisible;
            IsEnabled = isEnabled;

        }

        public ButtonModel(string text, Action action, bool isVisible = true, bool isEnabled = false)
        {
            Text = text;
            Command = new Command(action);
            IsVisible = isVisible;
            IsEnabled = isEnabled;

        }


    }
}
