using System;

using KartTrajterWTP.ViewModels;

using Windows.UI.Xaml.Controls;

namespace KartTrajterWTP.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel => DataContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
