#region

using GitHub4WinRT.App.Core.Network;
using GitHub4WinRT.App.Views;
using Tumbaga;
using Tumbaga.Logging;

#endregion

namespace GitHub4WinRT.App
{
    sealed partial class App : AppBootstrapper
    {
        public App() : base(typeof (MainPage))
        {
            InitializeComponent();
            InitBootstrapper();
        }

        private void InitBootstrapper()
        {
            Container.Register<ILogger, DebugLogger>();
            Container.Register<IOAuth2Service, OAuth2Service>();
            Container.Register<IGitHubService, GitHubService>();
        }
    }
}
