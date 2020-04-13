using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

using KartTrajterWTP.Core.Models;
using KartTrajterWTP.Core.Services;

using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

using WinUI = Microsoft.UI.Xaml.Controls;

namespace KartTrajterWTP.ViewModels
{
    public class TreeViewViewModel : ViewModelBase
    {
        private readonly ISampleDataService _sampleDataService;
        private ICommand _itemInvokedCommand;
        private object _selectedItem;

        public object SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        public ObservableCollection<SampleCompany> SampleItems { get; } = new ObservableCollection<SampleCompany>();

        public ICommand ItemInvokedCommand => _itemInvokedCommand ?? (_itemInvokedCommand = new DelegateCommand<WinUI.TreeViewItemInvokedEventArgs>(OnItemInvoked));

        public TreeViewViewModel(ISampleDataService sampleDataServiceInstance)
        {
            _sampleDataService = sampleDataServiceInstance;
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);

            var data = await _sampleDataService.GetTreeViewDataAsync();
            foreach (var item in data)
            {
                SampleItems.Add(item);
            }
        }

        private void OnItemInvoked(WinUI.TreeViewItemInvokedEventArgs args)
            => SelectedItem = args.InvokedItem;
    }
}
