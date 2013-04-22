#region

using GitHub4WinRT.App.Core;
using GitHub4WinRT.App.Views;
using Tumbaga.Commands;
using Tumbaga.IoC;
using Tumbaga.MVVM;

#endregion

namespace GitHub4WinRT.App.ViewModels
{
    public class HelpPageViewModel : ViewModel
    {
        [Inject]
        public NavigateCommand<MainPage> NavigateBackCommand { get; set; }

        protected override void OnLoad()
        {
            MetroGridHelper.CreateGrid();
        }
    }
}
