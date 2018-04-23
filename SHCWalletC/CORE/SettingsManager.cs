using System.Configuration;

namespace MonetaVerdeWalletC
{
    class SettingsManager
    {
        //Get and sets parameters during runtime

        public static string getAppSetting(string key)
        {
            //Load the appsettings
            Configuration config = ConfigurationManager.OpenExeConfiguration(
                                    System.Reflection.Assembly.GetExecutingAssembly().Location);
            
            //Fix using try catch when value is not found in appsettings
            try
            {
                //Return the value which matches the key
                return config.AppSettings.Settings[key].Value;
            }
            catch
            {
                return "";
            }
        }

        public static void setAppSetting(string key, string value)
        {
            //Load appsettings
            Configuration config = ConfigurationManager.OpenExeConfiguration(
                                    System.Reflection.Assembly.GetExecutingAssembly().Location);
            //Check if key exists in the settings
            if (config.AppSettings.Settings[key] != null)
            {
                //If key exists, delete it
                config.AppSettings.Settings.Remove(key);
            }
            //Add new key-value pair
            config.AppSettings.Settings.Add(key, value);
            //Save the changed settings
            config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
