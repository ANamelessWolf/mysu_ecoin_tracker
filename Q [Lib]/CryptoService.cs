using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Msyu.Q
{
    public class CryptoService
    {
        /// <summary>
        /// The format URL
        /// <example>
        /// https://min-api.cryptocompare.com/data/pricemulti?fsyms=BTC,XRP,ETH&tsyms=MXN,USD
        /// </example>
        /// </summary>
        const String FORMAT_URL = "https://min-api.cryptocompare.com/data/pricemulti?fsyms={0}&tsyms={1}";
        /// <summary>
        /// The coins used to make the petition
        /// </summary>
        public String[] ECoins;
        /// <summary>
        /// The coins used to make the petition
        /// </summary>
        public String[] LocalCoins;
        /// <summary>
        /// Gets the URL.
        /// </summary>
        /// <returns>Gets the crypto service URL</returns>
        public String GetUrl()
        {
            StringBuilder eB = new StringBuilder(),
                          lB = new StringBuilder();
            ECoins.ToList().ForEach(x => eB.Append(String.Format("{0},", x)));
            LocalCoins.ToList().ForEach(x => lB.Append(String.Format("{0},", x)));
            return String.Format(FORMAT_URL, eB.ToString().Substring(0, eB.Length - 1), lB.ToString().Substring(0, lB.Length - 1));
        }

    }
}
