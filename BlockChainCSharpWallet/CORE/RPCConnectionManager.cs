using System;
using JsonRPC;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using SHCWalletC.CORE;

namespace SHCWalletC.CORE
{
    public class RPCConnectionManager
    {
        //This class contains all code to interact with RPC
        public static GenericResponse SendRPCJson(string _method, string _params = "")
        {
            string URL      = "http://" + Preference.ReadBlobToPreferences().daemonIPPort + "/json_rpc";    //Get parameter for IP+Port
            GenericResponse response;

            using (Client rpcClient = new Client(URL))
            {
                JArray parameters = JArray.Parse(@"['9000']");  //TODO: set parameters

                Request request = rpcClient.NewRequest(_method, parameters);
                //GenericResponse 
                    response = rpcClient.Rpc(request);

				if (response != null)
				{
					if (response.Result != null)
					{
						JToken result = response.Result;

						Console.WriteLine("Connection success for method {0} : daemon says: {1}", _method, result);
					}
					else
					{
						Console.WriteLine(string.Format("Error in response, code:{0} message:{1}",
						response.Error.Code, response.Error.Message));
					}
                }
                else
                {
					Console.WriteLine("Serious issues occured in connecting to the daemon, please check the setup or check if the daemon is running...");
                    return null;
                }
            }

			return response;
        }

        public static void TestRPCJsonGet()
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:51485/getinfo");
            httpWebRequest.Method = WebRequestMethods.Http.Get;
            httpWebRequest.Accept = "application/json";

            var response = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }
    }
}
