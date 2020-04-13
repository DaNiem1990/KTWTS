using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

using KartTrajterWTP.Core.Services;
using KartTrajterWTP.Helpers;
using KartTrajterWTP.Services;

using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

using Windows.ApplicationModel;
using Windows.UI.Xaml;

namespace KartTrajterWTP.ViewModels
{
    // TODO WTS: Add other settings as necessary. For help see https://github.com/Microsoft/WindowsTemplateStudio/blob/master/docs/pages/settings.md
    public class SettingsViewModel : ViewModelBase
    {
        private IUserDataService _userDataService;
        private IIdentityService _identityService;
        private ElementTheme _elementTheme = ThemeSelectorService.Theme;
        private UserViewModel _user;

        public UserViewModel User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        public ICommand LogoutCommand { get; }

        public ElementTheme ElementTheme
        {
            get { return _elementTheme; }

            set { SetProperty(ref _elementTheme, value); }
        }

        private string _versionDescription;

        public string VersionDescription
        {
            get { return _versionDescription; }

            set { SetProperty(ref _versionDescription, value); }
        }

        private ICommand _switchThemeCommand;

        public ICommand SwitchThemeCommand
        {
            get
            {
                if (_switchThemeCommand == null)
                {
                    _switchThemeCommand = new DelegateCommand<object>(
                        async (param) =>
                        {
                            ElementTheme = (ElementTheme)param;
                            await ThemeSelectorService.SetThemeAsync((ElementTheme)param);
                        });
                }

                return _switchThemeCommand;
            }
        }

        public SettingsViewModel(IIdentityService identityService, IUserDataService userDataService)
        {
            _identityService = identityService;
            _userDataService = userDataService;
            LogoutCommand = new DelegateCommand(OnLogout);
        }

        public async Task InitializeAsync()
        {
            VersionDescription = GetVersionDescription();
            _identityService.LoggedOut += OnLoggedOut;
            _userDataService.UserDataUpdated += OnUserDataUpdated;
            User = await _userDataService.GetUserAsync();
        }

        public void UnregisterEvents()
        {
            _identityService.LoggedOut -= OnLoggedOut;
            _userDataService.UserDataUpdated -= OnUserDataUpdated;
        }

        private void OnUserDataUpdated(object sender, UserViewModel userData)
        {
            User = userData;
        }

        private async void OnLogout()
        {
            await _identityService.LogoutAsync();
        }

        private void OnLoggedOut(object sender, EventArgs e)
        {
            UnregisterEvents();
        }

        private string GetVersionDescription()
        {
            var appName = "AppDisplayName".GetLocalized();
            var package = Package.Current;
            var packageId = package.Id;
            var version = packageId.Version;

            return $"{appName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            await InitializeAsync();
        }

        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatingFrom(e, viewModelState, suspending);
            UnregisterEvents();
        }
    }
}
