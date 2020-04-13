using System;

using KartTrajterWTP.Core.Models;
using KartTrajterWTP.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace KartTrajterWTP.Views
{
    public sealed partial class ContentGridDetailPage : Page
    {
        public ContentGridDetailPage()
        {
            InitializeComponent();
        }

        private ContentGridDetailViewModel ViewModel => DataContext as ContentGridDetailViewModel;
    }
}
