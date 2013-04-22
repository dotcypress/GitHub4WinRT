#region

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Tumbaga.Logging;
using Windows.Foundation;
using Windows.Security.Authentication.Web;

#endregion

namespace GitHub4WinRT.App.Core.Network
{
    public class OAuth2Service : IOAuth2Service
    {
        private readonly ILogger _logger;

        public OAuth2Service(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<string> RequestToken()
        {
            const string url = "https://github.com/login/oauth/authorize?client_id=8d945f08b133bd8b012c&scope=user,public_repo";
            var startUri = new Uri(url);
            var endUri = new Uri("https://github.com/dotCypress/GitHub4WinRT");

            try
            {
                var authenticationResult = await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None, startUri, endUri);
                if (authenticationResult.ResponseStatus == WebAuthenticationStatus.Success)
                {
                    var redirectUri = new Uri(authenticationResult.ResponseData);
                    var code = new WwwFormUrlDecoder(redirectUri.Query).GetFirstValueByName("code");
                    var client = new HttpClient();
                    var postResult = await client.PostAsync(new Uri("https://github.com/login/oauth/access_token?client_id=8d945f08b133bd8b012c&client_secret=4970b55c24fa2e903ead07c5a6ed13e8ab034b31&code=" + code), null);
                    var resultString = await postResult.Content.ReadAsStringAsync();
                    return new WwwFormUrlDecoder(resultString).GetFirstValueByName("access_token");
                }
            }
            catch (Exception ex)
            {
                _logger.Error("OAuth2Service error", ex);
            }
            return null;
        }
    }
}
