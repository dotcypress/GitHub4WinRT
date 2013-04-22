#region

using System.Threading.Tasks;
using GitHub4WinRT.App.Core;
using GitHub4WinRT.App.Core.Models;
using GitHub4WinRT.App.Core.Network;
using GitHub4WinRT.App.Views;
using Tumbaga.Commands;
using Tumbaga.IoC;
using Tumbaga.Logging;
using Tumbaga.MVVM;

#endregion

namespace GitHub4WinRT.App.ViewModels
{
    public class MainPageViewModel : ViewModel
    {
        private UserInfo _currentUser;

        [Inject]
        public NavigateCommand<HelpPage> OpenAboutCommand { get; set; }

        [Inject]
        public ILogger Logger { get; set; }

        [Inject]
        public IGitHubService GitHubService { get; set; }

        public UserInfo CurrentUser
        {
            get { return _currentUser; }
            set { SetProperty(ref _currentUser, value); }
        }

        protected override async void OnLoad()
        {
            MetroGridHelper.CreateGrid();
            if (!GitHubService.IsLoggedIn)
            {
                await GitHubService.Authenicate();
            }
            CurrentUser = await GitHubService.GetUserInfo();
        }
    }
}
