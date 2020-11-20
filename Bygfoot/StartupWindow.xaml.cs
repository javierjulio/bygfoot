﻿namespace Bygfoot
{
    using System.ComponentModel;
    using Avalonia;
    using Avalonia.Controls;
    using Avalonia.Markup.Xaml;

    public class StartupWindow : Window
    {
        public StartupWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            DataContext = new StartupWindowViewModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }

    public class StartupWindowViewModel : INotifyPropertyChanged
    {
        private readonly IHintProvider hintProvider;
        private string currentHint;
        private int currentHintNumber;

        public StartupWindowViewModel()
        {
            hintProvider = new HintProvider();
            currentHintNumber = hintProvider.GetLastHintNumber();
            currentHint = hintProvider.GetHint(currentHintNumber++);
        }

        public string HintText
        {
            get => currentHint;
            set
            {
                currentHint = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HintText)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NextButtonClicked() => HintText = hintProvider.GetHint(currentHintNumber++);

        public void PrevButtonClicked() => HintText = hintProvider.GetHint(currentHintNumber--);
    }

    public interface IHintProvider
    {
        int GetTotalHints();
        int GetLastHintNumber();
        string GetHint(int number);
    }

    public class HintProvider : IHintProvider
    {
        public int GetTotalHints() => 10;
        public int GetLastHintNumber() => 1;
        public string GetHint(int hintNumber) => $"This is hint {hintNumber}";
    }
}