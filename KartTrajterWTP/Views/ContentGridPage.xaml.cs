using System;

using KartTrajterWTP.ViewModels;

using Windows.UI.Xaml.Controls;

namespace KartTrajterWTP.Views
{
    public sealed partial class ContentGridPage : Page
    {
        private ContentGridViewModel ViewModel => DataContext as ContentGridViewModel;

        public ContentGridPage()
        {
            InitializeComponent();
        }
    }
}
