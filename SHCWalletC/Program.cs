
namespace MonetaVerdeWalletC
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Open the application
            Wallet wallet = new Wallet();
            wallet.Run(args);
        }
    }
}
