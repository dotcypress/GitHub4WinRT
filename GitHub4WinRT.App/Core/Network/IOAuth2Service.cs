#region

using System.Threading.Tasks;

#endregion

namespace GitHub4WinRT.App.Core.Network
{
    public interface IOAuth2Service
    {
        Task<string> RequestToken();
    }
}
