using System;

namespace MonetaVerdeWalletC
{
    class Wallet
    {
        string []                       inboundArgs;
        Boolean                         isLoggedIn = false;
        String                          daemonIPPort = "127.0.0.1:26081";   //Expect localhost
		Boolean							connectionStable = true;

        public void Run(string[] args)
        {
            //Here the application starts, first handle the incoming parameters
            inboundArgs = args;
            handleParms();      //Handle incoming parms

            /*
            - submitblock:              Works :)
            - getblockcount:            Works :)
            - getBlock:                 Does not work :( ...needs the new build binaries later on (fixed by Jakzodiac)
            - on_getblockhash:          Works with the right parms
            - getlastblockheader:       Works :)
            - getblockheaderbyhash:     Works with the right parms
            - getblockheaderbyheight:   Works :)
            - getcurrencyid:            Works :)
            - getblocktemplate:         Works :)
            */

            //TESTING
            setDaemonIpPort();
			Console.WriteLine(KeyManager.GenerateKeySet());              //Test generating a key 

			connectionStable = RPCConnectionManager.SendRPCJson("getblockcount", "");  //Params have to be filled. Todo later on

			if (!connectionStable)
			{
				//Quit application when connection with daemon is not working
				Environment.Exit(1);
			}

            if (!isLoggedIn)
            {
                LoginManager.Login(); //Login if required
                isLoggedIn = true;  //If we pass this marker, we're logged in
                IdleState();
            }  
            //TODO: Set to idle state
        }
        public void setDaemonIpPort()
        {
            SettingsManager.setAppSetting("daemonIPPort", daemonIPPort);    //Basic set IPPort
        }

        public void IdleState()
        {
            String actionToHandle = "";
            //Supports the idle state and listen for input
            do
            {
                actionToHandle = UserInteractionManager.WaitForUserInput();
                UserInteractionManager.HandleNewUserRequest(actionToHandle);    //We have a new request from the user, handle it
                //And we revert to the idle state
            } while (actionToHandle != "Exit");
        //When exit command has been entered, the method ends and the application is also done
        }

        public void handleParms()
        {           
            Boolean ShouldAttemptLogin = false;
            String walletID  = "";
            String Pass      = "";
            //Handle the incoming parms

            foreach (string s in inboundArgs)   //Loop commands
            {
                Console.WriteLine(s);
                int Stop = s.IndexOf(":");
                String action = s.Substring(0, Stop);

                switch (action)
                {
                    case "--Help":
                        {
                            Help.ShowHelp();
                            break;
                        }
                    case "--walletname":
                        {
                            walletID = s.Substring(13);
                            SettingsManager.setAppSetting("walletID", walletID);
                            ShouldAttemptLogin = true;
                            break;
                        }
                    case "--daemonipport":
                        {
                            daemonIPPort = s.Substring(13);
                            setDaemonIpPort();  //Set ip+port
                            break;
                        }
                    case "--Password":
                        {
                            Pass = s.Substring(11);
                            SettingsManager.setAppSetting("pass", Pass);
                            ShouldAttemptLogin = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Unknown parameter: {0}", action);
                            break;
                        }
                }
            }
            //After foreach
            if (ShouldAttemptLogin)
            {
                if(LoginManager.Login())
                {
                    isLoggedIn = true;
                    IdleState();
                }
            }
        }
    }
}
