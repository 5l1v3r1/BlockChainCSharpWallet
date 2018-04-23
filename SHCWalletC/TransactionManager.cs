
namespace MonetaVerdeWalletC
{
    class TransactionManager
    {
        //This class contains all code for receiving / sending transactions
        public static void UpdateBalance(double _newBalance)
        {
            SettingsManager.setAppSetting("Balance", _newBalance.ToString());
        }
        public static string GetBalance()
        {
            return SettingsManager.getAppSetting("Balance");
        }
        public static string GetPubAddress()
        {
            return SettingsManager.getAppSetting("PubAddress");
        }
        public static void GetTransactions()
        {
            //Generate and show transactions
        }
    }
}
