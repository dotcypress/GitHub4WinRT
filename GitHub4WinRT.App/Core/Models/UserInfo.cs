#region

using Newtonsoft.Json;

#endregion

namespace GitHub4WinRT.App.Core.Models
{
    public class UserInfo
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
    }
}
