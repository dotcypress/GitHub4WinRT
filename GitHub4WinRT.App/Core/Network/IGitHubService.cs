#region

using System.Threading.Tasks;
using GitHub4WinRT.App.Core.Models;

#endregion

namespace GitHub4WinRT.App.Core.Network
{
    public interface IGitHubService
    {
        Task<UserInfo> GetUserInfo();
        bool IsLoggedIn { get; }
        Task<bool> Authenicate();
    }
}
