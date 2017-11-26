using System;
using System.Collections.Generic;
using System.Text;

namespace NETStandard
{
    public class Constants
    {
        /*
         * 10.0.2.1    Router/gateway address
         * 10.0.2.2    Special alias to your host loopback interface (i.e., 127.0.0.1 on your development machine)
         * 10.0.2.3    First DNS server
         * 10.0.2.4 / 10.0.2.5 / 10.0.2.6  Optional second, third and fourth DNS server (if any)
         * 10.0.2.15   The emulated device's own network/ethernet interface
         * 127.0.0.1   The emulated device's own loopback interface
         */

        /// <summary>
        /// URL of REST service.
        /// </summary>
        public static string RestUrl = "http://10.0.2.2:5000/api/movie/{0}";
        // Credentials that are hard coded into the REST service
        public static string Username = "Username";
        public static string Password = "Password";
    }
}
