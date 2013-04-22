#region

using Windows.Storage;

#endregion

namespace GitHub4WinRT.App.Core
{
    public class Settings
    {
        public string AuthToken
        {
            get { return Load<string>("token"); }
            set { Save("token", value); }
        }


        private T Load<T>(string name)
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            if (localSettings.Containers.ContainsKey("AppSettings") && localSettings.Containers["AppSettings"].Values.ContainsKey(name))
            {
                return (T) localSettings.Containers["AppSettings"].Values[name];
            }
            return default(T);
        }

        private void Save<T>(string name, T value)
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            if (!localSettings.Containers.ContainsKey("AppSettings"))
            {
                localSettings.CreateContainer("AppSettings", ApplicationDataCreateDisposition.Always);
            }
            if (localSettings.Containers["AppSettings"].Values.ContainsKey(name))
            {
                localSettings.Containers["AppSettings"].Values[name] = value;
            }
            else
            {
                localSettings.Containers["AppSettings"].Values.Add(name, value);
            }
        }
    }
}
