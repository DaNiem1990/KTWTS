using System;

using KartTrajterWTP.ViewModels;

using Windows.UI.Xaml.Controls;

namespace KartTrajterWTP.Views
{
    // For more info about the TreeView Control see
    // https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/tree-view
    // For other samples, get the XAML Controls Gallery app http://aka.ms/XamlControlsGallery
    public sealed partial class TreeViewPage : Page
    {
        private TreeViewViewModel ViewModel => DataContext as TreeViewViewModel;

        public TreeViewPage()
        {
            InitializeComponent();
        }
    }
}
