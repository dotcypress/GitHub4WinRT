#region

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GitHub4WinRT.App.Core.Models;
using Newtonsoft.Json;

#endregion

namespace GitHub4WinRT.App.Core.Network
{
    public class GitHubService : IGitHubService
    {
        private readonly IOAuth2Service _oAuth2Service;
        private readonly Settings _settings;

        public GitHubService(Settings settings, IOAuth2Service oAuth2Service)
        {
            _settings = settings;
            _oAuth2Service = oAuth2Service;
        }

        public bool IsLoggedIn
        {
            get { return _settings.AuthToken != null; }
        }

        public async Task<UserInfo> GetUserInfo()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "token " + _settings.AuthToken);
            var result = await client.GetAsync("https://api.github.com/user");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var value = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UserInfo>(value);
            }
            return null;
        }


        public async Task<bool> Authenicate()
        {
            _settings.AuthToken = await _oAuth2Service.RequestToken();
            return IsLoggedIn;
        }
    }
}
