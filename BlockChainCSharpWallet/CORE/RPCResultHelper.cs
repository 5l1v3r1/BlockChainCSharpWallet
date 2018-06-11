using System;
using JsonRPC;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace BlockChainCSharpWallet.CORE
{
    class RPCResultHelper
    {

        public static string[] jsonResult(GenericResponse _response)
        {
            IEnumerator resultsEnumerator;
            IEnumerable results;

            string[] values = new string[0];
            int x = 0;

            if (_response == null)
            {
                //Avoid errors when connection did not result in a response
                return values;  //Return empty
            }

            results = _response.Result.Values();
            resultsEnumerator = results.GetEnumerator();

            while (resultsEnumerator.MoveNext())
            {
                Array.Resize(ref values, values.Length + 1);
                values[x] = resultsEnumerator.Current.ToString();
                x++;
            }

            return values;
        }
    }
}
