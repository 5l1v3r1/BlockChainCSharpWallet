using System;
using JsonRPC;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace SHCWalletC.CORE
{
    class RPCResultHelper
    {

        public static string[] jsonResult(GenericResponse _response)
        {
            IEnumerator resultsEnumerator;
            IEnumerable results = _response.Result.Values();
            resultsEnumerator = results.GetEnumerator();
            string[] values = new string[0];
            int x = 0;

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
