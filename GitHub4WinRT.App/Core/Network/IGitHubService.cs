#region

using System.Threading.Tasks;
using GitHub4WinRT.App.Core.Models;

#endregion

namespace GitHub4WinRT.App.Core.Network
{
    public interface IGitHubService
    {
        bool IsLoggedIn { get; }
        Task<UserInfo> GetUserInfo();
        Task<bool> Authenicate();
    }
}
